/*
 * CAR SYSTEM v1.0 - Handoff Edition
 * ──────────────────────────────────
 * Based on: Rent_Auto_Desktop (MIT License)
 * Original: Clarence Sabangan (Yurei21) / Provider: chan dev
 * GitHub:   https://github.com/workingts/carsystem
 */
namespace CAR_SYSTEM
{
    partial class MainDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop     = new Panel();
            lblTitle   = new Label();
            flwNav     = new FlowLayoutPanel();
            btnReport   = new Button();
            btnPayment  = new Button();
            btnExpiry   = new Button();
            btnAccount  = new Button();
            btnAbout    = new Button();
            tblMain    = new TableLayoutPanel();
            ucCustomer = new CustomerForm();
            ucBike     = new BikeCustomerForm();
            ucRecord   = new RecordViewer();

            pnlTop.SuspendLayout();
            flwNav.SuspendLayout();
            tblMain.SuspendLayout();
            SuspendLayout();

            // ── pnlTop ───────────────────────────────────────────────
            pnlTop.BackColor = Color.FromArgb(20, 22, 40);
            pnlTop.Dock      = DockStyle.Top;
            pnlTop.Height    = 40;
            pnlTop.Name      = "pnlTop";
            pnlTop.Controls.Add(flwNav);
            pnlTop.Controls.Add(lblTitle);

            // lblTitle
            lblTitle.Text      = "차량검사 접수 관리";
            lblTitle.Font      = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Dock      = DockStyle.Left;
            lblTitle.Width     = 270;
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTitle.Padding   = new Padding(12, 0, 0, 0);
            lblTitle.Name      = "lblTitle";

            // flwNav (right-side button strip)
            flwNav.Dock          = DockStyle.Right;
            flwNav.AutoSize      = true;
            flwNav.FlowDirection = FlowDirection.LeftToRight;
            flwNav.WrapContents  = false;
            flwNav.BackColor     = Color.Transparent;
            flwNav.Padding       = new Padding(0, 6, 8, 0);
            flwNav.Name          = "flwNav";
            flwNav.Controls.Add(btnReport);
            flwNav.Controls.Add(btnPayment);
            flwNav.Controls.Add(btnExpiry);
            flwNav.Controls.Add(btnAccount);
            flwNav.Controls.Add(btnAbout);

            // btnReport
            btnReport.Text      = "집계표";
            btnReport.Font      = new Font("Segoe UI", 9F);
            btnReport.ForeColor = Color.White;
            btnReport.BackColor = Color.FromArgb(55, 55, 85);
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.Size      = new Size(78, 28);
            btnReport.Cursor    = Cursors.Hand;
            btnReport.Name      = "btnReport";
            btnReport.Click    += btnReport_Click;

            // btnPayment
            btnPayment.Text      = "수수료내역";
            btnPayment.Font      = new Font("Segoe UI", 9F);
            btnPayment.ForeColor = Color.White;
            btnPayment.BackColor = Color.FromArgb(55, 55, 85);
            btnPayment.FlatStyle = FlatStyle.Flat;
            btnPayment.FlatAppearance.BorderSize = 0;
            btnPayment.Size      = new Size(88, 28);
            btnPayment.Cursor    = Cursors.Hand;
            btnPayment.Name      = "btnPayment";
            btnPayment.Click    += btnPayment_Click;

            // btnExpiry
            btnExpiry.Text      = "만료목록";
            btnExpiry.Font      = new Font("Segoe UI", 9F);
            btnExpiry.ForeColor = Color.LightSalmon;
            btnExpiry.BackColor = Color.FromArgb(55, 55, 85);
            btnExpiry.FlatStyle = FlatStyle.Flat;
            btnExpiry.FlatAppearance.BorderSize = 0;
            btnExpiry.Size      = new Size(78, 28);
            btnExpiry.Cursor    = Cursors.Hand;
            btnExpiry.Name      = "btnExpiry";
            btnExpiry.Click    += btnExpiry_Click;

            // btnAccount
            btnAccount.Text      = "계정관리";
            btnAccount.Font      = new Font("Segoe UI", 9F);
            btnAccount.ForeColor = Color.White;
            btnAccount.BackColor = Color.FromArgb(55, 55, 85);
            btnAccount.FlatStyle = FlatStyle.Flat;
            btnAccount.FlatAppearance.BorderSize = 0;
            btnAccount.Size      = new Size(78, 28);
            btnAccount.Cursor    = Cursors.Hand;
            btnAccount.Name      = "btnAccount";
            btnAccount.Click    += btnAccount_Click;

            // btnAbout
            btnAbout.Text      = "About";
            btnAbout.Font      = new Font("Segoe UI", 9F);
            btnAbout.ForeColor = Color.DarkGray;
            btnAbout.BackColor = Color.FromArgb(28, 28, 42);
            btnAbout.FlatStyle = FlatStyle.Flat;
            btnAbout.FlatAppearance.BorderSize = 0;
            btnAbout.Size      = new Size(60, 28);
            btnAbout.Cursor    = Cursors.Hand;
            btnAbout.Name      = "btnAbout";
            btnAbout.Click    += btnAbout_Click;

            // ── tblMain ──────────────────────────────────────────────
            tblMain.Dock        = DockStyle.Fill;
            tblMain.ColumnCount = 1;
            tblMain.RowCount    = 3;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tblMain.BackColor   = Color.FromArgb(14, 14, 20);
            tblMain.Name        = "tblMain";

            // ucCustomer
            ucCustomer.Dock        = DockStyle.Fill;
            ucCustomer.MinimumSize = new Size(0, 234);
            ucCustomer.Name        = "ucCustomer";

            // ucBike
            ucBike.Dock        = DockStyle.Fill;
            ucBike.MinimumSize = new Size(0, 234);
            ucBike.Name        = "ucBike";

            // ucRecord
            ucRecord.Dock = DockStyle.Fill;
            ucRecord.Name = "ucRecord";

            tblMain.Controls.Add(ucCustomer, 0, 0);
            tblMain.Controls.Add(ucBike,     0, 1);
            tblMain.Controls.Add(ucRecord,   0, 2);

            // ── MainDashboard ─────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(14, 14, 20);
            ClientSize          = new Size(1200, 820);
            Controls.Add(tblMain);
            Controls.Add(pnlTop);
            FormBorderStyle = FormBorderStyle.Sizable;
            Name            = "MainDashboard";
            StartPosition   = FormStartPosition.CenterScreen;
            Text            = "CAR SYSTEM";

            pnlTop.ResumeLayout(false);
            flwNav.ResumeLayout(false);
            flwNav.PerformLayout();
            tblMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel           pnlTop;
        private Label           lblTitle;
        private FlowLayoutPanel flwNav;
        private Button          btnReport;
        private Button          btnPayment;
        private Button          btnExpiry;
        private Button          btnAccount;
        private Button          btnAbout;
        private TableLayoutPanel tblMain;
        private CustomerForm    ucCustomer;
        private BikeCustomerForm ucBike;
        private RecordViewer    ucRecord;
    }
}
