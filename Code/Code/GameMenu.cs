namespace Code
{
    public partial class GameMenuForm : Form
    {
        private bool isSuperMorpion;
        public static bool onePlayer;

        public GameMenuForm()
        {
            InitializeComponent();
            isSuperMorpion = false;
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
            // Show the game rules form
            GameRulesForm gameRules = new GameRulesForm();
            gameRules.ShowDialog();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            // Disable the choice buttons
            QuitButton.Visible = false;
            PlayButton.Visible = false;
            RulesButton.Visible = false;

            // Enable the game mode buttons
            ClassicButton.Visible = true;
            SuperMorpionButton.Visible = true;
            BackToMenuButton.Visible = true;
        }

        private void OnePlayerButton_Click(object sender, EventArgs e)
        {
            onePlayer = true;
            if (isSuperMorpion)
            {
                // Show the game Morpion form
                PlayGameUltimateMorpionForm playGameSMorpion = new PlayGameUltimateMorpionForm();
                playGameSMorpion.ShowDialog();
            }
            else
            {
                PlayGameMorpionForm playGameMorpion = new PlayGameMorpionForm();
                playGameMorpion.ShowDialog();
            }
        }

        private void TwoPlayersButton_Click(object sender, EventArgs e)
        {
            onePlayer = false;
            if (isSuperMorpion)
            {
                // Show the game Morpion form
                PlayGameUltimateMorpionForm playGameSMorpion = new PlayGameUltimateMorpionForm();
                playGameSMorpion.ShowDialog();
            }
            else
            {
                PlayGameMorpionForm playGameMorpion = new PlayGameMorpionForm();
                playGameMorpion.ShowDialog();
            }
        }

        private void BackToMenuButton_Click(object sender, EventArgs e)
        {
            // Disable the game mode buttons
            OnePlayerButton.Visible = false;
            TwoPlayersButton.Visible = false;
            BackToMenuButton.Visible = false;
            ClassicButton.Visible = false;
            SuperMorpionButton.Visible = false;

            // Enable the choice buttons
            QuitButton.Visible = true;
            PlayButton.Visible = true;
            RulesButton.Visible = true;
        }

        private void ClassicButton_Click(object sender, EventArgs e)
        {
            // Disable the choice buttons
            ClassicButton.Visible = false;
            SuperMorpionButton.Visible = false;

            // Enable the game mode buttons
            OnePlayerButton.Visible = true;
            TwoPlayersButton.Visible = true;

            isSuperMorpion = false;
        }

        private void SuperMorpionButton_Click(object sender, EventArgs e)
        {
            // Disable the choice buttons
            ClassicButton.Visible = false;
            SuperMorpionButton.Visible = false;

            // Enable the game mode buttons
            OnePlayerButton.Visible = true;
            TwoPlayersButton.Visible = true;

            isSuperMorpion = true;
        }
    }
}