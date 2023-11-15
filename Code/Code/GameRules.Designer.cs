namespace Code
{
    partial class GameRules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameRules));
            RulesTitleLabel = new Label();
            label2 = new Label();
            BackToMenuButton = new Button();
            SuspendLayout();
            // 
            // RulesTitleLabel
            // 
            RulesTitleLabel.AutoSize = true;
            RulesTitleLabel.Font = new Font("Courier New", 27F, FontStyle.Bold, GraphicsUnit.Point);
            RulesTitleLabel.Location = new Point(841, 95);
            RulesTitleLabel.Name = "RulesTitleLabel";
            RulesTitleLabel.Size = new Size(238, 41);
            RulesTitleLabel.TabIndex = 0;
            RulesTitleLabel.Text = "Game Rules";
            RulesTitleLabel.Click += RulesTitleLabel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(51, 241);
            label2.MaximumSize = new Size(1800, 0);
            label2.Name = "label2";
            label2.Size = new Size(1797, 252);
            label2.TabIndex = 1;
            label2.Text = resources.GetString("label2.Text");
            // 
            // BackToMenuButton
            // 
            BackToMenuButton.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            BackToMenuButton.Location = new Point(765, 614);
            BackToMenuButton.Name = "BackToMenuButton";
            BackToMenuButton.Size = new Size(390, 132);
            BackToMenuButton.TabIndex = 2;
            BackToMenuButton.Text = "Back to Menu";
            BackToMenuButton.UseVisualStyleBackColor = true;
            BackToMenuButton.Click += BackToMenuButton_Click;
            // 
            // GameRules
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(BackToMenuButton);
            Controls.Add(label2);
            Controls.Add(RulesTitleLabel);
            Name = "GameRules";
            Text = "Ultimate Tic-Tac-Toe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label RulesTitleLabel;
        private Label label2;
        private Button BackToMenuButton;
    }
}