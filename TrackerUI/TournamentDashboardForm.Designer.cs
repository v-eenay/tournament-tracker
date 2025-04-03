namespace TrackerUI
{
    partial class TournamentDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentDashboardForm));
            TournamentDashboardLabel = new Label();
            LoadExistingTournamentLabel = new Label();
            LoadExistingTournamentDropDown = new ComboBox();
            LoadTournamentButton = new Button();
            CreateTournamentButton = new Button();
            SuspendLayout();
            // 
            // TournamentDashboardLabel
            // 
            TournamentDashboardLabel.AutoSize = true;
            TournamentDashboardLabel.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            TournamentDashboardLabel.ForeColor = Color.FromArgb(51, 153, 255);
            TournamentDashboardLabel.Location = new Point(32, 24);
            TournamentDashboardLabel.Name = "TournamentDashboardLabel";
            TournamentDashboardLabel.Size = new Size(501, 59);
            TournamentDashboardLabel.TabIndex = 0;
            TournamentDashboardLabel.Text = "Tournament Dashboard";
            // 
            // LoadExistingTournamentLabel
            // 
            LoadExistingTournamentLabel.AutoSize = true;
            LoadExistingTournamentLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            LoadExistingTournamentLabel.ForeColor = Color.FromArgb(51, 153, 255);
            LoadExistingTournamentLabel.Location = new Point(107, 120);
            LoadExistingTournamentLabel.Name = "LoadExistingTournamentLabel";
            LoadExistingTournamentLabel.Size = new Size(351, 37);
            LoadExistingTournamentLabel.TabIndex = 1;
            LoadExistingTournamentLabel.Text = "Load Existing Tournament";
            // 
            // LoadExistingTournamentDropDown
            // 
            LoadExistingTournamentDropDown.BackColor = Color.WhiteSmoke;
            LoadExistingTournamentDropDown.FlatStyle = FlatStyle.Flat;
            LoadExistingTournamentDropDown.Font = new Font("Segoe UI", 14F);
            LoadExistingTournamentDropDown.FormattingEnabled = true;
            LoadExistingTournamentDropDown.Location = new Point(82, 180);
            LoadExistingTournamentDropDown.Name = "LoadExistingTournamentDropDown";
            LoadExistingTournamentDropDown.Size = new Size(400, 33);
            LoadExistingTournamentDropDown.TabIndex = 2;
            // 
            // LoadTournamentButton
            // 
            LoadTournamentButton.BackColor = Color.FromArgb(51, 153, 255);
            LoadTournamentButton.Cursor = Cursors.Hand;
            LoadTournamentButton.FlatAppearance.BorderSize = 0;
            LoadTournamentButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 122, 204);
            LoadTournamentButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(73, 162, 255);
            LoadTournamentButton.FlatStyle = FlatStyle.Flat;
            LoadTournamentButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LoadTournamentButton.ForeColor = Color.White;
            LoadTournamentButton.Location = new Point(132, 240);
            LoadTournamentButton.Name = "LoadTournamentButton";
            LoadTournamentButton.Size = new Size(300, 50);
            LoadTournamentButton.TabIndex = 3;
            LoadTournamentButton.Text = "Load Tournament";
            LoadTournamentButton.UseVisualStyleBackColor = false;
            // 
            // CreateTournamentButton
            // 
            CreateTournamentButton.BackColor = Color.FromArgb(51, 153, 255);
            CreateTournamentButton.Cursor = Cursors.Hand;
            CreateTournamentButton.FlatAppearance.BorderSize = 0;
            CreateTournamentButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 122, 204);
            CreateTournamentButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(73, 162, 255);
            CreateTournamentButton.FlatStyle = FlatStyle.Flat;
            CreateTournamentButton.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            CreateTournamentButton.ForeColor = Color.White;
            CreateTournamentButton.Location = new Point(107, 340);
            CreateTournamentButton.Name = "CreateTournamentButton";
            CreateTournamentButton.Size = new Size(350, 80);
            CreateTournamentButton.TabIndex = 4;
            CreateTournamentButton.Text = "Create Tournament";
            CreateTournamentButton.UseVisualStyleBackColor = false;
            // 
            // TournamentDashboardForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(564, 450);
            Controls.Add(CreateTournamentButton);
            Controls.Add(LoadTournamentButton);
            Controls.Add(LoadExistingTournamentDropDown);
            Controls.Add(LoadExistingTournamentLabel);
            Controls.Add(TournamentDashboardLabel);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "TournamentDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tournament Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label TournamentDashboardLabel;
        private Label LoadExistingTournamentLabel;
        private ComboBox LoadExistingTournamentDropDown;
        private Button LoadTournamentButton;
        private Button CreateTournamentButton;

        #endregion
    }
}
