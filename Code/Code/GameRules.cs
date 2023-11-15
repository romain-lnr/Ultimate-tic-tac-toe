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
    public partial class GameRules : Form
    {
        public GameRules()
        {
            InitializeComponent();
        }

        private void RulesTitleLabel_Click(object sender, EventArgs e)
        {

        }

        private void BackToMenuButton_Click(object sender, EventArgs e)
        {
            // Show the game menu window
            GameMenu gameMenu = new GameMenu();
            gameMenu.Show();

            // Hide the game rules window
            this.Hide();
        }
    }
}
