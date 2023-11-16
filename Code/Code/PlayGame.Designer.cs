namespace Code
{
    partial class PlayGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayGameForm));
            GridLabel = new Label();
            BackToMenuButton = new Button();
            QuitButton = new Button();
            TopLeftLabel = new Label();
            XsTurnLabel = new Label();
            OsTurnLabel = new Label();
            SuspendLayout();
            // 
            // GridLabel
            // 
            GridLabel.AutoSize = true;
            GridLabel.Image = (Image)resources.GetObject("GridLabel.Image");
            GridLabel.Location = new Point(739, 45);
            GridLabel.MinimumSize = new Size(600, 600);
            GridLabel.Name = "GridLabel";
            GridLabel.Size = new Size(600, 600);
            GridLabel.TabIndex = 0;
            // 
            // BackToMenuButton
            // 
            BackToMenuButton.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            BackToMenuButton.Location = new Point(557, 827);
            BackToMenuButton.Name = "BackToMenuButton";
            BackToMenuButton.Size = new Size(390, 132);
            BackToMenuButton.TabIndex = 1;
            BackToMenuButton.Text = "Back to Menu";
            BackToMenuButton.UseVisualStyleBackColor = true;
            BackToMenuButton.Click += BackToMenuButton_Click;
            // 
            // QuitButton
            // 
            QuitButton.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            QuitButton.Location = new Point(1117, 827);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(390, 132);
            QuitButton.TabIndex = 2;
            QuitButton.Text = "Quit";
            QuitButton.UseVisualStyleBackColor = true;
            QuitButton.Click += QuitButton_Click;
            // 
            // TopLeftLabel
            // 
            TopLeftLabel.AutoSize = true;
            TopLeftLabel.Location = new Point(739, 45);
            TopLeftLabel.MinimumSize = new Size(196, 196);
            TopLeftLabel.Name = "TopLeftLabel";
            TopLeftLabel.Size = new Size(196, 196);
            TopLeftLabel.TabIndex = 3;
            TopLeftLabel.Click += TopLeftLabel_Click;
            // 
            // XsTurnLabel
            // 
            XsTurnLabel.AutoSize = true;
            XsTurnLabel.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            XsTurnLabel.ForeColor = Color.Blue;
            XsTurnLabel.Location = new Point(85, 98);
            XsTurnLabel.Name = "XsTurnLabel";
            XsTurnLabel.Size = new Size(197, 37);
            XsTurnLabel.TabIndex = 4;
            XsTurnLabel.Text = "X's turn!";
            // 
            // OsTurnLabel
            // 
            OsTurnLabel.AutoSize = true;
            OsTurnLabel.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            OsTurnLabel.ForeColor = Color.Red;
            OsTurnLabel.Location = new Point(85, 98);
            OsTurnLabel.Name = "OsTurnLabel";
            OsTurnLabel.Size = new Size(197, 37);
            OsTurnLabel.TabIndex = 5;
            OsTurnLabel.Text = "O's turn!";
            // 
            // PlayGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(OsTurnLabel);
            Controls.Add(XsTurnLabel);
            Controls.Add(TopLeftLabel);
            Controls.Add(QuitButton);
            Controls.Add(BackToMenuButton);
            Controls.Add(GridLabel);
            Name = "PlayGameForm";
            Text = "Ultimate Tic-Tac-Toe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label GridLabel;
        private Button BackToMenuButton;
        private Button QuitButton;
        private Label TopLeftLabel;
        private Label XsTurnLabel;
        private Label OsTurnLabel;
    }
}