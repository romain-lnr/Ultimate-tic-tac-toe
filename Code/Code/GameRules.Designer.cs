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
            GameRulesLabel = new Label();
            SuspendLayout();
            // 
            // GameRulesLabel
            // 
            GameRulesLabel.AutoSize = true;
            GameRulesLabel.Font = new Font("Courier New", 27F, FontStyle.Bold, GraphicsUnit.Point);
            GameRulesLabel.Location = new Point(841, 95);
            GameRulesLabel.Name = "GameRulesLabel";
            GameRulesLabel.Size = new Size(238, 41);
            GameRulesLabel.TabIndex = 0;
            GameRulesLabel.Text = "Game Rules";
            GameRulesLabel.Click += GameRulesLabel_Click;
            // 
            // GameRules
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(GameRulesLabel);
            Name = "GameRules";
            Text = "Ultimate Tic-Tac-Toe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label GameRulesLabel;
    }
}