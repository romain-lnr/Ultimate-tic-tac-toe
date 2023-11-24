using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code
{
    public partial class PlayGameSMorpionForm : Form
    {
        private string grandCercle = "..\\..\\..\\Images\\GrandCercle.png";
        private string grandeCroix = "..\\..\\..\\Images\\GrandeCroix.png";
        private string petitCercle = "..\\..\\..\\Images\\PetitCercle.png";
        private string petiteCroix = "..\\..\\..\\Images\\PetiteCroix.png";
        private int[,,] isOccupiedBy = new int[9, 3, 3];
        private int?[] usedCase = new int?[9];
        private int result;
        private bool circleTurn;
        private bool isgameEnded;
        private bool isBotPlays;
        private Label[,,] labels;
        private Label[,] caches;
        Random random = new Random((int)DateTime.Now.Ticks);

        private void WhosTurn()
        {
            if (circleTurn)
            {
                OsTurnLabel.Enabled = true;
                XsTurnLabel.Enabled = false;
                circleTurn = false;
            }
            else
            {
                XsTurnLabel.Enabled = true;
                OsTurnLabel.Enabled = false;
                circleTurn = true;
            }
        }
        public PlayGameSMorpionForm()
        {
            InitializeComponent();

            isgameEnded = false;

            labels = new Label[,,] { { { TopLeft_TopLeftLabel, TopLeft_TopLabel, TopLeft_TopRightLabel }, { TopLeft_LeftLabel, TopLeft_MiddleLabel, TopLeft_RightLabel }, { TopLeft_BottomLeftLabel, TopLeft_BottomLabel, TopLeft_BottomRightLabel } },
                                     { { Top_TopLeftLabel,  Top_TopLabel, Top_TopRightLabel }, { Top_LeftLabel, Top_MiddleLabel, Top_RightLabel }, {Top_BottomLeftLabel, Top_BottomLabel, Top_BottomRightLabel } },
                                     { { TopRight_TopLeftLabel,  TopRight_TopLabel, TopRight_TopRightLabel }, { TopRight_LeftLabel, TopRight_MiddleLabel, TopRight_RightLabel }, {TopRight_BottomLeftLabel, TopRight_BottomLabel, TopRight_BottomRightLabel } },
                                     { { Left_TopLeftLabel,  Left_TopLabel, Left_TopRightLabel }, { Left_LeftLabel, Left_MiddleLabel, Left_RightLabel }, { Left_BottomLeftLabel, Left_BottomLabel, Left_BottomRightLabel } },
                                     { { Middle_TopLeftLabel,  Middle_TopLabel, Middle_TopRightLabel }, { Middle_LeftLabel, Middle_MiddleLabel, Middle_RightLabel }, { Middle_BottomLeftLabel, Middle_BottomLabel, Middle_BottomRightLabel } },
                                     { { Right_TopLeftLabel,  Right_TopLabel, Right_TopRightLabel }, { Right_LeftLabel, Right_MiddleLabel, Right_RightLabel }, { Right_BottomLeftLabel, Right_BottomLabel, Right_BottomRightLabel } },
                                     { { BottomLeft_TopLeftLabel,  BottomLeft_TopLabel, BottomLeft_TopRightLabel }, { BottomLeft_LeftLabel, BottomLeft_MiddleLabel, BottomLeft_RightLabel }, { BottomLeft_BottomLeftLabel, BottomLeft_BottomLabel, BottomLeft_BottomRightLabel } },
                                     { { Bottom_TopLeftLabel,  Bottom_TopLabel, Bottom_TopRightLabel }, { Bottom_LeftLabel, Bottom_MiddleLabel, Bottom_RightLabel }, { Bottom_BottomLeftLabel, Bottom_BottomLabel, Bottom_BottomRightLabel } },
                                     { { BottomRight_TopLeftLabel,  BottomRight_TopLabel, BottomRight_TopRightLabel }, { BottomRight_LeftLabel, BottomRight_MiddleLabel, BottomRight_RightLabel }, { BottomRight_BottomLeftLabel, BottomRight_BottomLabel, BottomRight_BottomRightLabel } } };

            caches = new Label[,] { { Cache_TopLeftLabel, Cache_TopLabel, Cache_TopRightLabel },
                                      { Cache_LeftLabel, Cache_MiddleLabel, Cache_RightLabel },
                                      { Cache_BottomLeftLabel, Cache_BottomLabel, Cache_BottomRightLabel } };

            int zeroOrOne = random.Next(0, 2);

            circleTurn = (zeroOrOne == 0) ? true : false;

            WhosTurn();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        isOccupiedBy[i, j, k] = 0;
                    }
                }
            }

            if (GameMenuForm.onePlayer && !circleTurn)
            {
                BotPlays(labels);
            }
        }

        private void BotPlays(Label[,,] labels)
        {
            int rdmCase, rdmColumn, rdmRow;

            isBotPlays = true;

            do
            {
                rdmCase = random.Next(0, 9);
                rdmColumn = random.Next(0, 3);
                rdmRow = random.Next(0, 3);
            } while (isOccupiedBy[rdmCase, rdmColumn, rdmRow] != 0);

            PlaceSymbol(rdmCase, rdmColumn, rdmRow, caches[rdmColumn, rdmRow], labels[rdmCase, rdmColumn, rdmRow]);
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

        private void TopLeft_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 0, 0, Cache_TopLeftLabel, TopLeft_TopLeftLabel);
        }

        private void TopLeft_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 0, 1, Cache_TopLeftLabel, TopLeft_TopLabel);
        }

        private void TopLeft_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 0, 2, Cache_TopLeftLabel, TopLeft_TopRightLabel);
        }

        private void TopLeft_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 1, 0, Cache_TopLeftLabel, TopLeft_LeftLabel);
        }

        private void TopLeft_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 1, 1, Cache_TopLeftLabel, TopLeft_MiddleLabel);
        }

        private void TopLeft_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 1, 2, Cache_TopLeftLabel, TopLeft_RightLabel);
        }

        private void TopLeft_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 2, 0, Cache_TopLeftLabel, TopLeft_BottomLeftLabel);
        }

        private void TopLeft_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 2, 1, Cache_TopLeftLabel, TopLeft_BottomLabel);
        }

        private void TopLeft_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 2, 2, Cache_TopLeftLabel, TopLeft_BottomRightLabel);
        }

        private void Top_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 0, 0, Cache_TopLabel, Top_TopLeftLabel);
        }

        private void Top_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 0, 1, Cache_TopLabel, Top_TopLabel);
        }

        private void Top_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 0, 2, Cache_TopLabel, Top_TopRightLabel);
        }

        private void Top_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 1, 0, Cache_TopLabel, Top_LeftLabel);
        }

        private void Top_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 1, 1, Cache_TopLabel, Top_MiddleLabel);
        }

        private void Top_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 1, 2, Cache_TopLabel, Top_RightLabel);
        }

        private void Top_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 2, 0, Cache_TopLabel, Top_BottomLeftLabel);
        }

        private void Top_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 2, 1, Cache_TopLabel, Top_BottomLabel);
        }

        private void Top_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 2, 2, Cache_TopLabel, Top_BottomRightLabel);
        }

        private void TopRight_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 0, 0, Cache_TopRightLabel, TopRight_TopLeftLabel);
        }

        private void TopRight_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 0, 1, Cache_TopRightLabel, TopRight_TopLabel);
        }

        private void TopRight_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 0, 2, Cache_TopRightLabel, TopRight_TopRightLabel);
        }

        private void TopRight_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 1, 0, Cache_TopRightLabel, TopRight_LeftLabel);
        }

        private void TopRight_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 1, 1, Cache_TopRightLabel, TopRight_MiddleLabel);
        }

        private void TopRight_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 1, 2, Cache_TopRightLabel, TopRight_RightLabel);
        }

        private void TopRight_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 2, 0, Cache_TopRightLabel, TopRight_BottomLeftLabel);
        }

        private void TopRight_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 2, 1, Cache_TopRightLabel, TopRight_BottomLabel);
        }

        private void TopRight_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 2, 2, Cache_TopRightLabel, TopRight_BottomRightLabel);
        }

        private void Left_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 0, 0, Cache_LeftLabel, Left_TopLeftLabel);
        }

        private void Left_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 0, 1, Cache_LeftLabel, Left_TopLabel);
        }

        private void Left_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 0, 2, Cache_LeftLabel, Left_TopRightLabel);
        }

        private void Left_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 1, 0, Cache_LeftLabel, Left_LeftLabel);
        }

        private void Left_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 1, 1, Cache_LeftLabel, Left_MiddleLabel);
        }

        private void Left_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 1, 2, Cache_LeftLabel, Left_RightLabel);
        }

        private void Left_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 2, 0, Cache_LeftLabel, Left_BottomLeftLabel);
        }

        private void Left_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 2, 1, Cache_LeftLabel, Left_BottomLabel);
        }

        private void Left_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 2, 2, Cache_LeftLabel, Left_BottomRightLabel);
        }

        private void Middle_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 0, 0, Cache_MiddleLabel, Middle_TopLeftLabel);
        }

        private void Middle_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 0, 1, Cache_MiddleLabel, Middle_TopLabel);
        }

        private void Middle_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 0, 2, Cache_MiddleLabel, Middle_TopRightLabel);
        }

        private void Middle_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 1, 0, Cache_MiddleLabel, Middle_LeftLabel);
        }

        private void Middle_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 1, 1, Cache_MiddleLabel, Middle_MiddleLabel);
        }

        private void Middle_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 1, 2, Cache_MiddleLabel, Middle_RightLabel);
        }

        private void Middle_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 2, 0, Cache_MiddleLabel, Middle_BottomLeftLabel);
        }

        private void Middle_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 2, 1, Cache_MiddleLabel, Middle_BottomLabel);
        }

        private void Middle_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 2, 2, Cache_MiddleLabel, Middle_BottomRightLabel);
        }

        private void Right_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 0, 0, Cache_RightLabel, Right_TopLeftLabel);
        }

        private void Right_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 0, 1, Cache_RightLabel, Right_TopLabel);
        }

        private void Right_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 0, 2, Cache_RightLabel, Right_TopRightLabel);
        }

        private void Right_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 1, 0, Cache_RightLabel, Right_LeftLabel);
        }

        private void Right_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 1, 1, Cache_RightLabel, Right_MiddleLabel);
        }

        private void Right_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 1, 2, Cache_RightLabel, Right_RightLabel);
        }

        private void Right_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 2, 0, Cache_RightLabel, Right_BottomLeftLabel);
        }

        private void Right_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 2, 1, Cache_RightLabel, Right_BottomLabel);
        }

        private void Right_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 2, 2, Cache_RightLabel, Right_BottomRightLabel);
        }

        private void BottomLeft_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 0, 0, Cache_BottomLeftLabel, BottomLeft_TopLeftLabel);
        }

        private void BottomLeft_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 0, 1, Cache_BottomLeftLabel, BottomLeft_TopLabel);
        }

        private void BottomLeft_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 0, 2, Cache_BottomLeftLabel, BottomLeft_TopRightLabel);
        }

        private void BottomLeft_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 1, 0, Cache_BottomLeftLabel, BottomLeft_LeftLabel);
        }

        private void BottomLeft_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 1, 1, Cache_BottomLeftLabel, BottomLeft_MiddleLabel);
        }

        private void BottomLeft_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 1, 2, Cache_BottomLeftLabel, BottomLeft_RightLabel);
        }

        private void BottomLeft_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 2, 0, Cache_BottomLeftLabel, BottomLeft_BottomLeftLabel);
        }

        private void BottomLeft_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 2, 1, Cache_BottomLeftLabel, BottomLeft_BottomLabel);
        }

        private void BottomLeft_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 2, 2, Cache_BottomLeftLabel, BottomLeft_BottomRightLabel);
        }

        private void Bottom_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 0, 0, Cache_BottomLabel, Bottom_TopLeftLabel);
        }

        private void Bottom_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 0, 1, Cache_BottomLabel, Bottom_TopLabel);
        }

        private void Bottom_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 0, 2, Cache_BottomLabel, Bottom_TopRightLabel);
        }

        private void Bottom_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 1, 0, Cache_BottomLabel, Bottom_LeftLabel);
        }

        private void Bottom_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 1, 1, Cache_BottomLabel, Bottom_MiddleLabel);
        }

        private void Bottom_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 1, 2, Cache_BottomLabel, Bottom_RightLabel);
        }

        private void Bottom_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 2, 0, Cache_BottomLabel, Bottom_BottomLeftLabel);
        }

        private void Bottom_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 2, 1, Cache_BottomLabel, Bottom_BottomLabel);
        }

        private void Bottom_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 2, 2, Cache_BottomLabel, Bottom_BottomRightLabel);
        }

        private void BottomRight_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 0, 0, Cache_BottomRightLabel, BottomRight_TopLeftLabel);
        }

        private void BottomRight_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 0, 1, Cache_BottomRightLabel, BottomRight_TopLabel);
        }

        private void BottomRight_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 0, 2, Cache_BottomRightLabel, BottomRight_TopRightLabel);
        }

        private void BottomRight_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 1, 0, Cache_BottomRightLabel, BottomRight_LeftLabel);
        }

        private void BottomRight_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 1, 1, Cache_BottomRightLabel, BottomRight_MiddleLabel);
        }

        private void BottomRight_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 1, 2, Cache_BottomRightLabel, BottomRight_RightLabel);
        }

        private void BottomRight_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 2, 0, Cache_BottomRightLabel, BottomRight_BottomLeftLabel);
        }

        private void BottomRight_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 2, 1, Cache_BottomRightLabel, BottomRight_BottomLabel);
        }

        private void BottomRight_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 2, 2, Cache_BottomRightLabel, BottomRight_BottomRightLabel);
        }


        private async void PlaceSymbol(int idLabelCase, int idLabelColumn, int idLabelRow, Label cache, Label label)
        {
            if (!isgameEnded)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            labels[i, j, k].Enabled = false;
                        }
                    }
                }

                if (isOccupiedBy[idLabelCase, idLabelColumn, idLabelRow] == 0)
                {
                    if (!circleTurn)
                    {
                        label.Image = System.Drawing.Image.FromFile(petitCercle);
                        isOccupiedBy[idLabelCase, idLabelColumn, idLabelRow] = 1;
                    }
                    else
                    {
                        label.Image = System.Drawing.Image.FromFile(petiteCroix);
                        isOccupiedBy[idLabelCase, idLabelColumn, idLabelRow] = 2;
                    }
                    result = VerifyWinnerCase(isOccupiedBy);
                    if (result != 0)
                    {
                        cache.Visible = true;
                        if (result == 1)
                        {
                            cache.Image = System.Drawing.Image.FromFile(grandCercle);

                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    isOccupiedBy[idLabelCase, i, j] = 3;
                                }
                            }                            
                        }
                        else if (result == 2)
                        {
                            cache.Image = System.Drawing.Image.FromFile(grandeCroix);

                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    isOccupiedBy[idLabelCase, i, j] = 4;
                                }
                            }
                        }
                    }

                    if (verifyWinner(isOccupiedBy) != 0)
                    {
                        if (verifyWinner(isOccupiedBy) == 3) OsWinningLabel.Visible = true;
                        if (verifyWinner(isOccupiedBy) == 4) XsWinningLabel.Visible = true;
                        isgameEnded = true;
                    }
                    else
                    {
                        WhosTurn();

                        if (GameMenuForm.onePlayer)
                        {
                            // Attendre 1000 millisecondes
                            await Task.Delay(1000);

                            if (!isBotPlays) BotPlays(labels);
                            else isBotPlays = false;
                        }
                    }

                    for (int i = 0; i < 9; i++)
                    {
                        if (i != idLabelCase)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                for (int k = 0; k < 3; k++)
                                {
                                    labels[i, j, k].Enabled = false;
                                }                                
                            }
                        }
                    }
                }
            }
        }

        private int VerifyWinnerCase(int[,,] isOccupiedBy)
        {
            for (int c = 0; c < 9; c++)
            {
                if (usedCase[c] == null)
                {
                    // Verify straight line vertically
                    for (int i = 0; i < 3; i++)
                    {
                        if ((isOccupiedBy[c, i, 0] == 1 && isOccupiedBy[c, i, 1] == 1 && isOccupiedBy[c, i, 2] == 1) || (isOccupiedBy[c, i, 0] == 2 && isOccupiedBy[c, i, 1] == 2 && isOccupiedBy[c, i, 2] == 2))
                        {
                            usedCase[c] = 1;
                            return isOccupiedBy[c, i, 0];
                        }
                    }

                    // Verify straight line horizontally
                    for (int i = 0; i < 3; i++)
                    {
                        if ((isOccupiedBy[c, 0, i] == 1 && isOccupiedBy[c, 1, i] == 1 && isOccupiedBy[c, 2, i] == 1) || (isOccupiedBy[c, 0, i] == 2 && isOccupiedBy[c, 1, i] == 2 && isOccupiedBy[c, 2, i] == 2))
                        {
                            usedCase[c] = 1;
                            return isOccupiedBy[c, 0, i];
                        }
                    }

                    // Verify horizontal right line
                    if ((isOccupiedBy[c, 0, 0] == 1 && isOccupiedBy[c, 1, 1] == 1 && isOccupiedBy[c, 2, 2] == 1) || (isOccupiedBy[c, 0, 0] == 2 && isOccupiedBy[c, 1, 1] == 2 && isOccupiedBy[c, 2, 2] == 2))
                    {
                        usedCase[c] = 1;
                        return isOccupiedBy[c, 0, 0];
                    }
                    // Verify horizontal left line
                    else if ((isOccupiedBy[c, 0, 2] == 1 && isOccupiedBy[c, 1, 1] == 1 && isOccupiedBy[c, 2, 0] == 1) || (isOccupiedBy[c, 0, 2] == 2 && isOccupiedBy[c, 1, 1] == 2 && isOccupiedBy[c, 2, 0] == 2))
                    {
                        usedCase[c] = 1;
                        return isOccupiedBy[c, 0, 2];
                    }
                }
            }
            return 0;
        }

        private int verifyWinner(int[,,] isOccupiedBy)
        {
            for (int c = 0; c < 9; c += 3)
            {
                if ((isOccupiedBy[c, 1, 1] == 3 && isOccupiedBy[c + 1, 1, 1] == 3 && isOccupiedBy[c + 2, 1, 1] == 3) || (isOccupiedBy[c, 1, 1] == 4 && isOccupiedBy[c + 1, 1, 1] == 4 && isOccupiedBy[c + 2, 1, 1] == 4))
                {
                    return isOccupiedBy[c, 1, 1];
                }
            }

            for (int c = 0; c < 3; c++)
            {
                if ((isOccupiedBy[c, 1, 1] == 3 && isOccupiedBy[c + 3, 1, 1] == 3 && isOccupiedBy[c + 6, 1, 1] == 3) || (isOccupiedBy[c, 1, 1] == 4 && isOccupiedBy[c + 3, 1, 1] == 4 && isOccupiedBy[c + 6, 1, 1] == 4))
                {
                    return isOccupiedBy[c, 1, 1];
                }
            }

            // Verify horizontal right line
            if ((isOccupiedBy[0, 1, 1] == 3 && isOccupiedBy[4, 1, 1] == 3 && isOccupiedBy[8, 2, 2] == 3) || (isOccupiedBy[0, 1, 1] == 4 && isOccupiedBy[4, 1, 1] == 4 && isOccupiedBy[8, 2, 2] == 4))
            {
                return isOccupiedBy[0, 1, 1];
            }
            // Verify horizontal left line
            else if ((isOccupiedBy[2, 1, 1] == 3 && isOccupiedBy[4, 1, 1] == 3 && isOccupiedBy[6, 1, 1] == 3) || (isOccupiedBy[2, 1, 1] == 4 && isOccupiedBy[4, 1, 1] == 4 && isOccupiedBy[6, 1, 1] == 4))
            {
                return isOccupiedBy[2, 1, 1];
            }
            return 0;
        }
    }
}