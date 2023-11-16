using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Code
{
    public partial class PlayGameForm : Form
    {
        private string grandCercle = "..\\..\\..\\Images\\GrandCercle.png";
        private string grandeCroix = "..\\..\\..\\Images\\GrandeCroix.png";
        private bool[] isOccupied = new bool[9];
        private bool circleTurn;
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

        public PlayGameForm()
        {
            InitializeComponent();

            int zeroOrOne = random.Next(0, 2);
            if (zeroOrOne == 0) circleTurn = false;
            else circleTurn = true;

            WhosTurn();

            for (int i = 0; i < 8; i++)
            {
                isOccupied[i] = false;
            }
        }

        private void BackToMenuButton_Click(object sender, EventArgs e)
        {
            // Show the game menu window
            GameMenuForm gameMenu = new GameMenuForm();
            gameMenu.Show();

            // Hide the game window
            this.Hide();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            // Quit the game
            System.Windows.Forms.Application.Exit();
        }

        private void TopLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(0, TopLeftLabel);
        }

        private void TopLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(1, TopLabel);
        }

        private void TopRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(2, TopRightLabel);
        }

        private void LeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(3, LeftLabel);
        }

        private void MiddleLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(4, MiddleLabel);
        }

        private void RightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(5, RightLabel);
        }

        private void BottomLeftLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(6, BottomLeftLabel);
        }

        private void BottomLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(7, BottomLabel);
        }

        private void BottomRightLabel_Click(object sender, EventArgs e)
        {
            PlaceSymbol(8, BottomRightLabel);
        }

        private void PlaceSymbol(int idLabel, Label label)
        {
            if (isOccupied[idLabel] == false)
            {
                if (!circleTurn)
                {
                    label.Image = System.Drawing.Image.FromFile(grandCercle);
                }
                else
                {
                    label.Image = System.Drawing.Image.FromFile(grandeCroix);
                }
                isOccupied[idLabel] = true;
                WhosTurn();
            }
        }
    }
}