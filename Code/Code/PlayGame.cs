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
                OsTurnLabel.Visible = true;
                XsTurnLabel.Visible = false;
                circleTurn = false;    
            }
            else
            {
                XsTurnLabel.Visible = true;
                OsTurnLabel.Visible = false;
                circleTurn = true;
            }
        }

        public PlayGameForm()
        {
            InitializeComponent();

            int zeroOrOne = random.Next(0, 1);
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
            if (isOccupied[0] == false)
            {
                if (!circleTurn)
                {
                    TopLeftLabel.Image = System.Drawing.Image.FromFile(grandCercle);
                }
                else
                {
                    TopLeftLabel.Image = System.Drawing.Image.FromFile(grandeCroix);
                }
                isOccupied[0] = true;
                WhosTurn();
            }
        }
    }
}