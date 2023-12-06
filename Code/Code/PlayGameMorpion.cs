using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Code
{
    public partial class PlayGameMorpionForm : Form
    {
        private string grandCercle = "..\\..\\..\\Images\\GrandCercle.png";
        private string grandeCroix = "..\\..\\..\\Images\\GrandeCroix.png";
        private int[,] isOccupiedBy = new int[3, 3];
        private bool circleTurn;
        private bool isgameEnded;
        private bool isBotPlays;
        private Label[,] labels;
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
            int rdmColumn;
            int rdmRow;

            isBotPlays = true;

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

        private async void PlaceSymbol(int idLabelColumn, int idLabelRow, Label label)
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
                        if (VerifyWinner(isOccupiedBy) == 1)
                        {
                            ResultLabel.Text = "O won !";
                            ResultLabel.ForeColor = Color.Red;
                        }

                        if (VerifyWinner(isOccupiedBy) == 2)
                        {
                            ResultLabel.Text = "X won !";
                            ResultLabel.ForeColor = Color.Blue;
                        }

                        if (VerifyWinner(isOccupiedBy) == 3)
                        {
                            ResultLabel.Text = "It's a tie...";
                            ResultLabel.ForeColor = Color.Black;
                        }

                        XsTurnLabel.Visible = false;
                        OsTurnLabel.Visible = false;

                        while (true) {
                            for (int r = 0; r <= 255; r += 100)
                            {
                                for (int g = 0; g <= 255; g += 100)
                                {
                                    for (int b = 0; b <= 255; b++)
                                    {
                                        ResultLabel.ForeColor = Color.FromArgb(r, g, b);
                                        await Task.Delay(1);
                                        break;
                                    }
                                }
                            }
                        }
                     
                        isgameEnded = true;
                    }
                    else
                    {
                        WhosTurn();

                        if (GameMenuForm.onePlayer)
                        {
                            if (!isBotPlays)
                            {
                                await Task.Delay(1000);
                                BotPlays(labels);
                            }
                            else isBotPlays = false;
                        }
                    }
                }
            }
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
    }
}