/*
 * CAR SYSTEM v1.0 - Handoff Edition
 * ──────────────────────────────────
 * Based on: Rent_Auto_Desktop (MIT License)
 * Original: Clarence Sabangan (Yurei21) / Provider: chan dev
 * GitHub:   https://github.com/workingts/carsystem
 */
namespace CAR_SYSTEM
{
    partial class ReportViewer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            topPanel   = new Panel();
            rbCar      = new RadioButton();
            rbBike     = new RadioButton();
            lblPeriod  = new Label();
            cmbPeriod  = new ComboBox();
            lblStart   = new Label();
            dtpStart   = new DateTimePicker();
            lblTilde   = new Label();
            dtpEnd     = new DateTimePicker();
            btnSearch  = new Button();
            btnPrint   = new Button();
            dgvSummary = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSummary).BeginInit();
            topPanel.SuspendLayout();
            SuspendLayout();

            // rbCar
            rbCar.AutoSize  = true;
            rbCar.Checked   = true;
            rbCar.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            rbCar.ForeColor = Color.LightSkyBlue;
            rbCar.Location  = new Point(12, 15);
            rbCar.Name      = "rbCar";
            rbCar.TabIndex  = 1;
            rbCar.TabStop   = true;
            rbCar.Text      = "자동차";
            rbCar.UseVisualStyleBackColor = false;
            rbCar.BackColor = Color.Transparent;

            // rbBike
            rbBike.AutoSize  = true;
            rbBike.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            rbBike.ForeColor = Color.LightSkyBlue;
            rbBike.Location  = new Point(90, 15);
            rbBike.Name      = "rbBike";
            rbBike.TabIndex  = 2;
            rbBike.Text      = "이  륜";
            rbBike.UseVisualStyleBackColor = false;
            rbBike.BackColor = Color.Transparent;

            // lblPeriod
            lblPeriod.AutoSize  = true;
            lblPeriod.Font      = new Font("Segoe UI", 10F);
            lblPeriod.ForeColor = Color.Silver;
            lblPeriod.Location  = new Point(168, 17);
            lblPeriod.Name      = "lblPeriod";
            lblPeriod.TabIndex  = 3;
            lblPeriod.Text      = "기간:";

            // cmbPeriod
            cmbPeriod.DropDownStyle     = ComboBoxStyle.DropDownList;
            cmbPeriod.FormattingEnabled = true;
            cmbPeriod.Items.AddRange(new object[] { "일별", "월별", "년도별" });
            cmbPeriod.SelectedIndex     = 0;
            cmbPeriod.Font              = new Font("Segoe UI", 10F);
            cmbPeriod.Location          = new Point(208, 12);
            cmbPeriod.Name              = "cmbPeriod";
            cmbPeriod.Size              = new Size(82, 25);
            cmbPeriod.TabIndex          = 4;

            // lblStart
            lblStart.AutoSize  = true;
            lblStart.Font      = new Font("Segoe UI", 10F);
            lblStart.ForeColor = Color.Silver;
            lblStart.Location  = new Point(300, 17);
            lblStart.Name      = "lblStart";
            lblStart.TabIndex  = 5;
            lblStart.Text      = "시작:";

            // dtpStart
            dtpStart.CustomFormat = "yyyy-MM-dd";
            dtpStart.Format       = DateTimePickerFormat.Custom;
            dtpStart.Font         = new Font("Segoe UI", 10F);
            dtpStart.Location     = new Point(337, 12);
            dtpStart.Name         = "dtpStart";
            dtpStart.Size         = new Size(115, 25);
            dtpStart.TabIndex     = 6;

            // lblTilde
            lblTilde.AutoSize  = true;
            lblTilde.Font      = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTilde.ForeColor = Color.Silver;
            lblTilde.Location  = new Point(458, 15);
            lblTilde.Name      = "lblTilde";
            lblTilde.TabIndex  = 7;
            lblTilde.Text      = "~";

            // dtpEnd
            dtpEnd.CustomFormat = "yyyy-MM-dd";
            dtpEnd.Format       = DateTimePickerFormat.Custom;
            dtpEnd.Font         = new Font("Segoe UI", 10F);
            dtpEnd.Location     = new Point(472, 12);
            dtpEnd.Name         = "dtpEnd";
            dtpEnd.Size         = new Size(115, 25);
            dtpEnd.TabIndex     = 8;

            // btnSearch
            btnSearch.BackColor = Color.SlateBlue;
            btnSearch.Cursor    = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle  = FlatStyle.Flat;
            btnSearch.Font       = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor  = Color.White;
            btnSearch.Location   = new Point(597, 9);
            btnSearch.Name       = "btnSearch";
            btnSearch.Size       = new Size(72, 32);
            btnSearch.TabIndex   = 9;
            btnSearch.Text       = "조  회";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;

            // btnPrint
            btnPrint.BackColor = Color.FromArgb(70, 90, 70);
            btnPrint.Cursor    = Cursors.Hand;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle  = FlatStyle.Flat;
            btnPrint.Font       = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPrint.ForeColor  = Color.White;
            btnPrint.Location   = new Point(677, 9);
            btnPrint.Name       = "btnPrint";
            btnPrint.Size       = new Size(68, 32);
            btnPrint.TabIndex   = 10;
            btnPrint.Text       = "인  쇄";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;

            // topPanel
            topPanel.BackColor = Color.FromArgb(28, 28, 38);
            topPanel.Dock      = DockStyle.Top;
            topPanel.Height    = 50;
            topPanel.Name      = "topPanel";
            topPanel.Controls.Add(rbCar);
            topPanel.Controls.Add(rbBike);
            topPanel.Controls.Add(lblPeriod);
            topPanel.Controls.Add(cmbPeriod);
            topPanel.Controls.Add(lblStart);
            topPanel.Controls.Add(dtpStart);
            topPanel.Controls.Add(lblTilde);
            topPanel.Controls.Add(dtpEnd);
            topPanel.Controls.Add(btnSearch);
            topPanel.Controls.Add(btnPrint);

            // dgvSummary
            dgvSummary.AllowUserToAddRows            = false;
            dgvSummary.AllowUserToDeleteRows          = false;
            dgvSummary.AutoGenerateColumns            = false;
            dgvSummary.BackgroundColor                = Color.FromArgb(22, 22, 22);
            dgvSummary.BorderStyle                    = BorderStyle.None;
            dgvSummary.ColumnHeadersDefaultCellStyle.BackColor            = Color.FromArgb(72, 52, 120);
            dgvSummary.ColumnHeadersDefaultCellStyle.Font                 = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvSummary.ColumnHeadersDefaultCellStyle.ForeColor            = Color.White;
            dgvSummary.ColumnHeadersDefaultCellStyle.SelectionBackColor   = Color.FromArgb(72, 52, 120);
            dgvSummary.ColumnHeadersDefaultCellStyle.SelectionForeColor   = Color.White;
            dgvSummary.ColumnHeadersDefaultCellStyle.Alignment            = DataGridViewContentAlignment.MiddleCenter;
            dgvSummary.ColumnHeadersHeightSizeMode    = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSummary.EnableHeadersVisualStyles      = false;
            dgvSummary.GridColor                      = Color.FromArgb(50, 50, 50);
            dgvSummary.Dock                           = DockStyle.Fill;
            dgvSummary.Name                           = "dgvSummary";
            dgvSummary.ReadOnly                       = true;
            dgvSummary.RowHeadersVisible              = false;
            dgvSummary.RowTemplate.Height             = 26;
            dgvSummary.TabIndex                       = 11;

            // ReportViewer
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(18, 18, 18);
            Controls.Add(dgvSummary);
            Controls.Add(topPanel);
            Name = "ReportViewer";
            Size = new Size(780, 530);
            ((System.ComponentModel.ISupportInitialize)dgvSummary).EndInit();
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel        topPanel;
        private RadioButton  rbCar;
        private RadioButton  rbBike;
        private Label        lblPeriod;
        private ComboBox     cmbPeriod;
        private Label        lblStart;
        private DateTimePicker dtpStart;
        private Label        lblTilde;
        private DateTimePicker dtpEnd;
        private Button       btnSearch;
        private Button       btnPrint;
        private DataGridView dgvSummary;
    }
}
