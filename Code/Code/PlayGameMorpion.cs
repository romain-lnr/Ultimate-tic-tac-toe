﻿using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code
{
    public partial class PlayGameMorpionForm : Form
    {
        const int MAX_INTENSITY = 228;

        private string grandCercle = "..\\..\\..\\Images\\GrandCercle.png";
        private string grandeCroix = "..\\..\\..\\Images\\GrandeCroix.png";
        private int[,] isOccupiedBy = new int[3, 3];
        private bool circleTurn;
        private bool isgameEnded;
        private bool isBotPlays;
        private Label[,] labels;
        private int r, g, b, x;
        int red, green, blue, gradientIndex;

        int[,] gradients = { { 0, 0, 1 }, { 0, 1, 0 }, { 0, 0, -1 }, { 1, 0, 0 }, { 0, -1, 0 }, { 0, 0, 1 }, { 0, 1, 0 }, { -1, -1, -1 } };

        Random random = new Random((int)DateTime.Now.Ticks);

        private void WhosTurn()
        {
            if (circleTurn)
            {
                OsTurnLabel.Enabled = true;
                XsTurnLabel.Enabled = false;
            }
            else
            {
                XsTurnLabel.Enabled = true;
                OsTurnLabel.Enabled = false;
            }

        }

        public PlayGameMorpionForm()
        {
            InitializeComponent();

            isgameEnded = false;

            labels = new Label[,] { { TopLeftLabel, TopLabel, TopRightLabel },
                                    { LeftLabel, MiddleLabel, RightLabel },
                                    { BottomLeftLabel, BottomLabel, BottomRightLabel } };

            int zeroOrOne = random.Next(0, 2);

            circleTurn = (zeroOrOne == 0) ? true : false;

            WhosTurn();

            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    isOccupiedBy[column, row] = 0;
                }
            }

            if (GameMenuForm.onePlayer && !circleTurn)
            {
                BotPlays(labels);
            }
        }

        private void BotPlays(Label[,] labels)
        {
            int rdmColumn, rdmRow;
            int[] countCircle = new int[2] { 0, 0 }, countCross = new int[2] { 0, 0 };
            isBotPlays = true;

            for (int column = 0; column < 3; column++)
            {
                // Check both rows and columns in a single loop
                for (int i = 0; i < 2; i++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        int value = (i == 0) ? isOccupiedBy[column, row] : isOccupiedBy[row, column];

                        if (value == 1) countCircle[i]++;
                        else if (value == 2) countCross[i]++;
                    }

                    if (countCircle[i] == 2 || countCross[i] == 2)
                    {
                        for (int rerow = 0; rerow < 3; rerow++)
                        {
                            int currentColumn = (i == 0) ? column : rerow;
                            int currentRow = (i == 0) ? rerow : column;

                            if (isOccupiedBy[currentColumn, currentRow] == 0)
                            {
                                PlaceSymbol(currentColumn, currentRow, labels[currentColumn, currentRow]);
                                return;
                            }
                        }
                    }

                    // Reset counts for the next iteration
                    countCircle[i] = countCross[i] = 0;
                }

                // Check both diagonals in a single loop
                for (int i = 0; i < 2; i++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        int value = (i == 0) ? isOccupiedBy[row, row] : isOccupiedBy[row, 2 - row];

                        if (value == 1) countCircle[i]++;
                        else if (value == 2) countCross[i]++;
                    }

                    if (countCircle[i] == 2 || countCross[i] == 2)
                    {
                        for (int rerow = 0; rerow < 3; rerow++)
                        {
                            int currentColumn = (i == 0) ? rerow : 2 - rerow;
                            int currentRow = (i == 0) ? rerow : rerow;

                            if (isOccupiedBy[currentColumn, currentRow] == 0)
                            {
                                PlaceSymbol(currentColumn, currentRow, labels[currentColumn, currentRow]);
                                return;
                            }
                        }
                    }
                    countCircle[i] = countCross[i] = 0;
                }
            }

            do
            {
                rdmColumn = random.Next(0, 3);
                rdmRow = random.Next(0, 3);
            } while (isOccupiedBy[rdmColumn, rdmRow] != 0);

            PlaceSymbol(rdmColumn, rdmRow, labels[rdmColumn, rdmRow]);
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            // Quit the game
            System.Windows.Forms.Application.Exit();
        }

        private void TheLabel_Click(object sender, EventArgs e)
        {
            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (labels[column, row] == sender)
                    {
                        if (GameMenuForm.onePlayer)
                        {
                            if (circleTurn) PlaceSymbol(column, row, (Label)sender);
                        }
                        else PlaceSymbol(column, row, (Label)sender);
                    }
                }
            }
        }

        private void PlaceSymbol(int idLabelColumn, int idLabelRow, Label label)
        {
            if (!isgameEnded)
            {
                if (isOccupiedBy[idLabelColumn, idLabelRow] == 0)
                {
                    if (circleTurn)
                    {
                        label.Image = System.Drawing.Image.FromFile(grandCercle);
                        isOccupiedBy[idLabelColumn, idLabelRow] = 1;
                        circleTurn = false;
                    }
                    else
                    {
                        label.Image = System.Drawing.Image.FromFile(grandeCroix);
                        isOccupiedBy[idLabelColumn, idLabelRow] = 2;
                        circleTurn = true;
                    }

                    if (VerifyWinner(isOccupiedBy) != 0)
                    {

                        XsTurnLabel.Visible = false;
                        OsTurnLabel.Visible = false;

                        isgameEnded = true;

                        if (VerifyWinner(isOccupiedBy) == 1)
                        {
                            ResultLabel.Text = "O won !";
                            ColorizeRgbText();
                        }
                        else if (VerifyWinner(isOccupiedBy) == 2)
                        {
                            ResultLabel.Text = "X won !";
                            ColorizeRgbText();
                        }
                        else ResultLabel.Text = "It's a tie !";
                    }
                    else
                    {
                        WhosTurn();

                        if (GameMenuForm.onePlayer)
                        {
                            if (!isBotPlays) BotTimer_Classic.Enabled = true;
                            isBotPlays = false;
                        }
                    }
                }
            }
        }

        private void ColorizeRgbText()
        {
            r = 0;
            g = 0;
            b = 0;
            x = 0;
            gradientIndex = 0;
            red = gradients[gradientIndex, 0];
            green = gradients[gradientIndex, 1];
            blue = gradients[gradientIndex, 2];
            RGBTimer_Classic.Enabled = true;
        }

        private void RGBTimer_Classic_Tick(object sender, EventArgs e)
        {
            if (x > MAX_INTENSITY)
            {
                if (gradientIndex >= gradients.Length / 3 - 1)
                {
                    gradientIndex = -1;
                }
                x = 0;
                gradientIndex++;
                red = gradients[gradientIndex, 0];
                green = gradients[gradientIndex , 1];
                blue = gradients[gradientIndex, 2];
            }

            if (red != 0)
            {
                r = red > 0 ? red * x : MAX_INTENSITY + red * x;
            }

            if (green != 0)
            {
                g = green > 0 ? green * x : MAX_INTENSITY + green * x;
            }

            if (blue != 0)
            {
                b = blue > 0 ? blue * x : MAX_INTENSITY + blue * x;
            }
            ResultLabel.ForeColor = Color.FromArgb(r, g, b);

            x = x + 4;
        }

        private int VerifyWinner(int[,] isOccupiedBy)
        {
            // Verify straight row vertically
            for (int column = 0; column < 3; column++)
            {
                if ((isOccupiedBy[column, 0] == 1 && isOccupiedBy[column, 1] == 1 && isOccupiedBy[column, 2] == 1) || (isOccupiedBy[column, 0] == 2 && isOccupiedBy[column, 1] == 2 && isOccupiedBy[column, 2] == 2))
                {
                    return isOccupiedBy[column, 0];
                }
            }

            // Verify straight row horizontally
            for (int row = 0; row < 3; row++)
            {
                if ((isOccupiedBy[0, row] == 1 && isOccupiedBy[1, row] == 1 && isOccupiedBy[2, row] == 1) || (isOccupiedBy[0, row] == 2 && isOccupiedBy[1, row] == 2 && isOccupiedBy[2, row] == 2))
                {
                    return isOccupiedBy[0, row];
                }
            }

            // Verify horizontal right row
            if ((isOccupiedBy[0, 0] == 1 && isOccupiedBy[1, 1] == 1 && isOccupiedBy[2, 2] == 1) || (isOccupiedBy[0, 0] == 2 && isOccupiedBy[1, 1] == 2 && isOccupiedBy[2, 2] == 2))
            {
                return isOccupiedBy[0, 0];
            }
            // Verify horizontal left row
            else if ((isOccupiedBy[0, 2] == 1 && isOccupiedBy[1, 1] == 1 && isOccupiedBy[2, 0] == 1) || (isOccupiedBy[0, 2] == 2 && isOccupiedBy[1, 1] == 2 && isOccupiedBy[2, 0] == 2))
            {
                return isOccupiedBy[0, 2];
            }
            int num = 0;
            // Verify tie
            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (isOccupiedBy[column, row] != 0) num++;
                }
            }
            if (num == 9) return 3;
            return 0;
        }

        private void BotTimer_Classic_Tick(object sender, EventArgs e)
        {
            BotPlays(labels);
            BotTimer_Classic.Enabled = false;
        }

    }
}