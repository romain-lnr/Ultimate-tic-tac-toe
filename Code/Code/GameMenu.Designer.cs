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
            GameTitle.Click += label1_Click;
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
            // GameMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(PlayButton);
            Controls.Add(RulesButton);
            Controls.Add(QuitButton);
            Controls.Add(GameTitle);
            Controls.Add(GameStartButton);
            Name = "GameMenuForm";
            Text = "Ultimate Tic-Tac-Toe";
            Load += Form1_Load;
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
    }
}