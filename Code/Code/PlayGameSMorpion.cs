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
        private bool circleTurn;
        private bool isgameEnded;
        private bool isBotPlays;
        private Label[,,] labels;
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
                                     //
                                     { { Top_TopLeftLabel,  Top_TopLeftLabel, Top_TopLeftLabel }, { Top_TopLeftLabel, Top_TopLeftLabel, Top_TopLeftLabel }, {Top_TopLeftLabel, Top_TopLeftLabel, Top_TopLeftLabel } },
                                     { { Top_TopLeftLabel,  Top_TopLeftLabel, Top_TopLeftLabel }, { Top_TopLeftLabel, Top_TopLeftLabel, Top_TopLeftLabel }, {Top_TopLeftLabel, Top_TopLeftLabel, Top_TopLeftLabel } },
                                     { { Top_TopLeftLabel,  Top_TopLeftLabel, Top_TopLeftLabel }, { Top_TopLeftLabel, Top_TopLeftLabel, Top_TopLeftLabel }, {Top_TopLeftLabel, Top_TopLeftLabel, Top_TopLeftLabel } },
                                     { { Top_TopLeftLabel,  Top_TopLeftLabel, Top_TopLeftLabel }, { Top_TopLeftLabel, Top_TopLeftLabel, Top_TopLeftLabel }, {Top_TopLeftLabel, Top_TopLeftLabel, Top_TopLeftLabel } },
                                     { { Top_TopLeftLabel,  Top_TopLeftLabel, Top_TopLeftLabel }, { Top_TopLeftLabel, Top_TopLeftLabel, Top_TopLeftLabel }, {Top_TopLeftLabel, Top_TopLeftLabel, Top_TopLeftLabel } },
                                     { { Top_TopLeftLabel,  Top_TopLeftLabel, Top_TopLeftLabel }, { Top_TopLeftLabel, Top_TopLeftLabel, Top_TopLeftLabel }, {Top_TopLeftLabel, Top_TopLeftLabel, Top_TopLeftLabel } },
                                     { { Top_TopLeftLabel,  Top_TopLeftLabel, Top_TopLeftLabel }, { Top_TopLeftLabel, Top_TopLeftLabel, Top_TopLeftLabel }, {Top_TopLeftLabel, Top_TopLeftLabel, Top_TopLeftLabel } } };

            int zeroOrOne = random.Next(0, 2);
            if (zeroOrOne == 0) circleTurn = false;
            else circleTurn = true;

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

        private void BotPlays(Label[,] labels)
        {
            int rdmColumn;
            int rdmLine;

            isBotPlays = true;

            do
            {
                rdmColumn = random.Next(0, 3);
                rdmLine = random.Next(0, 3);
            } while (isOccupiedBy[rdmColumn, rdmLine] != 0);

            PlaceSymbol(rdmColumn, rdmLine, labels[rdmColumn, rdmLine]);
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
            PlaceSymbol(0, 0, 0, TopLeft_TopLeftLabel);
        }

        private void TopLeft_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 0, 1, TopLeft_TopLabel);
        }

        private void TopLeft_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 0, 2, TopLeft_TopRightLabel);
        }

        private void TopLeft_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 1, 0, TopLeft_LeftLabel);
        }

        private void TopLeft_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 1, 1, TopLeft_MiddleLabel);
        }

        private void TopLeft_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 1, 2, TopLeft_RightLabel);
        }

        private void TopLeft_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 2, 0, TopLeft_BottomLeftLabel);
        }

        private void TopLeft_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 2, 1, TopLeft_BottomLabel);
        }

        private void TopLeft_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, 2, 2, TopLeft_BottomRightLabel);
        }

        private void Top_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 0, 0, Top_TopLeftLabel);
        }

        private void Top_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 0, 1, Top_TopLabel);
        }

        private void Top_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 0, 2, Top_TopRightLabel);
        }

        private void Top_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 1, 0, Top_LeftLabel);
        }

        private void Top_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 1, 1, Top_MiddleLabel);
        }

        private void Top_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 1, 2, Top_RightLabel);
        }

        private void Top_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 2, 0, Top_BottomLeftLabel);
        }

        private void Top_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 2, 1, Top_BottomLabel);
        }

        private void Top_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, 2, 2, Top_BottomRightLabel);
        }

        private void TopRight_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 0, 0, TopRight_TopLeftLabel);
        }

        private void TopRight_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 0, 1, TopRight_TopLabel);
        }

        private void TopRight_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 0, 2, TopRight_TopRightLabel);
        }

        private void TopRight_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 1, 0, TopRight_LeftLabel);
        }

        private void TopRight_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 1, 1, TopRight_MiddleLabel);
        }

        private void TopRight_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 1, 2, TopRight_RightLabel);
        }

        private void TopRight_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 2, 0, TopRight_BottomLeftLabel);
        }

        private void TopRight_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 2, 1, TopRight_BottomLabel);
        }

        private void TopRight_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, 2, 2, TopRight_BottomRightLabel);
        }

        private void Left_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 0, 0, Left_TopLeftLabel);
        }

        private void Left_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 0, 1, Left_TopLabel);
        }

        private void Left_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 0, 2, Left_TopRightLabel);
        }

        private void Left_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 1, 0, Left_LeftLabel);
        }

        private void Left_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 1, 1, Left_MiddleLabel);
        }

        private void Left_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 1, 2, Left_RightLabel);
        }

        private void Left_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 2, 0, Left_BottomLeftLabel);
        }

        private void Left_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 2, 1, Left_BottomLabel);
        }

        private void Left_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, 2, 2, Left_BottomRightLabel);
        }

        private void Middle_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 0, 0, Middle_TopLeftLabel);
        }

        private void Middle_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 0, 1, Middle_TopLabel);
        }

        private void Middle_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 0, 2, Middle_TopRightLabel);
        }

        private void Middle_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 1, 0, Middle_LeftLabel);
        }

        private void Middle_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 1, 1, Middle_MiddleLabel);
        }

        private void Middle_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 1, 2, Middle_RightLabel);
        }

        private void Middle_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 2, 0, Middle_BottomLeftLabel);
        }

        private void Middle_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 2, 1, Middle_BottomLabel);
        }

        private void Middle_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, 2, 2, Middle_BottomRightLabel);
        }

        private void Right_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 0, 0, Right_TopLeftLabel);
        }

        private void Right_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 0, 1, Right_TopLabel);
        }

        private void Right_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 0, 2, Right_TopRightLabel);
        }

        private void Right_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 1, 0, Right_LeftLabel);
        }

        private void Right_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 1, 1, Right_MiddleLabel);
        }

        private void Right_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 1, 2, Right_RightLabel);
        }

        private void Right_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 2, 0, Right_BottomLeftLabel);
        }

        private void Right_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 2, 1, Right_BottomLabel);
        }

        private void Right_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, 2, 2, Right_BottomRightLabel);
        }

        private void BottomLeft_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 0, 0, BottomLeft_TopLeftLabel);
        }

        private void BottomLeft_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 0, 1, BottomLeft_TopLabel);
        }

        private void BottomLeft_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 0, 2, BottomLeft_TopRightLabel);
        }

        private void BottomLeft_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 1, 0, BottomLeft_LeftLabel);
        }

        private void BottomLeft_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 1, 1, BottomLeft_MiddleLabel);
        }

        private void BottomLeft_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 1, 2, BottomLeft_RightLabel);
        }

        private void BottomLeft_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 2, 0, BottomLeft_BottomLeftLabel);
        }

        private void BottomLeft_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 2, 1, BottomLeft_BottomLabel);
        }

        private void BottomLeft_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, 2, 2, BottomLeft_BottomRightLabel);
        }

        private void Bottom_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 0, 0, Bottom_TopLeftLabel);
        }

        private void Bottom_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 0, 1, Bottom_TopLabel);
        }

        private void Bottom_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 0, 2, Bottom_TopRightLabel);
        }

        private void Bottom_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 1, 0, Bottom_LeftLabel);
        }

        private void Bottom_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 1, 1, Bottom_MiddleLabel);
        }

        private void Bottom_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 1, 2, Bottom_RightLabel);
        }

        private void Bottom_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 2, 0, Bottom_BottomLeftLabel);
        }

        private void Bottom_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 2, 1, Bottom_BottomLabel);
        }

        private void Bottom_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, 2, 2, Bottom_BottomRightLabel);
        }

        private void BottomRight_TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 0, 0, BottomRight_TopLeftLabel);
        }

        private void BottomRight_TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 0, 1, BottomRight_TopLabel);
        }

        private void BottomRight_TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 0, 2, BottomRight_TopRightLabel);
        }

        private void BottomRight_LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 1, 0, BottomRight_LeftLabel);
        }

        private void BottomRight_MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 1, 1, BottomRight_MiddleLabel);
        }

        private void BottomRight_RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 1, 2, BottomRight_RightLabel);
        }

        private void BottomRight_BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 2, 0, BottomRight_BottomLeftLabel);
        }

        private void BottomRight_BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 2, 1, BottomRight_BottomLabel);
        }

        private void BottomRight_BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, 2, 2, BottomRight_BottomRightLabel);
        }


        private void PlaceSymbol(int case_label, int idLabelColumn, int idLabelLine, Label label)
        {
            if (!isgameEnded)
            {
                if (isOccupiedBy[case_label, idLabelColumn, idLabelLine] == 0)
                {
                    if (!circleTurn)
                    {
                        label.Image = System.Drawing.Image.FromFile(petitCercle);
                        isOccupiedBy[case_label, idLabelColumn, idLabelLine] = 1;
                    }
                    else
                    {
                        label.Image = System.Drawing.Image.FromFile(petiteCroix);
                        isOccupiedBy[case_label, idLabelColumn, idLabelLine] = 2;
                    }

                    if (VerifyWinner(isOccupiedBy) != 0)
                    {
                        if (VerifyWinner(isOccupiedBy) == 1) OsWinningLabel.Visible = true;
                        if (VerifyWinner(isOccupiedBy) == 2) XsWinningLabel.Visible = true;
                        isgameEnded = true;
                    }
                    WhosTurn();
                }
            }
        }
    }
}
/*
private int VerifyWinner(int[,,] isOccupiedBy)
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
if ((isOccupiedBy[0, 2] == 1 && isOccupiedBy[1, 1] == 1 && isOccupiedBy[2, 0] == 1) || (isOccupiedBy[0, 2] == 2 && isOccupiedBy[1, 1] == 2 && isOccupiedBy[2, 0] == 2))
{
return isOccupiedBy[0, 2];
}
return 0;
} 
}
}*/