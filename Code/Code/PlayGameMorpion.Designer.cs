namespace Code
{
    partial class PlayGameMorpionForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayGameMorpionForm));
            GridLabel = new Label();
            BackButton = new Button();
            QuitButton = new Button();
            TopLeftLabel = new Label();
            XsTurnLabel = new Label();
            OsTurnLabel = new Label();
            TopLabel = new Label();
            TopRightLabel = new Label();
            LeftLabel = new Label();
            MiddleLabel = new Label();
            RightLabel = new Label();
            BottomLeftLabel = new Label();
            BottomLabel = new Label();
            BottomRightLabel = new Label();
            ResultLabel = new Label();
            BotTimer_Classic = new System.Windows.Forms.Timer(components);
            RGBTimer_Classic = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // GridLabel
            // 
            GridLabel.AutoSize = true;
            GridLabel.Image = (Image)resources.GetObject("GridLabel.Image");
            GridLabel.Location = new Point(660, 68);
            GridLabel.MinimumSize = new Size(600, 600);
            GridLabel.Name = "GridLabel";
            GridLabel.Size = new Size(600, 600);
            GridLabel.TabIndex = 0;
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
            // TopLeftLabel
            // 
            TopLeftLabel.AutoSize = true;
            TopLeftLabel.Location = new Point(663, 71);
            TopLeftLabel.MinimumSize = new Size(192, 192);
            TopLeftLabel.Name = "TopLeftLabel";
            TopLeftLabel.Size = new Size(192, 192);
            TopLeftLabel.TabIndex = 3;
            TopLeftLabel.Click += TheLabel_Click;
            // 
            // XsTurnLabel
            // 
            XsTurnLabel.AutoSize = true;
            XsTurnLabel.Font = new Font("Courier New", 25F, FontStyle.Bold, GraphicsUnit.Point);
            XsTurnLabel.ForeColor = Color.Blue;
            XsTurnLabel.Location = new Point(92, 226);
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
            OsTurnLabel.Location = new Point(92, 471);
            OsTurnLabel.Name = "OsTurnLabel";
            OsTurnLabel.Size = new Size(197, 37);
            OsTurnLabel.TabIndex = 5;
            OsTurnLabel.Text = "O's turn!";
            // 
            // TopLabel
            // 
            TopLabel.AutoSize = true;
            TopLabel.Location = new Point(863, 71);
            TopLabel.MinimumSize = new Size(192, 192);
            TopLabel.Name = "TopLabel";
            TopLabel.Size = new Size(192, 192);
            TopLabel.TabIndex = 6;
            TopLabel.Click += TheLabel_Click;
            // 
            // TopRightLabel
            // 
            TopRightLabel.AutoSize = true;
            TopRightLabel.Location = new Point(1063, 71);
            TopRightLabel.MinimumSize = new Size(192, 192);
            TopRightLabel.Name = "TopRightLabel";
            TopRightLabel.Size = new Size(192, 192);
            TopRightLabel.TabIndex = 7;
            TopRightLabel.Click += TheLabel_Click;
            // 
            // LeftLabel
            // 
            LeftLabel.AutoSize = true;
            LeftLabel.Location = new Point(663, 271);
            LeftLabel.MinimumSize = new Size(192, 192);
            LeftLabel.Name = "LeftLabel";
            LeftLabel.Size = new Size(192, 192);
            LeftLabel.TabIndex = 8;
            LeftLabel.Click += TheLabel_Click;
            // 
            // MiddleLabel
            // 
            MiddleLabel.AutoSize = true;
            MiddleLabel.Location = new Point(864, 271);
            MiddleLabel.MinimumSize = new Size(192, 192);
            MiddleLabel.Name = "MiddleLabel";
            MiddleLabel.Size = new Size(192, 192);
            MiddleLabel.TabIndex = 9;
            MiddleLabel.Click += TheLabel_Click;
            // 
            // RightLabel
            // 
            RightLabel.AutoSize = true;
            RightLabel.Location = new Point(1063, 271);
            RightLabel.MinimumSize = new Size(192, 192);
            RightLabel.Name = "RightLabel";
            RightLabel.Size = new Size(192, 192);
            RightLabel.TabIndex = 10;
            RightLabel.Click += TheLabel_Click;
            // 
            // BottomLeftLabel
            // 
            BottomLeftLabel.AutoSize = true;
            BottomLeftLabel.Location = new Point(663, 471);
            BottomLeftLabel.MinimumSize = new Size(192, 192);
            BottomLeftLabel.Name = "BottomLeftLabel";
            BottomLeftLabel.Size = new Size(192, 192);
            BottomLeftLabel.TabIndex = 11;
            BottomLeftLabel.Click += TheLabel_Click;
            // 
            // BottomLabel
            // 
            BottomLabel.AutoSize = true;
            BottomLabel.Location = new Point(863, 471);
            BottomLabel.MinimumSize = new Size(192, 192);
            BottomLabel.Name = "BottomLabel";
            BottomLabel.Size = new Size(192, 192);
            BottomLabel.TabIndex = 12;
            BottomLabel.Click += TheLabel_Click;
            // 
            // BottomRightLabel
            // 
            BottomRightLabel.AutoSize = true;
            BottomRightLabel.Location = new Point(1063, 471);
            BottomRightLabel.MinimumSize = new Size(192, 192);
            BottomRightLabel.Name = "BottomRightLabel";
            BottomRightLabel.Size = new Size(192, 192);
            BottomRightLabel.TabIndex = 13;
            BottomRightLabel.Click += TheLabel_Click;
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Font = new Font("Courier New", 50F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            ResultLabel.Location = new Point(85, 325);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(0, 76);
            ResultLabel.TabIndex = 17;
            // 
            // BotTimer_Classic
            // 
            BotTimer_Classic.Interval = 1000;
            BotTimer_Classic.Tick += BotTimer_Classic_Tick;
            // 
            // RGBTimer_Classic
            // 
            RGBTimer_Classic.Interval = 50;
            RGBTimer_Classic.Tick += RGBTimer_Classic_Tick;
            // 
            // PlayGameMorpionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(ResultLabel);
            Controls.Add(BottomRightLabel);
            Controls.Add(BottomLabel);
            Controls.Add(BottomLeftLabel);
            Controls.Add(RightLabel);
            Controls.Add(MiddleLabel);
            Controls.Add(LeftLabel);
            Controls.Add(TopRightLabel);
            Controls.Add(TopLabel);
            Controls.Add(OsTurnLabel);
            Controls.Add(XsTurnLabel);
            Controls.Add(TopLeftLabel);
            Controls.Add(QuitButton);
            Controls.Add(BackButton);
            Controls.Add(GridLabel);
            Name = "PlayGameMorpionForm";
            Text = "Ultimate Tic-Tac-Toe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label GridLabel;
        private Button BackButton;
        private Button QuitButton;
        private Label TopLeftLabel;
        private Label XsTurnLabel;
        private Label OsTurnLabel;
        private Label TopLabel;
        private Label TopRightLabel;
        private Label LeftLabel;
        private Label MiddleLabel;
        private Label RightLabel;
        private Label BottomLeftLabel;
        private Label BottomLabel;
        private Label BottomRightLabel;
        private Label ResultLabel;
        private System.Windows.Forms.Timer BotTimer_Classic;
        private System.Windows.Forms.Timer RGBTimer_Classic;
    }
}