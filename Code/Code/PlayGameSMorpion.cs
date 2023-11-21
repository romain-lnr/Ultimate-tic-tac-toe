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
        private int[,] isOccupiedBy = new int[3, 3];
        private bool circleTurn;
        private bool isgameEnded;
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

            int zeroOrOne = random.Next(0, 2);
            if (zeroOrOne == 0) circleTurn = false;
            else circleTurn = true;

            WhosTurn();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    isOccupiedBy[i, j] = 0;
                }
            }
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

        private void PlaceSymbol(int idLabelColumn, int idLabelLine, Label label)
        {
            if (!isgameEnded)
            {
                if (isOccupiedBy[idLabelColumn, idLabelLine] == 0)
                {
                    if (!circleTurn)
                    {
                        label.Image = System.Drawing.Image.FromFile(grandCercle);
                        isOccupiedBy[idLabelColumn, idLabelLine] = 1;
                    }
                    else
                    {
                        label.Image = System.Drawing.Image.FromFile(grandeCroix);
                        isOccupiedBy[idLabelColumn, idLabelLine] = 2;
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
            if ((isOccupiedBy[0, 2] == 1 && isOccupiedBy[1, 1] == 1 && isOccupiedBy[2, 0] == 1) || (isOccupiedBy[0, 0] == 2 && isOccupiedBy[1, 1] == 2 && isOccupiedBy[2, 2] == 2))
            {
                return isOccupiedBy[0, 2];
            }
            return 0;
        }
    }
}
