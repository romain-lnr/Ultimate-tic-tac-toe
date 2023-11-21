namespace Code
{
    partial class GameMenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameMenuForm));
            GameStartButton = new Button();
            GameTitle = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            QuitButton = new Button();
            RulesButton = new Button();
            PlayButton = new Button();
            OnePlayerButton = new Button();
            TwoPlayersButton = new Button();
            BackToMenuButton = new Button();
            ClassicButton = new Button();
            SuperMorpionButton = new Button();
            SuspendLayout();
            // 
            // GameStartButton
            // 
            GameStartButton.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            GameStartButton.Location = new Point(765, 671);
            GameStartButton.Name = "GameStartButton";
            GameStartButton.Size = new Size(390, 132);
            GameStartButton.TabIndex = 0;
            GameStartButton.Text = "Start";
            GameStartButton.UseVisualStyleBackColor = true;
            GameStartButton.Click += GameStartButton_Click;
            // 
            // GameTitle
            // 
            GameTitle.AutoSize = true;
            GameTitle.Font = new Font("Courier New", 18F, FontStyle.Regular, GraphicsUnit.Point);
            GameTitle.Location = new Point(373, 141);
            GameTitle.MaximumSize = new Size(10000, 10000);
            GameTitle.Name = "GameTitle";
            GameTitle.Size = new Size(1174, 378);
            GameTitle.TabIndex = 1;
            GameTitle.Text = resources.GetString("GameTitle.Text");
            // 
            // QuitButton
            // 
            QuitButton.AccessibleName = "";
            QuitButton.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            QuitButton.Location = new Point(270, 671);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(390, 132);
            QuitButton.TabIndex = 2;
            QuitButton.Text = "Quit";
            QuitButton.UseVisualStyleBackColor = true;
            QuitButton.Visible = false;
            QuitButton.Click += QuitButton_Click;
            // 
            // RulesButton
            // 
            RulesButton.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            RulesButton.Location = new Point(1260, 671);
            RulesButton.Name = "RulesButton";
            RulesButton.Size = new Size(390, 132);
            RulesButton.TabIndex = 3;
            RulesButton.Text = "Game Rules";
            RulesButton.UseVisualStyleBackColor = true;
            RulesButton.Visible = false;
            RulesButton.Click += RulesButton_Click;
            // 
            // PlayButton
            // 
            PlayButton.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            PlayButton.Location = new Point(765, 671);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(390, 132);
            PlayButton.TabIndex = 4;
            PlayButton.Text = "Play";
            PlayButton.UseVisualStyleBackColor = true;
            PlayButton.Visible = false;
            PlayButton.Click += PlayButton_Click;
            // 
            // OnePlayerButton
            // 
            OnePlayerButton.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            OnePlayerButton.Location = new Point(765, 671);
            OnePlayerButton.Name = "OnePlayerButton";
            OnePlayerButton.Size = new Size(390, 132);
            OnePlayerButton.TabIndex = 5;
            OnePlayerButton.Text = "1 Player";
            OnePlayerButton.UseVisualStyleBackColor = true;
            OnePlayerButton.Visible = false;
            OnePlayerButton.Click += OnePlayerButton_Click;
            // 
            // TwoPlayersButton
            // 
            TwoPlayersButton.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            TwoPlayersButton.Location = new Point(1260, 671);
            TwoPlayersButton.Name = "TwoPlayersButton";
            TwoPlayersButton.Size = new Size(390, 132);
            TwoPlayersButton.TabIndex = 6;
            TwoPlayersButton.Text = "2 Players";
            TwoPlayersButton.UseVisualStyleBackColor = true;
            TwoPlayersButton.Visible = false;
            TwoPlayersButton.Click += TwoPlayersButton_Click;
            // 
            // BackToMenuButton
            // 
            BackToMenuButton.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            BackToMenuButton.Location = new Point(270, 671);
            BackToMenuButton.Name = "BackToMenuButton";
            BackToMenuButton.Size = new Size(390, 132);
            BackToMenuButton.TabIndex = 7;
            BackToMenuButton.Text = "Back to Menu";
            BackToMenuButton.UseVisualStyleBackColor = true;
            BackToMenuButton.Visible = false;
            BackToMenuButton.Click += BackToMenuButton_Click;
            // 
            // ClassicButton
            // 
            ClassicButton.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            ClassicButton.ForeColor = SystemColors.ControlText;
            ClassicButton.Location = new Point(765, 671);
            ClassicButton.Name = "ClassicButton";
            ClassicButton.Size = new Size(390, 132);
            ClassicButton.TabIndex = 9;
            ClassicButton.Text = "Classique";
            ClassicButton.UseVisualStyleBackColor = true;
            ClassicButton.Visible = false;
            ClassicButton.Click += ClassicButton_Click;
            // 
            // SuperMorpionButton
            // 
            SuperMorpionButton.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            SuperMorpionButton.Location = new Point(1260, 671);
            SuperMorpionButton.Name = "SuperMorpionButton";
            SuperMorpionButton.Size = new Size(390, 132);
            SuperMorpionButton.TabIndex = 10;
            SuperMorpionButton.Text = "Super Morpion";
            SuperMorpionButton.UseVisualStyleBackColor = true;
            SuperMorpionButton.Visible = false;
            SuperMorpionButton.Click += SuperMorpionButton_Click;
            // 
            // GameMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(SuperMorpionButton);
            Controls.Add(ClassicButton);
            Controls.Add(BackToMenuButton);
            Controls.Add(TwoPlayersButton);
            Controls.Add(OnePlayerButton);
            Controls.Add(PlayButton);
            Controls.Add(RulesButton);
            Controls.Add(QuitButton);
            Controls.Add(GameTitle);
            Controls.Add(GameStartButton);
            Name = "GameMenuForm";
            Text = "Ultimate Tic-Tac-Toe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GameStartButton;
        private Label GameTitle;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button QuitButton;
        private Button RulesButton;
        private Button PlayButton;
        private Button OnePlayerButton;
        private Button TwoPlayersButton;
        private Button BackToMenuButton;
        private Button ClassicButton;
        private Button SuperMorpionButton;
    }
}