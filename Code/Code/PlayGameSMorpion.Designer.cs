namespace Code
{
    partial class PlayGameSMorpionForm
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
            Gridlabel = new Label();
            BackButton = new Button();
            QuitButton = new Button();
            TopLeft_TopLeftLabel = new Label();
            TopLeft_TopLabel = new Label();
            TopLeft_TopRightLabel = new Label();
            TopLeft_LeftLabel = new Label();
            TopLeft_MiddleLabel = new Label();
            TopLeft_RightLabel = new Label();
            TopLeft_BottomLeftLabel = new Label();
            TopLeft_BottomLabel = new Label();
            TopLeft_BottomRightLabel = new Label();
            SuspendLayout();
            // 
            // Gridlabel
            // 
            Gridlabel.Image = Properties.Resources.Grille1_0;
            Gridlabel.Location = new Point(660, 68);
            Gridlabel.MaximumSize = new Size(600, 600);
            Gridlabel.Name = "Gridlabel";
            Gridlabel.Size = new Size(600, 600);
            Gridlabel.TabIndex = 0;
            // 
            // BackButton
            // 
            BackButton.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            BackButton.Location = new Point(517, 827);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(390, 132);
            BackButton.TabIndex = 1;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // QuitButton
            // 
            QuitButton.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            QuitButton.Location = new Point(1013, 827);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(390, 132);
            QuitButton.TabIndex = 2;
            QuitButton.Text = "Quit";
            QuitButton.UseVisualStyleBackColor = true;
            QuitButton.Click += QuitButton_Click;
            // 
            // TopLeft_TopLeftLabel
            // 
            TopLeft_TopLeftLabel.Location = new Point(699, 107);
            TopLeft_TopLeftLabel.Name = "TopLeft_TopLeftLabel";
            TopLeft_TopLeftLabel.Size = new Size(39, 39);
            TopLeft_TopLeftLabel.TabIndex = 3;
            TopLeft_TopLeftLabel.Click += TopLeft_TopLeftLabel_Click;
            // 
            // TopLeft_TopLabel
            // 
            TopLeft_TopLabel.Location = new Point(741, 107);
            TopLeft_TopLabel.Name = "TopLeft_TopLabel";
            TopLeft_TopLabel.Size = new Size(37, 39);
            TopLeft_TopLabel.TabIndex = 4;
            TopLeft_TopLabel.Click += TopLeft_TopLabel_Click;
            // 
            // TopLeft_TopRightLabel
            // 
            TopLeft_TopRightLabel.Location = new Point(781, 107);
            TopLeft_TopRightLabel.Name = "TopLeft_TopRightLabel";
            TopLeft_TopRightLabel.Size = new Size(39, 39);
            TopLeft_TopRightLabel.TabIndex = 5;
            // 
            // TopLeft_LeftLabel
            // 
            TopLeft_LeftLabel.Location = new Point(699, 149);
            TopLeft_LeftLabel.Name = "TopLeft_LeftLabel";
            TopLeft_LeftLabel.Size = new Size(39, 37);
            TopLeft_LeftLabel.TabIndex = 6;
            // 
            // TopLeft_MiddleLabel
            // 
            TopLeft_MiddleLabel.Location = new Point(741, 149);
            TopLeft_MiddleLabel.Name = "TopLeft_MiddleLabel";
            TopLeft_MiddleLabel.Size = new Size(37, 37);
            TopLeft_MiddleLabel.TabIndex = 7;
            // 
            // TopLeft_RightLabel
            // 
            TopLeft_RightLabel.Location = new Point(781, 149);
            TopLeft_RightLabel.Name = "TopLeft_RightLabel";
            TopLeft_RightLabel.Size = new Size(39, 37);
            TopLeft_RightLabel.TabIndex = 8;
            // 
            // TopLeft_BottomLeftLabel
            // 
            TopLeft_BottomLeftLabel.Location = new Point(699, 189);
            TopLeft_BottomLeftLabel.Name = "TopLeft_BottomLeftLabel";
            TopLeft_BottomLeftLabel.Size = new Size(39, 39);
            TopLeft_BottomLeftLabel.TabIndex = 9;
            // 
            // TopLeft_BottomLabel
            // 
            TopLeft_BottomLabel.Location = new Point(741, 189);
            TopLeft_BottomLabel.Name = "TopLeft_BottomLabel";
            TopLeft_BottomLabel.Size = new Size(37, 39);
            TopLeft_BottomLabel.TabIndex = 10;
            // 
            // TopLeft_BottomRightLabel
            // 
            TopLeft_BottomRightLabel.Location = new Point(781, 189);
            TopLeft_BottomRightLabel.Name = "TopLeft_BottomRightLabel";
            TopLeft_BottomRightLabel.Size = new Size(39, 39);
            TopLeft_BottomRightLabel.TabIndex = 11;
            // 
            // PlayGameSMorpionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(TopLeft_BottomRightLabel);
            Controls.Add(TopLeft_BottomLabel);
            Controls.Add(TopLeft_BottomLeftLabel);
            Controls.Add(TopLeft_RightLabel);
            Controls.Add(TopLeft_MiddleLabel);
            Controls.Add(TopLeft_LeftLabel);
            Controls.Add(TopLeft_TopRightLabel);
            Controls.Add(TopLeft_TopLabel);
            Controls.Add(TopLeft_TopLeftLabel);
            Controls.Add(QuitButton);
            Controls.Add(BackButton);
            Controls.Add(Gridlabel);
            Name = "PlayGameSMorpionForm";
            Text = "PlayGameSMorpion";
            ResumeLayout(false);
        }

        #endregion

        private Label Gridlabel;
        private Button BackButton;
        private Button QuitButton;
        private Label TopLeft_TopLeftLabel;
        private Label TopLeft_TopLabel;
        private Label TopLeft_TopRightLabel;
        private Label TopLeft_LeftLabel;
        private Label TopLeft_MiddleLabel;
        private Label TopLeft_RightLabel;
        private Label TopLeft_BottomLeftLabel;
        private Label TopLeft_BottomLabel;
        private Label TopLeft_BottomRightLabel;
    }
}