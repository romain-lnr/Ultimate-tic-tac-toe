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

namespace Code
{
    public partial class PlayGameUltimateMorpionForm : Form
    {
        private string grandCercle = "..\\..\\..\\Images\\GrandCercle.png";
        private string grandeCroix = "..\\..\\..\\Images\\GrandeCroix.png";
        private string petitCercle = "..\\..\\..\\Images\\PetitCercle.png";
        private string petiteCroix = "..\\..\\..\\Images\\PetiteCroix.png";
        private string grandTrait = "..\\..\\..\\Images\\GrandTrait.png";
        private int[,,,] isOccupiedBy = new int[3, 3, 3, 3];
        private int?[,] usedCase = new int?[3, 3];
        private int result;
        private bool circleTurn;
        private bool isgameEnded;
        private bool isBotPlays;
        private Label[,,,] labels;
        private Label[,] hiders;
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

        public PlayGameUltimateMorpionForm()
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

            hiders = new Label[,] { { Hider_TopLeftLabel, Hider_TopLabel, Hider_TopRightLabel },
                                      { Hider_LeftLabel, Hider_MiddleLabel, Hider_RightLabel },
                                      { Hider_BottomLeftLabel, Hider_BottomLabel, Hider_BottomRightLabel } };

            int zeroOrOne = random.Next(0, 2);

            circleTurn = (zeroOrOne == 0) ? true : false;

            WhosTurn();

            for (int bigColumn = 0; bigColumn < 3; bigColumn++)
            {
                for (int bigRow = 0; bigRow < 3; bigRow++)
                {
                    for (int smallColumn = 0; smallColumn < 3; smallColumn++)
                    {
                        for (int smallRow = 0; smallRow < 3; smallRow++)
                        {
                            isOccupiedBy[bigColumn, bigRow, smallColumn, smallRow] = 0;
                            BackCaseColor(bigColumn, bigRow, smallColumn, smallRow);
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
            int[] countCircle = new int[2] { 0, 0 }, countCross = new int[2] { 0, 0 };
            isBotPlays = true;
            for (int bigColumn = 0; bigColumn < 3; bigColumn++)
            {
                for (int bigRow = 0; bigRow < 3; bigRow++)
                {
                    if (labels[bigColumn, bigRow, 1, 1].Enabled)
                    {
                        for (int smallcolumn = 0; smallcolumn < 3; smallcolumn++)
                        {
                            // Check both rows and columns in a single loop
                            for (int i = 0; i < 2; i++)
                            {
                                for (int smallrow = 0; smallrow < 3; smallrow++)
                                {
                                    int value = (i == 0) ? isOccupiedBy[bigColumn, bigRow, smallcolumn, smallrow] : isOccupiedBy[bigColumn, bigRow, smallrow, smallcolumn];

                                    if (value == 1) countCircle[i]++;
                                    else if (value == 2) countCross[i]++;
                                }

                                if (countCircle[i] == 2 || countCross[i] == 2)
                                {
                                    for (int rerow = 0; rerow < 3; rerow++)
                                    {
                                        int currentColumn = (i == 0) ? smallcolumn : rerow;
                                        int currentRow = (i == 0) ? rerow : smallcolumn;

                                        if (isOccupiedBy[bigColumn, bigRow, currentColumn, currentRow] == 0)
                                        {
                                            PlaceSymbol(bigColumn, bigRow, currentColumn, currentRow, hiders[bigColumn, bigRow], labels[bigColumn, bigRow, currentColumn, currentRow]);
                                            return;
                                        }
                                    }
                                }
                                countCircle[i] = countCross[i] = 0;
                            }

                            // Check both diagonals in a single loop
                            for (int i = 0; i < 2; i++)
                            {
                                for (int smallrow = 0; smallrow < 3; smallrow++)
                                {
                                    int value = (i == 0) ? isOccupiedBy[bigColumn, bigRow, smallrow, smallrow] : isOccupiedBy[bigColumn, bigRow, smallrow, 2 - smallrow]; // 0;0 1;1 2;2 - 0;2 1;1 2;0

                                    if (value == 1) countCircle[i]++;
                                    else if (value == 2) countCross[i]++;
                                }

                                if (countCircle[i] == 2 || countCross[i] == 2)
                                {
                                    for (int rerow = 0; rerow < 3; rerow++)
                                    {
                                        int currentColumn = (i == 0) ? rerow : 2 - rerow;
                                        int currentRow = (i == 0) ? rerow : rerow;

                                        if (isOccupiedBy[bigColumn, bigRow, currentColumn, currentRow] == 0)
                                        {
                                            PlaceSymbol(bigColumn, bigRow, currentColumn, currentRow, hiders[bigColumn, bigRow], labels[bigColumn, bigRow, currentColumn, currentRow]);
                                            return;
                                        }
                                    }
                                }
                                countCircle[i] = countCross[i] = 0;
                            }
                        }
                    }
                }
            }

            do
            {
                rdmCaseColumn = random.Next(0, 3);
                rdmCaseRow = random.Next(0, 3);
                rdmColumn = random.Next(0, 3);
                rdmRow = random.Next(0, 3);
            } while (isOccupiedBy[rdmCaseColumn, rdmCaseRow, rdmColumn, rdmRow] != 0 || !labels[rdmCaseColumn, rdmCaseRow, rdmColumn, rdmRow].Enabled); // || !labels[rdmColumn, rdmRow, 0 , 0].Enabled);

            PlaceSymbol(rdmCaseColumn, rdmCaseRow, rdmColumn, rdmRow, hiders[rdmCaseColumn, rdmCaseRow], labels[rdmCaseColumn, rdmCaseRow, rdmColumn, rdmRow]);
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
            for (int bigColumn = 0; bigColumn < 3; bigColumn++)
            {
                for (int bigRow = 0; bigRow < 3; bigRow++)
                {
                    for (int smallColumn = 0; smallColumn < 3; smallColumn++)
                    {
                        for (int smallRow = 0; smallRow < 3; smallRow++)
                        {
                            if (labels[bigColumn, bigRow, smallColumn, smallRow] == sender)
                            {
                                if (GameMenuForm.onePlayer)
                                {
                                    if (circleTurn) PlaceSymbol(bigColumn, bigRow, smallColumn, smallRow, hiders[bigColumn, bigRow], (Label)sender);
                                }
                                else PlaceSymbol(bigColumn, bigRow, smallColumn, smallRow, hiders[bigColumn, bigRow], (Label)sender);
                            }
                        }
                    }
                }
            }
        }
        private async void PlaceSymbol(int idLabelCaseColumn, int idLabelCaseRow, int idLabelColumn, int idLabelRow, Label hiders, Label label)
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
                        hiders.Visible = true;
                        if (result == 1)
                        {
                            hiders.Image = System.Drawing.Image.FromFile(grandCercle);

                            for (int smallColumn = 0; smallColumn < 3; smallColumn++)
                            {
                                for (int smallRow = 0; smallRow < 3; smallRow++)
                                {
                                    isOccupiedBy[idLabelCaseColumn, idLabelCaseRow, smallColumn, smallRow] = 3;
                                    labels[idLabelCaseColumn, idLabelCaseRow, smallColumn, smallRow].Enabled = false;
                                }
                            }
                        }
                        else if (result == 2)
                        {
                            hiders.Image = System.Drawing.Image.FromFile(grandeCroix);

                            for (int smallColumn = 0; smallColumn < 3; smallColumn++)
                            {
                                for (int smallRow = 0; smallRow < 3; smallRow++)
                                {
                                    isOccupiedBy[idLabelCaseColumn, idLabelCaseRow, smallColumn, smallRow] = 4;
                                    labels[idLabelCaseColumn, idLabelCaseRow, smallColumn, smallRow].Enabled = false;
                                }
                            }
                        }
                        else if (result == 3)
                        {
                            hiders.Image = System.Drawing.Image.FromFile(grandTrait);

                            for (int smallColumn = 0; smallColumn < 3; smallColumn++)
                            {
                                for (int smallRow = 0; smallRow < 3; smallRow++)
                                {
                                    isOccupiedBy[idLabelCaseColumn, idLabelCaseRow, smallColumn, smallRow] = 5;
                                    labels[idLabelCaseColumn, idLabelCaseRow, smallColumn, smallRow].Enabled = false;
                                }
                            }
                        }
                    }

                    if (verifyWinner(isOccupiedBy) != 0)
                    {
                        if (verifyWinner(isOccupiedBy) == 3)
                        {
                            ResultLabel.Text = "O won !";
                            ResultLabel.ForeColor = Color.Red;
                        }

                        if (verifyWinner(isOccupiedBy) == 4)
                        {
                            ResultLabel.Text = "X won !";
                            ResultLabel.ForeColor = Color.Blue;
                        }

                        if (verifyWinner(isOccupiedBy) == 5)
                        {
                            ResultLabel.Text = "It's a tie...";
                            ResultLabel.ForeColor = Color.Black;
                        }

                        XsTurnLabel.Visible = false;
                        OsTurnLabel.Visible = false;

                        for (int bigColumn = 0; bigColumn < 3; bigColumn++)
                        {
                            for (int bigRow = 0; bigRow < 3; bigRow++)
                            {
                                for (int smallColumn = 0; smallColumn < 3; smallColumn++)
                                {
                                    for (int smallRow = 0; smallRow < 3; smallRow++)
                                    {
                                        labels[bigColumn, bigRow, smallColumn, smallRow].Enabled = false;
                                        labels[bigColumn, bigRow, smallColumn, smallRow].BackColor = ColorTranslator.FromHtml("#F0F0F0");
                                    }
                                }
                            }
                        }
                        isgameEnded = true;
                    }
                    else
                    {
                        WhosTurn();

                        if (isOccupiedBy[idLabelColumn, idLabelRow, 1, 1] != 3 && isOccupiedBy[idLabelColumn, idLabelRow, 1, 1] != 4 && isOccupiedBy[idLabelColumn, idLabelRow, 1, 1] != 5)
                        {
                            for (int bigColumn = 0; bigColumn < 3; bigColumn++)
                            {
                                for (int bigRow = 0; bigRow < 3; bigRow++)
                                {
                                    for (int smallColumn = 0; smallColumn < 3; smallColumn++)
                                    {
                                        for (int smallRow = 0; smallRow < 3; smallRow++)
                                        {
                                            labels[bigColumn, bigRow, smallColumn, smallRow].Enabled = false;
                                            labels[bigColumn, bigRow, smallColumn, smallRow].BackColor = ColorTranslator.FromHtml("#F0F0F0");
                                        }
                                    }
                                }
                            }


                            for (int smallColumn = 0; smallColumn < 3; smallColumn++)
                            {
                                for (int smallRow = 0; smallRow < 3; smallRow++)
                                {
                                    labels[idLabelColumn, idLabelRow, smallColumn, smallRow].Enabled = true;
                                    BackCaseColor(idLabelColumn, idLabelRow, smallColumn, smallRow);
                                }
                            }
                        }
                        else
                        {
                            for (int bigColumn = 0; bigColumn < 3; bigColumn++)
                            {
                                for (int bigRow = 0; bigRow < 3; bigRow++)
                                {
                                    for (int smallColumn = 0; smallColumn < 3; smallColumn++)
                                    {
                                        for (int smallRow = 0; smallRow < 3; smallRow++)
                                        {
                                            if (isOccupiedBy[bigColumn, bigRow, smallColumn, smallRow] != 3 && isOccupiedBy[bigColumn, bigRow, smallColumn, smallRow] != 4)
                                            {
                                                labels[bigColumn, bigRow, smallColumn, smallRow].Enabled = true;
                                                BackCaseColor(bigColumn, bigRow, smallColumn, smallRow);
                                            }

                                        }
                                    }
                                }
                            }
                        }


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
        private void BackCaseColor(int bigColumn, int bigRow, int smallColumn, int smallRow)
        {
            if (circleTurn)
            {
                labels[bigColumn, bigRow, smallColumn, smallRow].BackColor = ColorTranslator.FromHtml("#DDDDFF");
            }
            else
            {
                labels[bigColumn, bigRow, smallColumn, smallRow].BackColor = ColorTranslator.FromHtml("#FFDDDD");
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
                        for (int smallColumn = 0; smallColumn < 3; smallColumn++)
                        {
                            if ((isOccupiedBy[c, r, smallColumn, 0] == 1 && isOccupiedBy[c, r, smallColumn, 1] == 1 && isOccupiedBy[c, r, smallColumn, 2] == 1) || (isOccupiedBy[c, r, smallColumn, 0] == 2 && isOccupiedBy[c, r, smallColumn, 1] == 2 && isOccupiedBy[c, r, smallColumn, 2] == 2))
                            {
                                usedCase[c, r] = 1;
                                return isOccupiedBy[c, r, smallColumn, 0];
                            }
                        }

                        // Verify straight line horizontally
                        for (int smallRow = 0; smallRow < 3; smallRow++)
                        {
                            if ((isOccupiedBy[c, r, 0, smallRow] == 1 && isOccupiedBy[c, r, 1, smallRow] == 1 && isOccupiedBy[c, r, 2, smallRow] == 1) || (isOccupiedBy[c, r, 0, smallRow] == 2 && isOccupiedBy[c, r, 1, smallRow] == 2 && isOccupiedBy[c, r, 2, smallRow] == 2))
                            {
                                usedCase[c, r] = 1;
                                return isOccupiedBy[c, r, 0, smallRow];
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
                        // Verify Tie Case
                        int num = 0;
                        for (int column = 0; column < 3; column++)
                        {
                            for (int row = 0; row < 3; row++)
                            {
                                if (isOccupiedBy[c, r, column, row] != 0) num++;
                            }
                        }
                        if (num == 9)
                        {
                            usedCase[c, r] = 1;
                            return 3;
                        }
                    }
                }
            }
            return 0;

        }
        private int verifyWinner(int[,,,] isOccupiedBy)
        {
            for (int bigColumn = 0; bigColumn < 3; bigColumn++)
            {
                if ((isOccupiedBy[bigColumn, 0, 1, 1] == 3 && isOccupiedBy[bigColumn, 1, 1, 1] == 3 && isOccupiedBy[bigColumn, 2, 1, 1] == 3) || (isOccupiedBy[bigColumn, 0, 1, 1] == 4 && isOccupiedBy[bigColumn, 1, 1, 1] == 4 && isOccupiedBy[bigColumn, 2, 1, 1] == 4))
                {
                    return isOccupiedBy[bigColumn, 0, 1, 1];
                }
            }

            for (int bigRow = 0; bigRow < 3; bigRow++)
            {
                if ((isOccupiedBy[0, bigRow, 1, 1] == 3 && isOccupiedBy[1, bigRow, 1, 1] == 3 && isOccupiedBy[2, bigRow, 1, 1] == 3) || (isOccupiedBy[0, bigRow, 1, 1] == 4 && isOccupiedBy[1, bigRow, 1, 1] == 4 && isOccupiedBy[2, bigRow, 1, 1] == 4))
                {
                    return isOccupiedBy[0, bigRow, 1, 1];
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
            // Verify tie
            int num = 0;
            for (int bigColumn = 0; bigColumn < 3; bigColumn++)
            {
                for (int bigRow = 0; bigRow < 3; bigRow++)
                {
                    for (int smallColumn = 0; smallColumn < 3; smallColumn++)
                    {
                        for (int smallRow = 0; smallRow < 3; smallRow++)
                        {
                            if (isOccupiedBy[bigColumn, bigRow, smallColumn, smallRow] != 0) num++;

                        }
                    }
                }
            }
            if (num == 81) return 5;
            return 0;
        }
    }
}