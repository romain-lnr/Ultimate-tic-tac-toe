namespace Code
{
    public partial class GameMenu : Form
    {
        public GameMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GameStartButton_Click(object sender, EventArgs e)
        {
            // Disable the button that leads you to the menu
            GameStartButton.Visible = false;

            // Enable all the menu buttons
            QuitButton.Visible = true;
            RulesButton.Visible = true;
            PlayButton.Visible = true;

        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            // Quit the game
            Application.Exit();
        }

        private void RulesButton_Click(object sender, EventArgs e)
        {
            // Show the game rules window
            GameRules gameRules = new GameRules();
            gameRules.Show();

            // Hide the game menu window
            this.Hide();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {

        }
    }
}