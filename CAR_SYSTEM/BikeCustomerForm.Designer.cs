/*
 * CAR SYSTEM v1.0 - Handoff Edition
 * ──────────────────────────────────
 * Based on: Rent_Auto_Desktop (MIT License)
 * Original: Clarence Sabangan (Yurei21) / Provider: chan dev
 * GitHub:   https://github.com/workingts/carsystem
 */
namespace CAR_SYSTEM
{
    partial class BikeCustomerForm
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
            tblForm      = new TableLayoutPanel();
            txtCarNo     = new TextBox();
            txtOwnerName = new TextBox();
            txtPhone     = new TextBox();
            lblTypeValue = new Label();
            cmbFuel      = new ComboBox();
            cmbDrive     = new ComboBox();
            cmbEmission  = new ComboBox();
            cmbCycle     = new ComboBox();
            dtpDate      = new DateTimePicker();
            txtExpiry    = new TextBox();
            cmbFee       = new ComboBox();
            cmbPayment   = new ComboBox();
            txtMemo      = new TextBox();
            btnSave      = new Button();
            btnReset     = new Button();

            tblForm.SuspendLayout();
            SuspendLayout();

            // ── local helper ─────────────────────────────────────────
            Panel MkCell(string hdr, Control ctrl)
            {
                Panel p   = new Panel { Dock = DockStyle.Fill, Padding = new Padding(5, 2, 5, 0) };
                Label lbl = new Label
                {
                    Text      = hdr,
                    AutoSize  = true,
                    Font      = new Font("Segoe UI", 7.5F),
                    ForeColor = Color.Silver,
                    Location  = new Point(0, 0)
                };
                ctrl.Location = new Point(0, 15);
                ctrl.Anchor   = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                ctrl.Width    = 50;
                p.Controls.Add(lbl);
                p.Controls.Add(ctrl);
                return p;
            }

            // ── controls ─────────────────────────────────────────────
            txtCarNo.Name         = "txtCarNo";
            txtCarNo.TabIndex     = 1;

            txtOwnerName.Name     = "txtOwnerName";
            txtOwnerName.TabIndex = 2;

            txtPhone.Name         = "txtPhone";
            txtPhone.TabIndex     = 3;

            lblTypeValue.Text      = "이륜차검사";
            lblTypeValue.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTypeValue.ForeColor = Color.LightSkyBlue;
            lblTypeValue.AutoSize  = true;
            lblTypeValue.Location  = new Point(0, 15);
            lblTypeValue.Name      = "lblTypeValue";

            cmbFuel.DropDownStyle    = ComboBoxStyle.DropDownList;
            cmbFuel.FormattingEnabled = true;
            cmbFuel.Items.AddRange(new object[] { "가솔린", "전기" });
            cmbFuel.Name             = "cmbFuel";
            cmbFuel.TabIndex         = 4;

            cmbDrive.DropDownStyle   = ComboBoxStyle.DropDownList;
            cmbDrive.FormattingEnabled = true;
            cmbDrive.Items.AddRange(new object[] { "전륜", "후륜", "4륜" });
            cmbDrive.Name            = "cmbDrive";
            cmbDrive.TabIndex        = 5;

            cmbEmission.DropDownStyle    = ComboBoxStyle.DropDownList;
            cmbEmission.FormattingEnabled = true;
            cmbEmission.Items.AddRange(new object[] { "KD147", "무부하급가속", "Lug-down", "ASM+Idle", "TSI무부하", "공회전배출", "면제", "무부하 정지가동" });
            cmbEmission.Name             = "cmbEmission";
            cmbEmission.TabIndex         = 6;

            cmbCycle.DropDownStyle   = ComboBoxStyle.DropDownList;
            cmbCycle.FormattingEnabled = true;
            cmbCycle.Items.AddRange(new object[] { "6개월", "1년", "2년" });
            cmbCycle.Name            = "cmbCycle";
            cmbCycle.TabIndex        = 7;

            dtpDate.CustomFormat = "yyyy-MM-dd HH:mm";
            dtpDate.Format       = DateTimePickerFormat.Custom;
            dtpDate.Name         = "dtpDate";
            dtpDate.TabIndex     = 8;

            txtExpiry.PlaceholderText = "yyyy-MM-dd";
            txtExpiry.Name            = "txtExpiry";
            txtExpiry.TabIndex        = 9;

            cmbFee.DropDownStyle     = ComboBoxStyle.DropDown;
            cmbFee.FormattingEnabled = true;
            cmbFee.Items.AddRange(new object[] { "65,000", "55,000", "50,000", "40,000", "30,000" });
            cmbFee.SelectedIndex     = 0;
            cmbFee.Name              = "cmbFee";
            cmbFee.TabIndex          = 10;

            cmbPayment.DropDownStyle    = ComboBoxStyle.DropDownList;
            cmbPayment.FormattingEnabled = true;
            cmbPayment.Items.AddRange(new object[] { "현금", "카드", "계좌이체", "미수" });
            cmbPayment.Name             = "cmbPayment";
            cmbPayment.TabIndex         = 11;

            txtMemo.Name     = "txtMemo";
            txtMemo.TabIndex = 12;

            btnSave.BackColor = Color.SlateBlue;
            btnSave.Cursor    = Cursors.Hand;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Size      = new Size(100, 26);
            btnSave.Text      = "저장";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Name      = "btnSave";
            btnSave.TabIndex  = 13;
            btnSave.Click    += btnSave_Click;

            btnReset.BackColor = Color.FromArgb(75, 75, 75);
            btnReset.Cursor    = Cursors.Hand;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReset.ForeColor = Color.White;
            btnReset.Size      = new Size(90, 26);
            btnReset.Text      = "초기화";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Name      = "btnReset";
            btnReset.TabIndex  = 14;
            btnReset.Click    += btnReset_Click;

            // ── tblForm ───────────────────────────────────────────────
            tblForm.Dock        = DockStyle.Fill;
            tblForm.ColumnCount = 4;
            tblForm.RowCount    = 6;
            tblForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tblForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tblForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tblForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tblForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tblForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tblForm.BackColor   = Color.FromArgb(18, 18, 18);
            tblForm.Name        = "tblForm";

            // Row 0 — header (span 4)
            Panel pHdr = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(40, 22, 32) };
            Label lHdr = new Label
            {
                Text      = "이륜 검사 접수",
                Font      = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding   = new Padding(10, 0, 0, 0)
            };
            pHdr.Controls.Add(lHdr);
            tblForm.Controls.Add(pHdr, 0, 0);
            tblForm.SetColumnSpan(pHdr, 4);

            // Row 1 — 차량번호 | 차주명 | 연락처 | (blank)
            tblForm.Controls.Add(MkCell("차량번호", txtCarNo),    0, 1);
            tblForm.Controls.Add(MkCell("차주명",   txtOwnerName), 1, 1);
            tblForm.Controls.Add(MkCell("연락처",   txtPhone),    2, 1);

            // Row 2 — 검사종류(고정) | 유종 | 구동방식 | 배출가스
            Panel pTypeCell = new Panel { Dock = DockStyle.Fill, Padding = new Padding(5, 2, 5, 0) };
            Label lblTypeHdr = new Label
            {
                Text      = "검사종류",
                AutoSize  = true,
                Font      = new Font("Segoe UI", 7.5F),
                ForeColor = Color.Silver,
                Location  = new Point(0, 0)
            };
            pTypeCell.Controls.Add(lblTypeHdr);
            pTypeCell.Controls.Add(lblTypeValue);
            tblForm.Controls.Add(pTypeCell,             0, 2);
            tblForm.Controls.Add(MkCell("유종",    cmbFuel),     1, 2);
            tblForm.Controls.Add(MkCell("구동방식", cmbDrive),   2, 2);
            tblForm.Controls.Add(MkCell("배출가스", cmbEmission), 3, 2);

            // Row 3 — 검사주기 | 접수일시 | 유효만료일 | (blank)
            tblForm.Controls.Add(MkCell("검사주기",  cmbCycle),  0, 3);
            tblForm.Controls.Add(MkCell("접수일시",  dtpDate),   1, 3);
            tblForm.Controls.Add(MkCell("유효만료일", txtExpiry), 2, 3);

            // Row 4 — 수수료 | 결재구분 | 비고 (span 2)
            tblForm.Controls.Add(MkCell("수수료",   cmbFee),    0, 4);
            tblForm.Controls.Add(MkCell("결재구분", cmbPayment), 1, 4);
            Panel pMemo = MkCell("비고", txtMemo);
            tblForm.Controls.Add(pMemo, 2, 4);
            tblForm.SetColumnSpan(pMemo, 2);

            // Row 5 — buttons (span 4)
            Panel pBtns = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(25, 18, 22), Padding = new Padding(8, 4, 0, 0) };
            btnSave.Location  = new Point(0, 0);
            btnReset.Location = new Point(108, 0);
            pBtns.Controls.Add(btnSave);
            pBtns.Controls.Add(btnReset);
            tblForm.Controls.Add(pBtns, 0, 5);
            tblForm.SetColumnSpan(pBtns, 4);

            // ── BikeCustomerForm ──────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(18, 18, 18);
            Controls.Add(tblForm);
            MinimumSize = new Size(0, 236);
            Name        = "BikeCustomerForm";
            Size        = new Size(900, 236);

            tblForm.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TableLayoutPanel tblForm;
        private TextBox          txtCarNo;
        private TextBox          txtOwnerName;
        private TextBox          txtPhone;
        private Label            lblTypeValue;
        private ComboBox         cmbFuel;
        private ComboBox         cmbDrive;
        private ComboBox         cmbEmission;
        private ComboBox         cmbCycle;
        private DateTimePicker   dtpDate;
        private TextBox          txtExpiry;
        private ComboBox         cmbFee;
        private ComboBox         cmbPayment;
        private TextBox          txtMemo;
        private Button           btnSave;
        private Button           btnReset;
    }
}
