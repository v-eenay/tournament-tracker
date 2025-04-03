namespace TrackerUI
{
    partial class TournamentViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentViewerForm));
            TournamentLabel = new Label();
            TournamentName = new Label();
            RoundLabel = new Label();
            RoundDropDown = new ComboBox();
            UnplayedOnlyCheckbox = new CheckBox();
            MatchupListbox = new ListBox();
            TeamOneName = new Label();
            TeamOneScore = new Label();
            TeamOneScoreValue = new TextBox();
            TeamTwoName = new Label();
            TeamTwoScore = new Label();
            TeamTwoScoreValue = new TextBox();
            VsLabel = new Label();
            ScoreButton = new Button();
            SuspendLayout();
            // 
            // TournamentLabel
            // 
            TournamentLabel.AutoSize = true;
            TournamentLabel.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TournamentLabel.ForeColor = Color.FromArgb(51, 153, 255);
            TournamentLabel.Location = new Point(50, 30);
            TournamentLabel.Name = "TournamentLabel";
            TournamentLabel.Size = new Size(269, 59);
            TournamentLabel.TabIndex = 0;
            TournamentLabel.Text = "Tournament";
            TournamentLabel.Click += label1_Click;
            // 
            // TournamentName
            // 
            TournamentName.AutoSize = true;
            TournamentName.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TournamentName.ForeColor = Color.FromArgb(64, 64, 64);
            TournamentName.Location = new Point(52, 95);
            TournamentName.Name = "TournamentName";
            TournamentName.Size = new Size(147, 45);
            TournamentName.TabIndex = 1;
            TournamentName.Text = "<None>";
            // 
            // RoundLabel
            // 
            RoundLabel.AutoSize = true;
            RoundLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RoundLabel.ForeColor = Color.FromArgb(51, 153, 255);
            RoundLabel.Location = new Point(50, 160);
            RoundLabel.Name = "RoundLabel";
            RoundLabel.Padding = new Padding(0, 5, 0, 5);
            RoundLabel.Size = new Size(72, 35);
            RoundLabel.TabIndex = 2;
            RoundLabel.Text = "Round";
            // 
            // RoundDropDown
            // 
            RoundDropDown.BackColor = Color.White;
            RoundDropDown.FlatStyle = FlatStyle.Flat;
            RoundDropDown.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RoundDropDown.ForeColor = Color.FromArgb(64, 64, 64);
            RoundDropDown.FormattingEnabled = true;
            RoundDropDown.Location = new Point(155, 160);
            RoundDropDown.Name = "RoundDropDown";
            RoundDropDown.Size = new Size(250, 29);
            RoundDropDown.TabIndex = 3;
            // 
            // UnplayedOnlyCheckbox
            // 
            UnplayedOnlyCheckbox.AutoSize = true;
            UnplayedOnlyCheckbox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UnplayedOnlyCheckbox.ForeColor = Color.FromArgb(64, 64, 64);
            UnplayedOnlyCheckbox.Location = new Point(425, 160);
            UnplayedOnlyCheckbox.Name = "UnplayedOnlyCheckbox";
            UnplayedOnlyCheckbox.Padding = new Padding(0, 3, 0, 3);
            UnplayedOnlyCheckbox.Size = new Size(132, 31);
            UnplayedOnlyCheckbox.TabIndex = 4;
            UnplayedOnlyCheckbox.Text = "Unplayed Only";
            UnplayedOnlyCheckbox.UseVisualStyleBackColor = true;
            UnplayedOnlyCheckbox.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // MatchupListbox
            // 
            MatchupListbox.BackColor = Color.White;
            MatchupListbox.BorderStyle = BorderStyle.None;
            MatchupListbox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MatchupListbox.ForeColor = Color.FromArgb(64, 64, 64);
            MatchupListbox.FormattingEnabled = true;
            MatchupListbox.ItemHeight = 21;
            MatchupListbox.Location = new Point(50, 225);
            MatchupListbox.Margin = new Padding(10);
            MatchupListbox.Name = "MatchupListbox";
            MatchupListbox.Size = new Size(450, 336);
            MatchupListbox.TabIndex = 5;
            // 
            // TeamOneName
            // 
            TeamOneName.AutoSize = true;
            TeamOneName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TeamOneName.ForeColor = Color.FromArgb(51, 153, 255);
            TeamOneName.Location = new Point(678, 220);
            TeamOneName.Name = "TeamOneName";
            TeamOneName.Padding = new Padding(0, 5, 0, 5);
            TeamOneName.Size = new Size(161, 42);
            TeamOneName.TabIndex = 2;
            TeamOneName.Text = "<Team One>";
            // 
            // TeamOneScore
            // 
            TeamOneScore.AutoSize = true;
            TeamOneScore.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TeamOneScore.ForeColor = Color.FromArgb(64, 64, 64);
            TeamOneScore.Location = new Point(678, 270);
            TeamOneScore.Name = "TeamOneScore";
            TeamOneScore.Padding = new Padding(0, 5, 0, 5);
            TeamOneScore.Size = new Size(59, 35);
            TeamOneScore.TabIndex = 2;
            TeamOneScore.Text = "Score";
            // 
            // TeamOneScoreValue
            // 
            TeamOneScoreValue.BackColor = Color.White;
            TeamOneScoreValue.BorderStyle = BorderStyle.FixedSingle;
            TeamOneScoreValue.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TeamOneScoreValue.Location = new Point(818, 270);
            TeamOneScoreValue.Margin = new Padding(5);
            TeamOneScoreValue.Name = "TeamOneScoreValue";
            TeamOneScoreValue.Size = new Size(100, 32);
            TeamOneScoreValue.TabIndex = 6;
            TeamOneScoreValue.TextAlign = HorizontalAlignment.Center;
            // 
            // TeamTwoName
            // 
            TeamTwoName.AutoSize = true;
            TeamTwoName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TeamTwoName.ForeColor = Color.FromArgb(51, 153, 255);
            TeamTwoName.Location = new Point(678, 370);
            TeamTwoName.Name = "TeamTwoName";
            TeamTwoName.Padding = new Padding(0, 5, 0, 5);
            TeamTwoName.Size = new Size(162, 42);
            TeamTwoName.TabIndex = 2;
            TeamTwoName.Text = "<Team Two>";
            // 
            // TeamTwoScore
            // 
            TeamTwoScore.AutoSize = true;
            TeamTwoScore.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TeamTwoScore.ForeColor = Color.FromArgb(64, 64, 64);
            TeamTwoScore.Location = new Point(678, 420);
            TeamTwoScore.Name = "TeamTwoScore";
            TeamTwoScore.Padding = new Padding(0, 5, 0, 5);
            TeamTwoScore.Size = new Size(59, 35);
            TeamTwoScore.TabIndex = 2;
            TeamTwoScore.Text = "Score";
            // 
            // TeamTwoScoreValue
            // 
            TeamTwoScoreValue.BackColor = Color.White;
            TeamTwoScoreValue.BorderStyle = BorderStyle.FixedSingle;
            TeamTwoScoreValue.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TeamTwoScoreValue.Location = new Point(818, 420);
            TeamTwoScoreValue.Margin = new Padding(5);
            TeamTwoScoreValue.Name = "TeamTwoScoreValue";
            TeamTwoScoreValue.Size = new Size(100, 32);
            TeamTwoScoreValue.TabIndex = 6;
            TeamTwoScoreValue.TextAlign = HorizontalAlignment.Center;
            // 
            // VsLabel
            // 
            VsLabel.AutoSize = true;
            VsLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            VsLabel.ForeColor = Color.FromArgb(128, 128, 128);
            VsLabel.Location = new Point(838, 345);
            VsLabel.Name = "VsLabel";
            VsLabel.Size = new Size(35, 30);
            VsLabel.TabIndex = 2;
            VsLabel.Text = "vs";
            VsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ScoreButton
            // 
            ScoreButton.BackColor = Color.FromArgb(51, 153, 255);
            ScoreButton.Cursor = Cursors.Hand;
            ScoreButton.FlatAppearance.BorderSize = 0;
            ScoreButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 144, 255);
            ScoreButton.FlatStyle = FlatStyle.Flat;
            ScoreButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ScoreButton.ForeColor = Color.White;
            ScoreButton.Location = new Point(678, 480);
            ScoreButton.Name = "ScoreButton";
            ScoreButton.Padding = new Padding(5);
            ScoreButton.Size = new Size(240, 45);
            ScoreButton.TabIndex = 7;
            ScoreButton.Text = "Update Score";
            ScoreButton.UseVisualStyleBackColor = false;
            // 
            // TournamentViewerForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(945, 600);
            Controls.Add(ScoreButton);
            Controls.Add(TeamTwoScoreValue);
            Controls.Add(TeamOneScoreValue);
            Controls.Add(MatchupListbox);
            Controls.Add(UnplayedOnlyCheckbox);
            Controls.Add(RoundDropDown);
            Controls.Add(TeamTwoScore);
            Controls.Add(TeamOneScore);
            Controls.Add(TeamTwoName);
            Controls.Add(VsLabel);
            Controls.Add(TeamOneName);
            Controls.Add(RoundLabel);
            Controls.Add(TournamentName);
            Controls.Add(TournamentLabel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6, 4, 6, 4);
            MaximizeBox = false;
            MinimumSize = new Size(850, 600);
            Name = "TournamentViewerForm";
            Padding = new Padding(30);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tournament Viewer";
            Load += TournamentViewerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TournamentLabel;
        private Label TournamentName;
        private Label RoundLabel;
        private ComboBox RoundDropDown;
        private CheckBox UnplayedOnlyCheckbox;
        private ListBox MatchupListbox;
        private Label TeamOneName;
        private Label TeamOneScore;
        private TextBox TeamOneScoreValue;
        private Label TeamTwoName;
        private Label TeamTwoScore;
        private TextBox TeamTwoScoreValue;
        private Label VsLabel;
        private Button ScoreButton;
    }
}
