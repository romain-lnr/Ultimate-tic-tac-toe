namespace Code
{
    partial class GameRulesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameRulesForm));
            RulesTitleLabel = new Label();
            Rules_Label = new Label();
            BackToMenuButton = new Button();
            SuspendLayout();
            // 
            // RulesTitleLabel
            // 
            RulesTitleLabel.AutoSize = true;
            RulesTitleLabel.Font = new Font("Courier New", 27F, FontStyle.Bold, GraphicsUnit.Point);
            RulesTitleLabel.Location = new Point(841, 60);
            RulesTitleLabel.Name = "RulesTitleLabel";
            RulesTitleLabel.Size = new Size(238, 41);
            RulesTitleLabel.TabIndex = 0;
            RulesTitleLabel.Text = "Game Rules";
            RulesTitleLabel.Click += RulesTitleLabel_Click;
            // 
            // Rules_Label
            // 
            Rules_Label.AutoSize = true;
            Rules_Label.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            Rules_Label.Location = new Point(51, 150);
            Rules_Label.MaximumSize = new Size(1800, 0);
            Rules_Label.Name = "Rules_Label";
            Rules_Label.Size = new Size(1799, 532);
            Rules_Label.TabIndex = 1;
            Rules_Label.Text = resources.GetString("Rules_Label.Text");
            // 
            // BackToMenuButton
            // 
            BackToMenuButton.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            BackToMenuButton.Location = new Point(765, 799);
            BackToMenuButton.Name = "BackToMenuButton";
            BackToMenuButton.Size = new Size(390, 132);
            BackToMenuButton.TabIndex = 2;
            BackToMenuButton.Text = "Back to Menu";
            BackToMenuButton.UseVisualStyleBackColor = true;
            BackToMenuButton.Click += BackToMenuButton_Click;
            // 
            // GameRulesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(BackToMenuButton);
            Controls.Add(Rules_Label);
            Controls.Add(RulesTitleLabel);
            Name = "GameRulesForm";
            Text = "Ultimate Tic-Tac-Toe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label RulesTitleLabel;
        private Label Rules_Label;
        private Button BackToMenuButton;
    }
}