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
        public PlayGameSMorpionForm()
        {
            InitializeComponent();
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

        }

        private void TopLeft_TopLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
