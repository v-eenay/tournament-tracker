namespace TrackerUI
{
    partial class CreateTeamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTeamForm));
            CreateTeamLabel = new Label();
            TeamNameLabel = new Label();
            TeamNameValue = new TextBox();
            SelectTeamMemberLabel = new Label();
            AddNewMemberGroupBox = new GroupBox();
            CreateMemberButton = new Button();
            CellphoneValue = new TextBox();
            CellphoneLabel = new Label();
            EmailValue = new TextBox();
            EmailLabel = new Label();
            LastNameValue = new TextBox();
            LastNameLabel = new Label();
            FirstNameValue = new TextBox();
            FirstNameLabel = new Label();
            SelectTeamMemberDropDown = new ComboBox();
            AddTeamMemberButton = new Button();
            TeamMembersListBox = new ListBox();
            DeleteSelectedMemberButton = new Button();
            CreateTeamButton = new Button();
            AddNewMemberGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // CreateTeamLabel
            // 
            CreateTeamLabel.AutoSize = true;
            CreateTeamLabel.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            CreateTeamLabel.ForeColor = Color.FromArgb(51, 153, 255);
            CreateTeamLabel.Location = new Point(50, 30);
            CreateTeamLabel.Name = "CreateTeamLabel";
            CreateTeamLabel.Size = new Size(273, 59);
            CreateTeamLabel.TabIndex = 0;
            CreateTeamLabel.Text = "Create Team";
            // 
            // TeamNameLabel
            // 
            TeamNameLabel.AutoSize = true;
            TeamNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            TeamNameLabel.ForeColor = Color.FromArgb(51, 153, 255);
            TeamNameLabel.Location = new Point(50, 110);
            TeamNameLabel.Name = "TeamNameLabel";
            TeamNameLabel.Size = new Size(120, 25);
            TeamNameLabel.TabIndex = 1;
            TeamNameLabel.Text = "Team Name:";
            // 
            // TeamNameValue
            // 
            TeamNameValue.BorderStyle = BorderStyle.FixedSingle;
            TeamNameValue.Font = new Font("Segoe UI", 14F);
            TeamNameValue.Location = new Point(50, 140);
            TeamNameValue.Name = "TeamNameValue";
            TeamNameValue.Size = new Size(400, 32);
            TeamNameValue.TabIndex = 2;
            // 
            // SelectTeamMemberLabel
            // 
            SelectTeamMemberLabel.AutoSize = true;
            SelectTeamMemberLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            SelectTeamMemberLabel.ForeColor = Color.FromArgb(51, 153, 255);
            SelectTeamMemberLabel.Location = new Point(50, 190);
            SelectTeamMemberLabel.Name = "SelectTeamMemberLabel";
            SelectTeamMemberLabel.Size = new Size(201, 25);
            SelectTeamMemberLabel.TabIndex = 3;
            SelectTeamMemberLabel.Text = "Select Team Member:";
            // 
            // AddNewMemberGroupBox
            // 
            AddNewMemberGroupBox.Controls.Add(CreateMemberButton);
            AddNewMemberGroupBox.Controls.Add(CellphoneValue);
            AddNewMemberGroupBox.Controls.Add(CellphoneLabel);
            AddNewMemberGroupBox.Controls.Add(EmailValue);
            AddNewMemberGroupBox.Controls.Add(EmailLabel);
            AddNewMemberGroupBox.Controls.Add(LastNameValue);
            AddNewMemberGroupBox.Controls.Add(LastNameLabel);
            AddNewMemberGroupBox.Controls.Add(FirstNameValue);
            AddNewMemberGroupBox.Controls.Add(FirstNameLabel);
            AddNewMemberGroupBox.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            AddNewMemberGroupBox.ForeColor = Color.FromArgb(51, 153, 255);
            AddNewMemberGroupBox.Location = new Point(50, 320);
            AddNewMemberGroupBox.Name = "AddNewMemberGroupBox";
            AddNewMemberGroupBox.Size = new Size(400, 320);
            AddNewMemberGroupBox.TabIndex = 4;
            AddNewMemberGroupBox.TabStop = false;
            AddNewMemberGroupBox.Text = "Add New Member";
            // 
            // CreateMemberButton
            // 
            CreateMemberButton.BackColor = Color.FromArgb(51, 153, 255);
            CreateMemberButton.Cursor = Cursors.Hand;
            CreateMemberButton.FlatAppearance.BorderSize = 0;
            CreateMemberButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 122, 204);
            CreateMemberButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(73, 162, 255);
            CreateMemberButton.FlatStyle = FlatStyle.Flat;
            CreateMemberButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            CreateMemberButton.ForeColor = Color.White;
            CreateMemberButton.Location = new Point(75, 260);
            CreateMemberButton.Name = "CreateMemberButton";
            CreateMemberButton.Size = new Size(250, 40);
            CreateMemberButton.TabIndex = 16;
            CreateMemberButton.Text = "Create Member";
            CreateMemberButton.UseVisualStyleBackColor = false;
            // 
            // CellphoneValue
            // 
            CellphoneValue.BorderStyle = BorderStyle.FixedSingle;
            CellphoneValue.Font = new Font("Segoe UI", 14F);
            CellphoneValue.Location = new Point(150, 200);
            CellphoneValue.Name = "CellphoneValue";
            CellphoneValue.Size = new Size(220, 32);
            CellphoneValue.TabIndex = 15;
            // 
            // CellphoneLabel
            // 
            CellphoneLabel.AutoSize = true;
            CellphoneLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            CellphoneLabel.ForeColor = Color.FromArgb(51, 153, 255);
            CellphoneLabel.Location = new Point(20, 200);
            CellphoneLabel.Name = "CellphoneLabel";
            CellphoneLabel.Size = new Size(106, 25);
            CellphoneLabel.TabIndex = 14;
            CellphoneLabel.Text = "Cellphone:";
            // 
            // EmailValue
            // 
            EmailValue.BorderStyle = BorderStyle.FixedSingle;
            EmailValue.Font = new Font("Segoe UI", 14F);
            EmailValue.Location = new Point(150, 150);
            EmailValue.Name = "EmailValue";
            EmailValue.Size = new Size(220, 32);
            EmailValue.TabIndex = 13;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            EmailLabel.ForeColor = Color.FromArgb(51, 153, 255);
            EmailLabel.Location = new Point(20, 150);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(64, 25);
            EmailLabel.TabIndex = 12;
            EmailLabel.Text = "Email:";
            // 
            // LastNameValue
            // 
            LastNameValue.BorderStyle = BorderStyle.FixedSingle;
            LastNameValue.Font = new Font("Segoe UI", 14F);
            LastNameValue.Location = new Point(150, 100);
            LastNameValue.Name = "LastNameValue";
            LastNameValue.Size = new Size(220, 32);
            LastNameValue.TabIndex = 11;
            // 
            // LastNameLabel
            // 
            LastNameLabel.AutoSize = true;
            LastNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            LastNameLabel.ForeColor = Color.FromArgb(51, 153, 255);
            LastNameLabel.Location = new Point(20, 100);
            LastNameLabel.Name = "LastNameLabel";
            LastNameLabel.Size = new Size(109, 25);
            LastNameLabel.TabIndex = 10;
            LastNameLabel.Text = "Last Name:";
            // 
            // FirstNameValue
            // 
            FirstNameValue.BorderStyle = BorderStyle.FixedSingle;
            FirstNameValue.Font = new Font("Segoe UI", 14F);
            FirstNameValue.Location = new Point(150, 50);
            FirstNameValue.Name = "FirstNameValue";
            FirstNameValue.Size = new Size(220, 32);
            FirstNameValue.TabIndex = 9;
            // 
            // FirstNameLabel
            // 
            FirstNameLabel.AutoSize = true;
            FirstNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            FirstNameLabel.ForeColor = Color.FromArgb(51, 153, 255);
            FirstNameLabel.Location = new Point(20, 50);
            FirstNameLabel.Name = "FirstNameLabel";
            FirstNameLabel.Size = new Size(112, 25);
            FirstNameLabel.TabIndex = 8;
            FirstNameLabel.Text = "First Name:";
            // 
            // SelectTeamMemberDropDown
            // 
            SelectTeamMemberDropDown.BackColor = Color.WhiteSmoke;
            SelectTeamMemberDropDown.FlatStyle = FlatStyle.Flat;
            SelectTeamMemberDropDown.Font = new Font("Segoe UI", 14F);
            SelectTeamMemberDropDown.FormattingEnabled = true;
            SelectTeamMemberDropDown.Location = new Point(50, 220);
            SelectTeamMemberDropDown.Name = "SelectTeamMemberDropDown";
            SelectTeamMemberDropDown.Size = new Size(400, 33);
            SelectTeamMemberDropDown.TabIndex = 5;
            // 
            // AddTeamMemberButton
            // 
            AddTeamMemberButton.BackColor = Color.FromArgb(51, 153, 255);
            AddTeamMemberButton.Cursor = Cursors.Hand;
            AddTeamMemberButton.FlatAppearance.BorderSize = 0;
            AddTeamMemberButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 122, 204);
            AddTeamMemberButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(73, 162, 255);
            AddTeamMemberButton.FlatStyle = FlatStyle.Flat;
            AddTeamMemberButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            AddTeamMemberButton.ForeColor = Color.White;
            AddTeamMemberButton.Location = new Point(125, 270);
            AddTeamMemberButton.Name = "AddTeamMemberButton";
            AddTeamMemberButton.Size = new Size(250, 35);
            AddTeamMemberButton.TabIndex = 6;
            AddTeamMemberButton.Text = "Add Member";
            AddTeamMemberButton.UseVisualStyleBackColor = false;
            // 
            // TeamMembersListBox
            // 
            TeamMembersListBox.BackColor = Color.WhiteSmoke;
            TeamMembersListBox.BorderStyle = BorderStyle.FixedSingle;
            TeamMembersListBox.Font = new Font("Segoe UI", 12F);
            TeamMembersListBox.FormattingEnabled = true;
            TeamMembersListBox.ItemHeight = 21;
            TeamMembersListBox.Location = new Point(500, 140);
            TeamMembersListBox.Name = "TeamMembersListBox";
            TeamMembersListBox.Size = new Size(350, 380);
            TeamMembersListBox.TabIndex = 7;
            // 
            // DeleteSelectedMemberButton
            // 
            DeleteSelectedMemberButton.BackColor = Color.FromArgb(51, 153, 255);
            DeleteSelectedMemberButton.Cursor = Cursors.Hand;
            DeleteSelectedMemberButton.FlatAppearance.BorderSize = 0;
            DeleteSelectedMemberButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 122, 204);
            DeleteSelectedMemberButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(73, 162, 255);
            DeleteSelectedMemberButton.FlatStyle = FlatStyle.Flat;
            DeleteSelectedMemberButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            DeleteSelectedMemberButton.ForeColor = Color.White;
            DeleteSelectedMemberButton.Location = new Point(870, 140);
            DeleteSelectedMemberButton.Name = "DeleteSelectedMemberButton";
            DeleteSelectedMemberButton.Size = new Size(112, 73);
            DeleteSelectedMemberButton.TabIndex = 8;
            DeleteSelectedMemberButton.Text = "Delete Selected";
            DeleteSelectedMemberButton.UseVisualStyleBackColor = false;
            // 
            // CreateTeamButton
            // 
            CreateTeamButton.BackColor = Color.FromArgb(51, 153, 255);
            CreateTeamButton.Cursor = Cursors.Hand;
            CreateTeamButton.FlatAppearance.BorderSize = 0;
            CreateTeamButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 122, 204);
            CreateTeamButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(73, 162, 255);
            CreateTeamButton.FlatStyle = FlatStyle.Flat;
            CreateTeamButton.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            CreateTeamButton.ForeColor = Color.White;
            CreateTeamButton.Location = new Point(262, 660);
            CreateTeamButton.Name = "CreateTeamButton";
            CreateTeamButton.Size = new Size(500, 70);
            CreateTeamButton.TabIndex = 14;
            CreateTeamButton.Text = "Create Team";
            CreateTeamButton.UseVisualStyleBackColor = false;
            // 
            // CreateTeamForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1024, 768);
            Controls.Add(CreateTeamButton);
            Controls.Add(DeleteSelectedMemberButton);
            Controls.Add(TeamMembersListBox);
            Controls.Add(AddTeamMemberButton);
            Controls.Add(SelectTeamMemberDropDown);
            Controls.Add(AddNewMemberGroupBox);
            Controls.Add(SelectTeamMemberLabel);
            Controls.Add(TeamNameValue);
            Controls.Add(TeamNameLabel);
            Controls.Add(CreateTeamLabel);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "CreateTeamForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Team";
            AddNewMemberGroupBox.ResumeLayout(false);
            AddNewMemberGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label CreateTeamLabel;
        private Label TeamNameLabel;
        private TextBox TeamNameValue;
        private Label SelectTeamMemberLabel;
        private GroupBox AddNewMemberGroupBox;
        private TextBox FirstNameValue;
        private Label FirstNameLabel;
        private TextBox LastNameValue;
        private Label LastNameLabel;
        private TextBox EmailValue;
        private Label EmailLabel;
        private TextBox CellphoneValue;
        private Label CellphoneLabel;
        private Button CreateMemberButton;
        private ComboBox SelectTeamMemberDropDown;
        private Button AddTeamMemberButton;
        private ListBox TeamMembersListBox;
        private Button DeleteSelectedMemberButton;
        private Button CreateTeamButton;

        #endregion
    }
}
