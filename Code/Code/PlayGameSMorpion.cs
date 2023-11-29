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
        private int[,,,] isOccupiedBy = new int[3, 3, 3, 3];
        private int?[,] usedCase = new int?[3, 3];
        private int result;
        private bool circleTurn;
        private bool isgameEnded;
        private bool isBotPlays;
        private Label[,,,] labels;
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

            labels = new Label[,,,] { { { { TopLeft_TopLeftLabel, TopLeft_TopLabel, TopLeft_TopRightLabel }, { TopLeft_LeftLabel, TopLeft_MiddleLabel, TopLeft_RightLabel }, { TopLeft_BottomLeftLabel, TopLeft_BottomLabel, TopLeft_BottomRightLabel } },
                                     { { Top_TopLeftLabel,  Top_TopLabel, Top_TopRightLabel }, { Top_LeftLabel, Top_MiddleLabel, Top_RightLabel }, {Top_BottomLeftLabel, Top_BottomLabel, Top_BottomRightLabel } },
                                     { { TopRight_TopLeftLabel,  TopRight_TopLabel, TopRight_TopRightLabel }, { TopRight_LeftLabel, TopRight_MiddleLabel, TopRight_RightLabel }, {TopRight_BottomLeftLabel, TopRight_BottomLabel, TopRight_BottomRightLabel } } },
                                     { { { Left_TopLeftLabel,  Left_TopLabel, Left_TopRightLabel }, { Left_LeftLabel, Left_MiddleLabel, Left_RightLabel }, { Left_BottomLeftLabel, Left_BottomLabel, Left_BottomRightLabel } },
                                     { { Middle_TopLeftLabel,  Middle_TopLabel, Middle_TopRightLabel }, { Middle_LeftLabel, Middle_MiddleLabel, Middle_RightLabel }, { Middle_BottomLeftLabel, Middle_BottomLabel, Middle_BottomRightLabel } },
                                     { { Right_TopLeftLabel,  Right_TopLabel, Right_TopRightLabel }, { Right_LeftLabel, Right_MiddleLabel, Right_RightLabel }, { Right_BottomLeftLabel, Right_BottomLabel, Right_BottomRightLabel } } },
                                     { { { BottomLeft_TopLeftLabel,  BottomLeft_TopLabel, BottomLeft_TopRightLabel }, { BottomLeft_LeftLabel, BottomLeft_MiddleLabel, BottomLeft_RightLabel }, { BottomLeft_BottomLeftLabel, BottomLeft_BottomLabel, BottomLeft_BottomRightLabel } },
                                     { { Bottom_TopLeftLabel,  Bottom_TopLabel, Bottom_TopRightLabel }, { Bottom_LeftLabel, Bottom_MiddleLabel, Bottom_RightLabel }, { Bottom_BottomLeftLabel, Bottom_BottomLabel, Bottom_BottomRightLabel } },
                                     { { BottomRight_TopLeftLabel,  BottomRight_TopLabel, BottomRight_TopRightLabel }, { BottomRight_LeftLabel, BottomRight_MiddleLabel, BottomRight_RightLabel }, { BottomRight_BottomLeftLabel, BottomRight_BottomLabel, BottomRight_BottomRightLabel } } } };

            caches = new Label[,] { { Hider_TopLeftLabel, Hider_TopLabel, Hider_TopRightLabel },
                                      { Hider_LeftLabel, Hider_MiddleLabel, Hider_RightLabel },
                                      { Hider_BottomLeftLabel, Hider_BottomLabel, Hider_BottomRightLabel } };

            int zeroOrOne = random.Next(0, 2);

            circleTurn = (zeroOrOne == 0) ? true : false;

            WhosTurn();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            isOccupiedBy[i, j, k, l] = 0;
                            BackCaseColor(i, j, k, l);
                        }
                    }
                }
            }

            if (GameMenuForm.onePlayer && !circleTurn)
            {
                BotPlays(labels);
            }
        }

        private void BotPlays(Label[,,,] labels)
        {
            int rdmCaseColumn, rdmCaseRow, rdmColumn, rdmRow;

            isBotPlays = true;

            do
            {
                rdmCaseColumn = random.Next(0, 3);
                rdmCaseRow = random.Next(0, 3);
                rdmColumn = random.Next(0, 3);
                rdmRow = random.Next(0, 3);
            } while (isOccupiedBy[rdmCaseColumn, rdmCaseRow, rdmColumn, rdmRow] != 0 || !labels[rdmCaseColumn, rdmCaseRow, rdmColumn, rdmRow].Enabled); // || !labels[rdmColumn, rdmRow, 0 , 0].Enabled);

            PlaceSymbol(rdmCaseColumn, rdmCaseRow, rdmColumn, rdmRow, caches[rdmCaseColumn, rdmCaseRow], labels[rdmCaseColumn, rdmCaseRow, rdmColumn, rdmRow]);
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
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            if (labels[i, j, k, l] == sender)
                            {
                                PlaceSymbol(i, j, k, l, caches[i, j], (Label)sender);
                            }
                        }
                    }
                }
            }
        }
        private async void PlaceSymbol(int idLabelCaseColumn, int idLabelCaseRow, int idLabelColumn, int idLabelRow, Label cache, Label label)
        {
            if (!isgameEnded)
            {
                if (isOccupiedBy[idLabelCaseColumn, idLabelCaseRow, idLabelColumn, idLabelRow] == 0)
                {
                    if (!circleTurn)
                    {
                        label.Image = System.Drawing.Image.FromFile(petitCercle);
                        isOccupiedBy[idLabelCaseColumn, idLabelCaseRow, idLabelColumn, idLabelRow] = 1;
                    }
                    else
                    {
                        label.Image = System.Drawing.Image.FromFile(petiteCroix);
                        isOccupiedBy[idLabelCaseColumn, idLabelCaseRow, idLabelColumn, idLabelRow] = 2;
                    }
                    result = VerifyWinnerCase(isOccupiedBy);
                    if (result != 0)
                    {
                        cache.Visible = true;
                        if (result == 1)
                        {
                            cache.Image = System.Drawing.Image.FromFile(grandCercle);

                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    isOccupiedBy[idLabelCaseColumn, idLabelCaseRow, i, j] = 3;
                                    labels[idLabelCaseColumn, idLabelCaseRow, i, j].Enabled = false;
                                }
                            }
                        }
                        else if (result == 2)
                        {
                            cache.Image = System.Drawing.Image.FromFile(grandeCroix);

                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    isOccupiedBy[idLabelCaseColumn, idLabelCaseRow, i, j] = 4;
                                    labels[idLabelCaseColumn, idLabelCaseRow, i, j].Enabled = false;
                                }
                            }
                        }
                    }

                    if (verifyWinner(isOccupiedBy) != 0)
                    {
                        if (verifyWinner(isOccupiedBy) == 3) OsWinningLabel.Visible = true;
                        if (verifyWinner(isOccupiedBy) == 4) XsWinningLabel.Visible = true;

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                for (int k = 0; k < 3; k++)
                                {
                                    for (int l = 0; l < 3; l++)
                                    {
                                        labels[i, j, k, l].Enabled = false;
                                    }
                                }
                            }
                        }
                        isgameEnded = true;
                    }
                    else
                    {
                        WhosTurn();

                        if (isOccupiedBy[idLabelColumn, idLabelRow, 1, 1] != 3 && isOccupiedBy[idLabelColumn, idLabelRow, 1, 1] != 4)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    for (int k = 0; k < 3; k++)
                                    {
                                        for (int l = 0; l < 3; l++)
                                        {
                                            labels[i, j, k, l].Enabled = false;
                                            labels[i, j, k, l].BackColor = ColorTranslator.FromHtml("#F0F0F0");
                                        }
                                    }
                                }
                            }


                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    labels[idLabelColumn, idLabelRow, i, j].Enabled = true;
                                    BackCaseColor(idLabelColumn, idLabelRow, i, j);
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    for (int k = 0; k < 3; k++)
                                    {
                                        for (int l = 0; l < 3; l++)
                                        {
                                            if (isOccupiedBy[i, j, k, l] != 3 && isOccupiedBy[i, j, k, l] != 4)
                                            {
                                                labels[i, j, k, l].Enabled = true;
                                                BackCaseColor(i, j, k, l);
                                            }

                                        }
                                    }
                                }
                            }
                        }


                        if (GameMenuForm.onePlayer)
                        {
                            // Attendre 100 millisecondes
                            await Task.Delay(100);

                            if (!isBotPlays) BotPlays(labels);
                            else isBotPlays = false;
                        }
                    }
                }
            }
        }
        private void BackCaseColor(int i, int j, int k, int l)
        {
            if (circleTurn)
            {
                labels[i, j, k, l].BackColor = ColorTranslator.FromHtml("#DDDDFF");
            }
            else
            {
                labels[i, j, k, l].BackColor = ColorTranslator.FromHtml("#FFDDDD");
            }
        }
        private int VerifyWinnerCase(int[,,,] isOccupiedBy)
        {
            for (int c = 0; c < 3; c++)
            {
                for (int r = 0; r < 3; r++)
                {
                    if (usedCase[c, r] == null)
                    {
                        // Verify straight line vertically
                        for (int i = 0; i < 3; i++)
                        {
                            if ((isOccupiedBy[c, r, i, 0] == 1 && isOccupiedBy[c, r, i, 1] == 1 && isOccupiedBy[c, r, i, 2] == 1) || (isOccupiedBy[c, r, i, 0] == 2 && isOccupiedBy[c, r, i, 1] == 2 && isOccupiedBy[c, r, i, 2] == 2))
                            {
                                usedCase[c, r] = 1;
                                return isOccupiedBy[c, r, i, 0];
                            }
                        }

                        // Verify straight line horizontally
                        for (int i = 0; i < 3; i++)
                        {
                            if ((isOccupiedBy[c, r, 0, i] == 1 && isOccupiedBy[c, r, 1, i] == 1 && isOccupiedBy[c, r, 2, i] == 1) || (isOccupiedBy[c, r, 0, i] == 2 && isOccupiedBy[c, r, 1, i] == 2 && isOccupiedBy[c, r, 2, i] == 2))
                            {
                                usedCase[c, r] = 1;
                                return isOccupiedBy[c, r, 0, i];
                            }
                        }

                        // Verify horizontal right line
                        if ((isOccupiedBy[c, r, 0, 0] == 1 && isOccupiedBy[c, r, 1, 1] == 1 && isOccupiedBy[c, r, 2, 2] == 1) || (isOccupiedBy[c, r, 0, 0] == 2 && isOccupiedBy[c, r, 1, 1] == 2 && isOccupiedBy[c, r, 2, 2] == 2))
                        {
                            usedCase[c, r] = 1;
                            return isOccupiedBy[c, r, 0, 0];
                        }
                        // Verify horizontal left line
                        else if ((isOccupiedBy[c, r, 0, 2] == 1 && isOccupiedBy[c, r, 1, 1] == 1 && isOccupiedBy[c, r, 2, 0] == 1) || (isOccupiedBy[c, r, 0, 2] == 2 && isOccupiedBy[c, r, 1, 1] == 2 && isOccupiedBy[c, r, 2, 0] == 2))
                        {
                            usedCase[c, r] = 1;
                            return isOccupiedBy[c, r, 0, 2];
                        }
                    }
                }
            }
            return 0;

        }
        private int verifyWinner(int[,,,] isOccupiedBy)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((isOccupiedBy[i, 0, 1, 1] == 3 && isOccupiedBy[i, 1, 1, 1] == 3 && isOccupiedBy[i, 2, 1, 1] == 3) || (isOccupiedBy[i, 0, 1, 1] == 4 && isOccupiedBy[i, 1, 1, 1] == 4 && isOccupiedBy[i, 2, 1, 1] == 4))
                {
                    return isOccupiedBy[i, 0, 1, 1];
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if ((isOccupiedBy[0, i, 1, 1] == 3 && isOccupiedBy[1, i, 1, 1] == 3 && isOccupiedBy[2, i, 1, 1] == 3) || (isOccupiedBy[0, i, 1, 1] == 4 && isOccupiedBy[1, i, 1, 1] == 4 && isOccupiedBy[2, i, 1, 1] == 4))
                {
                    return isOccupiedBy[0, i, 1, 1];
                }
            }

            // Verify horizontal right line
            if ((isOccupiedBy[0, 0, 1, 1] == 3 && isOccupiedBy[1, 1, 1, 1] == 3 && isOccupiedBy[2, 2, 2, 2] == 3) || (isOccupiedBy[0, 0, 1, 1] == 4 && isOccupiedBy[1, 1, 1, 1] == 4 && isOccupiedBy[2, 2, 2, 2] == 4))
            {
                return isOccupiedBy[0, 0, 1, 1];
            }
            // Verify horizontal left line
            else if ((isOccupiedBy[0, 2, 1, 1] == 3 && isOccupiedBy[1, 1, 1, 1] == 3 && isOccupiedBy[2, 0, 1, 1] == 3) || (isOccupiedBy[0, 2, 1, 1] == 4 && isOccupiedBy[1, 1, 1, 1] == 4 && isOccupiedBy[2, 0, 1, 1] == 4))
            {
                return isOccupiedBy[0, 2, 1, 1];
            }
            return 0;
        }
    }
}