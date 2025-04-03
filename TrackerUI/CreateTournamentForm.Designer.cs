namespace TrackerUI
{
    partial class CreateTournamentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTournamentForm));
            CreateTournamentLabel = new Label();
            TournamentNameLabel = new Label();
            TournamentNameValue = new TextBox();
            SelectTeamLabel = new Label();
            CreateNewTeamLink = new LinkLabel();
            SelectTeamDropDown = new ComboBox();
            AddTeamButton = new Button();
            CreatePrizeButton = new Button();
            TeamPlayersLabel = new Label();
            TournamentPlayersListBox = new ListBox();
            DeleteSelectedPlayerButton = new Button();
            PrizesLabel = new Label();
            PrizesListBox = new ListBox();
            DeleteSelectedPrizeButton = new Button();
            CreateTournamentButton = new Button();
            SuspendLayout();
            // 
            // CreateTournamentLabel
            // 
            CreateTournamentLabel.AutoSize = true;
            CreateTournamentLabel.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point);
            CreateTournamentLabel.ForeColor = Color.FromArgb(51, 153, 255);
            CreateTournamentLabel.Location = new Point(50, 30);
            CreateTournamentLabel.Name = "CreateTournamentLabel";
            CreateTournamentLabel.Size = new Size(403, 59);
            CreateTournamentLabel.TabIndex = 0;
            CreateTournamentLabel.Text = "Create Tournament";
            // 
            // TournamentNameLabel
            // 
            TournamentNameLabel.AutoSize = true;
            TournamentNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            TournamentNameLabel.ForeColor = Color.FromArgb(51, 153, 255);
            TournamentNameLabel.Location = new Point(50, 120);
            TournamentNameLabel.Name = "TournamentNameLabel";
            TournamentNameLabel.Size = new Size(186, 25);
            TournamentNameLabel.TabIndex = 1;
            TournamentNameLabel.Text = "Tournament Name";
            // 
            // TournamentNameValue
            // 
            TournamentNameValue.BorderStyle = BorderStyle.FixedSingle;
            TournamentNameValue.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            TournamentNameValue.Location = new Point(50, 150);
            TournamentNameValue.Name = "TournamentNameValue";
            TournamentNameValue.Size = new Size(350, 32);
            TournamentNameValue.TabIndex = 2;
            // 
            // SelectTeamLabel
            // 
            SelectTeamLabel.AutoSize = true;
            SelectTeamLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            SelectTeamLabel.ForeColor = Color.FromArgb(51, 153, 255);
            SelectTeamLabel.Location = new Point(50, 200);
            SelectTeamLabel.Name = "SelectTeamLabel";
            SelectTeamLabel.Size = new Size(123, 25);
            SelectTeamLabel.TabIndex = 3;
            SelectTeamLabel.Text = "Select Team";
            // 
            // CreateNewTeamLink
            // 
            CreateNewTeamLink.AutoSize = true;
            CreateNewTeamLink.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CreateNewTeamLink.Location = new Point(280, 205);
            CreateNewTeamLink.Name = "CreateNewTeamLink";
            CreateNewTeamLink.Size = new Size(120, 21);
            CreateNewTeamLink.TabIndex = 4;
            CreateNewTeamLink.TabStop = true;
            CreateNewTeamLink.Text = "Create New";
            // 
            // SelectTeamDropDown
            // 
            SelectTeamDropDown.FlatStyle = FlatStyle.Flat;
            SelectTeamDropDown.BackColor = Color.WhiteSmoke;
            SelectTeamDropDown.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            SelectTeamDropDown.FormattingEnabled = true;
            SelectTeamDropDown.Location = new Point(50, 230);
            SelectTeamDropDown.Name = "SelectTeamDropDown";
            SelectTeamDropDown.Size = new Size(350, 33);
            SelectTeamDropDown.TabIndex = 5;
            // 
            // AddTeamButton
            // 
            AddTeamButton.BackColor = Color.FromArgb(51, 153, 255);
            AddTeamButton.FlatStyle = FlatStyle.Flat;
            AddTeamButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            AddTeamButton.ForeColor = Color.White;
            AddTeamButton.Location = new Point(50, 280);
            AddTeamButton.Name = "AddTeamButton";
            AddTeamButton.Size = new Size(165, 40);
            AddTeamButton.TabIndex = 6;
            AddTeamButton.Text = "Add Team";
            AddTeamButton.UseVisualStyleBackColor = false;
            AddTeamButton.FlatAppearance.BorderSize = 0;
            AddTeamButton.Cursor = Cursors.Hand;
            // 
            // CreatePrizeButton
            // 
            CreatePrizeButton.BackColor = Color.FromArgb(51, 153, 255);
            CreatePrizeButton.FlatStyle = FlatStyle.Flat;
            CreatePrizeButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CreatePrizeButton.ForeColor = Color.White;
            CreatePrizeButton.Location = new Point(235, 280);
            CreatePrizeButton.Name = "CreatePrizeButton";
            CreatePrizeButton.Size = new Size(165, 40);
            CreatePrizeButton.TabIndex = 7;
            CreatePrizeButton.Text = "Create Prize";
            CreatePrizeButton.UseVisualStyleBackColor = false;
            CreatePrizeButton.FlatAppearance.BorderSize = 0;
            CreatePrizeButton.Cursor = Cursors.Hand;
            // 
            // TeamPlayersLabel
            // 
            TeamPlayersLabel.AutoSize = true;
            TeamPlayersLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            TeamPlayersLabel.ForeColor = Color.FromArgb(51, 153, 255);
            TeamPlayersLabel.Location = new Point(500, 30);
            TeamPlayersLabel.Name = "TeamPlayersLabel";
            TeamPlayersLabel.Size = new Size(187, 37);
            TeamPlayersLabel.TabIndex = 8;
            TeamPlayersLabel.Text = "Team/Players";
            // 
            // TournamentPlayersListBox
            // 
            TournamentPlayersListBox.BorderStyle = BorderStyle.FixedSingle;
            TournamentPlayersListBox.BackColor = Color.WhiteSmoke;
            TournamentPlayersListBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TournamentPlayersListBox.FormattingEnabled = true;
            TournamentPlayersListBox.ItemHeight = 21;
            TournamentPlayersListBox.Location = new Point(500, 80);
            TournamentPlayersListBox.Name = "TournamentPlayersListBox";
            TournamentPlayersListBox.Size = new Size(350, 147);
            TournamentPlayersListBox.TabIndex = 9;
            // 
            // DeleteSelectedPlayerButton
            // 
            DeleteSelectedPlayerButton.BackColor = Color.FromArgb(51, 153, 255);
            DeleteSelectedPlayerButton.FlatStyle = FlatStyle.Flat;
            DeleteSelectedPlayerButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            DeleteSelectedPlayerButton.ForeColor = Color.White;
            DeleteSelectedPlayerButton.Location = new Point(870, 80);
            DeleteSelectedPlayerButton.Name = "DeleteSelectedPlayerButton";
            DeleteSelectedPlayerButton.Size = new Size(112, 73);
            DeleteSelectedPlayerButton.TabIndex = 10;
            DeleteSelectedPlayerButton.Text = "Delete Selected";
            DeleteSelectedPlayerButton.UseVisualStyleBackColor = false;
            DeleteSelectedPlayerButton.FlatAppearance.BorderSize = 0;
            DeleteSelectedPlayerButton.Cursor = Cursors.Hand;
            // 
            // PrizesLabel
            // 
            PrizesLabel.AutoSize = true;
            PrizesLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            PrizesLabel.ForeColor = Color.FromArgb(51, 153, 255);
            PrizesLabel.Location = new Point(500, 250);
            PrizesLabel.Name = "PrizesLabel";
            PrizesLabel.Size = new Size(187, 37);
            PrizesLabel.TabIndex = 11;
            PrizesLabel.Text = "Prizes";
            // 
            // PrizesListBox
            // 
            PrizesListBox.BorderStyle = BorderStyle.FixedSingle;
            PrizesListBox.BackColor = Color.WhiteSmoke;
            PrizesListBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PrizesListBox.FormattingEnabled = true;
            PrizesListBox.ItemHeight = 21;
            PrizesListBox.Location = new Point(500, 300);
            PrizesListBox.Name = "PrizesListBox";
            PrizesListBox.Size = new Size(350, 147);
            PrizesListBox.TabIndex = 12;
            // 
            // DeleteSelectedPrizeButton
            // 
            DeleteSelectedPrizeButton.BackColor = Color.FromArgb(51, 153, 255);
            DeleteSelectedPrizeButton.FlatStyle = FlatStyle.Flat;
            DeleteSelectedPrizeButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            DeleteSelectedPrizeButton.ForeColor = Color.White;
            DeleteSelectedPrizeButton.Location = new Point(870, 300);
            DeleteSelectedPrizeButton.Name = "DeleteSelectedPrizeButton";
            DeleteSelectedPrizeButton.Size = new Size(112, 73);
            DeleteSelectedPrizeButton.TabIndex = 13;
            DeleteSelectedPrizeButton.Text = "Delete Selected";
            DeleteSelectedPrizeButton.UseVisualStyleBackColor = false;
            DeleteSelectedPrizeButton.FlatAppearance.BorderSize = 0;
            DeleteSelectedPrizeButton.Cursor = Cursors.Hand;
            // 
            // CreateTournamentButton
            // 
            CreateTournamentButton.BackColor = Color.FromArgb(51, 153, 255);
            CreateTournamentButton.FlatStyle = FlatStyle.Flat;
            CreateTournamentButton.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            CreateTournamentButton.ForeColor = Color.White;
            CreateTournamentButton.Location = new Point(262, 480);
            CreateTournamentButton.Name = "CreateTournamentButton";
            CreateTournamentButton.Size = new Size(500, 70);
            CreateTournamentButton.TabIndex = 14;
            CreateTournamentButton.Text = "Create Tournament";
            CreateTournamentButton.UseVisualStyleBackColor = false;
            CreateTournamentButton.FlatAppearance.BorderSize = 0;
            CreateTournamentButton.Cursor = Cursors.Hand;
            CreateTournamentButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(73, 162, 255);
            CreateTournamentButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 122, 204);
            // 
            // CreateTournamentForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1024, 600);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(CreateTournamentButton);
            Controls.Add(DeleteSelectedPrizeButton);
            Controls.Add(PrizesListBox);
            Controls.Add(PrizesLabel);
            Controls.Add(DeleteSelectedPlayerButton);
            Controls.Add(TournamentPlayersListBox);
            Controls.Add(TeamPlayersLabel);
            Controls.Add(CreatePrizeButton);
            Controls.Add(AddTeamButton);
            Controls.Add(SelectTeamDropDown);
            Controls.Add(CreateNewTeamLink);
            Controls.Add(SelectTeamLabel);
            Controls.Add(TournamentNameValue);
            Controls.Add(TournamentNameLabel);
            Controls.Add(CreateTournamentLabel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimumSize = new Size(1024, 600);
            Name = "CreateTournamentForm";
            Padding = new Padding(30);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Tournament";
            ResumeLayout(false);
            PerformLayout();
            SuspendLayout();
            // 
            // CreateTournamentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateTournamentForm";
            Text = "CreateTournamentForm";
            ResumeLayout(false);
        }

        #endregion

        private Label CreateTournamentLabel;
        private Label TournamentNameLabel;
        private TextBox TournamentNameValue;
        private Label SelectTeamLabel;
        private LinkLabel CreateNewTeamLink;
        private ComboBox SelectTeamDropDown;
        private Button AddTeamButton;
        private Button CreatePrizeButton;
        private Label TeamPlayersLabel;
        private ListBox TournamentPlayersListBox;
        private Button DeleteSelectedPlayerButton;
        private Label PrizesLabel;
        private ListBox PrizesListBox;
        private Button DeleteSelectedPrizeButton;
        private Button CreateTournamentButton;
    }
}