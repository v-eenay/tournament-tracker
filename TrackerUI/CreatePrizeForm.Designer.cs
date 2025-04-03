namespace TrackerUI
{
    partial class CreatePrizeForm
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
            CreatePrizeLabel = new Label();
            PlaceNumberLabel = new Label();
            PlaceNumberValue = new TextBox();
            PlaceNameLabel = new Label();
            PlaceNameValue = new TextBox();
            PrizeAmountLabel = new Label();
            PrizeAmountValue = new TextBox();
            PrizePercentageLabel = new Label();
            PrizePercentageValue = new TextBox();
            OrLabel = new Label();
            CreatePrizeButton = new Button();
            SuspendLayout();
            // 
            // CreatePrizeLabel
            // 
            CreatePrizeLabel.AutoSize = true;
            CreatePrizeLabel.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point);
            CreatePrizeLabel.ForeColor = Color.FromArgb(51, 153, 255);
            CreatePrizeLabel.Location = new Point(50, 30);
            CreatePrizeLabel.Name = "CreatePrizeLabel";
            CreatePrizeLabel.Size = new Size(276, 59);
            CreatePrizeLabel.TabIndex = 0;
            CreatePrizeLabel.Text = "Create Prize";
            // 
            // PlaceNumberLabel
            // 
            PlaceNumberLabel.AutoSize = true;
            PlaceNumberLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            PlaceNumberLabel.ForeColor = Color.FromArgb(51, 153, 255);
            PlaceNumberLabel.Location = new Point(50, 120);
            PlaceNumberLabel.Name = "PlaceNumberLabel";
            PlaceNumberLabel.Size = new Size(144, 25);
            PlaceNumberLabel.TabIndex = 1;
            PlaceNumberLabel.Text = "Place Number:";
            // 
            // PlaceNumberValue
            // 
            PlaceNumberValue.BorderStyle = BorderStyle.FixedSingle;
            PlaceNumberValue.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            PlaceNumberValue.Location = new Point(250, 120);
            PlaceNumberValue.Name = "PlaceNumberValue";
            PlaceNumberValue.Size = new Size(150, 32);
            PlaceNumberValue.TabIndex = 2;
            // 
            // PlaceNameLabel
            // 
            PlaceNameLabel.AutoSize = true;
            PlaceNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            PlaceNameLabel.ForeColor = Color.FromArgb(51, 153, 255);
            PlaceNameLabel.Location = new Point(50, 180);
            PlaceNameLabel.Name = "PlaceNameLabel";
            PlaceNameLabel.Size = new Size(124, 25);
            PlaceNameLabel.TabIndex = 3;
            PlaceNameLabel.Text = "Place Name:";
            // 
            // PlaceNameValue
            // 
            PlaceNameValue.BorderStyle = BorderStyle.FixedSingle;
            PlaceNameValue.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            PlaceNameValue.Location = new Point(250, 180);
            PlaceNameValue.Name = "PlaceNameValue";
            PlaceNameValue.Size = new Size(150, 32);
            PlaceNameValue.TabIndex = 4;
            // 
            // PrizeAmountLabel
            // 
            PrizeAmountLabel.AutoSize = true;
            PrizeAmountLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            PrizeAmountLabel.ForeColor = Color.FromArgb(51, 153, 255);
            PrizeAmountLabel.Location = new Point(50, 240);
            PrizeAmountLabel.Name = "PrizeAmountLabel";
            PrizeAmountLabel.Size = new Size(139, 25);
            PrizeAmountLabel.TabIndex = 5;
            PrizeAmountLabel.Text = "Prize Amount:";
            // 
            // PrizeAmountValue
            // 
            PrizeAmountValue.BorderStyle = BorderStyle.FixedSingle;
            PrizeAmountValue.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            PrizeAmountValue.Location = new Point(250, 240);
            PrizeAmountValue.Name = "PrizeAmountValue";
            PrizeAmountValue.Size = new Size(150, 32);
            PrizeAmountValue.TabIndex = 6;
            PrizeAmountValue.Text = "0";
            // 
            // OrLabel
            // 
            OrLabel.AutoSize = true;
            OrLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            OrLabel.ForeColor = Color.FromArgb(51, 153, 255);
            OrLabel.Location = new Point(200, 300);
            OrLabel.Name = "OrLabel";
            OrLabel.Size = new Size(48, 25);
            OrLabel.TabIndex = 7;
            OrLabel.Text = "-or-";
            // 
            // PrizePercentageLabel
            // 
            PrizePercentageLabel.AutoSize = true;
            PrizePercentageLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            PrizePercentageLabel.ForeColor = Color.FromArgb(51, 153, 255);
            PrizePercentageLabel.Location = new Point(50, 360);
            PrizePercentageLabel.Name = "PrizePercentageLabel";
            PrizePercentageLabel.Size = new Size(167, 25);
            PrizePercentageLabel.TabIndex = 8;
            PrizePercentageLabel.Text = "Prize Percentage:";
            // 
            // PrizePercentageValue
            // 
            PrizePercentageValue.BorderStyle = BorderStyle.FixedSingle;
            PrizePercentageValue.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            PrizePercentageValue.Location = new Point(250, 360);
            PrizePercentageValue.Name = "PrizePercentageValue";
            PrizePercentageValue.Size = new Size(150, 32);
            PrizePercentageValue.TabIndex = 9;
            PrizePercentageValue.Text = "0";
            // 
            // CreatePrizeButton
            // 
            CreatePrizeButton.BackColor = Color.FromArgb(51, 153, 255);
            CreatePrizeButton.FlatStyle = FlatStyle.Flat;
            CreatePrizeButton.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            CreatePrizeButton.ForeColor = Color.White;
            CreatePrizeButton.Location = new Point(75, 440);
            CreatePrizeButton.Name = "CreatePrizeButton";
            CreatePrizeButton.Size = new Size(300, 60);
            CreatePrizeButton.TabIndex = 10;
            CreatePrizeButton.Text = "Create Prize";
            CreatePrizeButton.UseVisualStyleBackColor = false;
            CreatePrizeButton.FlatAppearance.BorderSize = 0;
            CreatePrizeButton.Cursor = Cursors.Hand;
            CreatePrizeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(73, 162, 255);
            CreatePrizeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 122, 204);
            // 
            // CreatePrizeForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(450, 540);
            Controls.Add(CreatePrizeButton);
            Controls.Add(PrizePercentageValue);
            Controls.Add(PrizePercentageLabel);
            Controls.Add(OrLabel);
            Controls.Add(PrizeAmountValue);
            Controls.Add(PrizeAmountLabel);
            Controls.Add(PlaceNameValue);
            Controls.Add(PlaceNameLabel);
            Controls.Add(PlaceNumberValue);
            Controls.Add(PlaceNumberLabel);
            Controls.Add(CreatePrizeLabel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "CreatePrizeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Prize";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label CreatePrizeLabel;
        private Label PlaceNumberLabel;
        private TextBox PlaceNumberValue;
        private Label PlaceNameLabel;
        private TextBox PlaceNameValue;
        private Label PrizeAmountLabel;
        private TextBox PrizeAmountValue;
        private Label OrLabel;
        private Label PrizePercentageLabel;
        private TextBox PrizePercentageValue;
        private Button CreatePrizeButton;

        #endregion
    }
}
