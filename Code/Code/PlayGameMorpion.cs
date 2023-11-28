using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
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

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    isOccupiedBy[i, j] = 0;
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

        private void TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 0, TopLeftLabel);
        }

        private void TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 1, TopLabel);
        }

        private void TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 2, TopRightLabel);
        }

        private void LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 0, LeftLabel);
        }

        private void MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 1, MiddleLabel);
        }

        private void RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 2, RightLabel);
        }

        private void BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 0, BottomLeftLabel);
        }

        private void BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 1, BottomLabel);
        }

        private void BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 2, BottomRightLabel);
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
                        if (VerifyWinner(isOccupiedBy) == 1) OsWinningLabel.Visible = true;
                        if (VerifyWinner(isOccupiedBy) == 2) XsWinningLabel.Visible = true;
                        isgameEnded = true;
                    }
                    else
                    {
                        WhosTurn();

                        if (GameMenuForm.onePlayer)
                        {
                            // Attendre 500 millisecondes
                            await Task.Delay(500);

                            if (!isBotPlays) BotPlays(labels);
                            else isBotPlays = false;
                        }
                    }
                }
            }
        }

        private int VerifyWinner(int[,] isOccupiedBy)
        {
            // Verify straight line vertically
            for (int i = 0; i < 3; i++)
            {
                if ((isOccupiedBy[i, 0] == 1 && isOccupiedBy[i, 1] == 1 && isOccupiedBy[i, 2] == 1) || (isOccupiedBy[i, 0] == 2 && isOccupiedBy[i, 1] == 2 && isOccupiedBy[i, 2] == 2))
                {
                    return isOccupiedBy[i, 0];
                }
            }

            // Verify straight line horizontally
            for (int i = 0; i < 3; i++)
            {
                if ((isOccupiedBy[0, i] == 1 && isOccupiedBy[1, i] == 1 && isOccupiedBy[2, i] == 1) || (isOccupiedBy[0, i] == 2 && isOccupiedBy[1, i] == 2 && isOccupiedBy[2, i] == 2))
                {
                    return isOccupiedBy[0, i];
                }
            }

            // Verify horizontal right line
            if ((isOccupiedBy[0, 0] == 1 && isOccupiedBy[1, 1] == 1 && isOccupiedBy[2, 2] == 1) || (isOccupiedBy[0, 0] == 2 && isOccupiedBy[1, 1] == 2 && isOccupiedBy[2, 2] == 2))
            {
                return isOccupiedBy[0, 0];
            }
            // Verify horizontal left line
            else if ((isOccupiedBy[0, 2] == 1 && isOccupiedBy[1, 1] == 1 && isOccupiedBy[2, 0] == 1) || (isOccupiedBy[0, 2] == 2 && isOccupiedBy[1, 1] == 2 && isOccupiedBy[2, 0] == 2))
            {
                return isOccupiedBy[0, 2];
            }
            return 0;
        }
    }
}