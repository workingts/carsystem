/*
 * CAR SYSTEM v1.0 - Handoff Edition
 * ──────────────────────────────────
 * Based on: Rent_Auto_Desktop (MIT License)
 * Original: Clarence Sabangan (Yurei21) / Provider: chan dev
 * GitHub:   https://github.com/workingts/carsystem
 */
namespace CAR_SYSTEM
{
    partial class RecordViewer
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
            DataGridViewCellStyle hdrStyle = new DataGridViewCellStyle();
            pnlToolbar       = new Panel();
            label1           = new Label();
            label2           = new Label();
            txtSearch        = new TextBox();
            Filter           = new Label();
            cmbStatusFilter  = new ComboBox();
            label3           = new Label();
            cmbPaymentFilter = new ComboBox();
            btnFilter        = new Button();
            button1          = new Button();
            btnExportCsv     = new Button();
            dataGridView1    = new DataGridView();

            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // ── pnlToolbar ───────────────────────────────────────────
            pnlToolbar.BackColor = Color.FromArgb(18, 18, 18);
            pnlToolbar.Dock      = DockStyle.Top;
            pnlToolbar.Height    = 85;
            pnlToolbar.Name      = "pnlToolbar";
            pnlToolbar.Controls.Add(label1);
            pnlToolbar.Controls.Add(label2);
            pnlToolbar.Controls.Add(txtSearch);
            pnlToolbar.Controls.Add(Filter);
            pnlToolbar.Controls.Add(cmbStatusFilter);
            pnlToolbar.Controls.Add(label3);
            pnlToolbar.Controls.Add(cmbPaymentFilter);
            pnlToolbar.Controls.Add(btnFilter);
            pnlToolbar.Controls.Add(button1);
            pnlToolbar.Controls.Add(btnExportCsv);

            // label1 — title
            label1.AutoSize  = true;
            label1.Font      = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location  = new Point(8, 3);
            label1.Name      = "label1";
            label1.TabIndex  = 21;
            label1.Text      = "접수 목록";

            // label2 — 검색
            label2.AutoSize  = true;
            label2.Font      = new Font("Segoe UI", 9F);
            label2.ForeColor = Color.White;
            label2.Location  = new Point(8, 38);
            label2.Name      = "label2";
            label2.TabIndex  = 27;
            label2.Text      = "검색";

            // txtSearch
            txtSearch.Location  = new Point(8, 54);
            txtSearch.Name      = "txtSearch";
            txtSearch.Size      = new Size(200, 23);
            txtSearch.TabIndex  = 24;

            // Filter — 진행상태
            Filter.AutoSize  = true;
            Filter.Font      = new Font("Segoe UI", 9F);
            Filter.ForeColor = Color.White;
            Filter.Location  = new Point(215, 38);
            Filter.Name      = "Filter";
            Filter.TabIndex  = 28;
            Filter.Text      = "진행상태";

            // cmbStatusFilter
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Location          = new Point(215, 54);
            cmbStatusFilter.Name              = "cmbStatusFilter";
            cmbStatusFilter.Size              = new Size(120, 23);
            cmbStatusFilter.TabIndex          = 22;

            // label3 — 납부상태
            label3.AutoSize  = true;
            label3.Font      = new Font("Segoe UI", 9F);
            label3.ForeColor = Color.White;
            label3.Location  = new Point(340, 38);
            label3.Name      = "label3";
            label3.TabIndex  = 29;
            label3.Text      = "납부상태";

            // cmbPaymentFilter
            cmbPaymentFilter.FormattingEnabled = true;
            cmbPaymentFilter.Location          = new Point(340, 54);
            cmbPaymentFilter.Name              = "cmbPaymentFilter";
            cmbPaymentFilter.Size              = new Size(100, 23);
            cmbPaymentFilter.TabIndex          = 23;

            // btnFilter
            btnFilter.BackColor = Color.SlateBlue;
            btnFilter.FlatStyle = FlatStyle.Popup;
            btnFilter.Font      = new Font("Segoe UI", 9F);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location  = new Point(446, 54);
            btnFilter.Name      = "btnFilter";
            btnFilter.Size      = new Size(65, 23);
            btnFilter.TabIndex  = 25;
            btnFilter.Text      = "조회";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click    += btnFilter_Click;

            // button1 — 초기화
            button1.BackColor = Color.Crimson;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font      = new Font("Segoe UI", 9F);
            button1.ForeColor = Color.White;
            button1.Location  = new Point(516, 54);
            button1.Name      = "button1";
            button1.Size      = new Size(55, 23);
            button1.TabIndex  = 26;
            button1.Text      = "초기화";
            button1.UseVisualStyleBackColor = false;
            button1.Click    += button1_Click;

            // btnExportCsv
            btnExportCsv.BackColor = Color.DarkGreen;
            btnExportCsv.FlatStyle = FlatStyle.Popup;
            btnExportCsv.Font      = new Font("Segoe UI", 9F);
            btnExportCsv.ForeColor = Color.White;
            btnExportCsv.Location  = new Point(576, 54);
            btnExportCsv.Name      = "btnExportCsv";
            btnExportCsv.Size      = new Size(90, 23);
            btnExportCsv.TabIndex  = 30;
            btnExportCsv.Text      = "CSV 내보내기";
            btnExportCsv.UseVisualStyleBackColor = false;
            btnExportCsv.Click    += btnExportCsv_Click;

            // ── dataGridView1 (fills remaining space) ────────────────
            hdrStyle.Alignment          = DataGridViewContentAlignment.MiddleCenter;
            hdrStyle.BackColor          = Color.FromArgb(113, 96, 232);
            hdrStyle.Font               = new Font("Segoe UI", 11F);
            hdrStyle.ForeColor          = Color.White;
            hdrStyle.SelectionBackColor = Color.FromArgb(113, 96, 232);
            hdrStyle.SelectionForeColor = SystemColors.HighlightText;
            hdrStyle.WrapMode           = DataGridViewTriState.True;

            dataGridView1.AutoGenerateColumns           = false;
            dataGridView1.BackgroundColor               = Color.FromArgb(18, 18, 18);
            dataGridView1.BorderStyle                   = BorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle = hdrStyle;
            dataGridView1.ColumnHeadersHeightSizeMode   = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock                          = DockStyle.Fill;
            dataGridView1.GridColor                     = Color.SlateBlue;
            dataGridView1.Name                          = "dataGridView1";
            dataGridView1.RowHeadersVisible             = false;
            dataGridView1.RowHeadersWidth               = 51;
            dataGridView1.TabIndex                      = 20;

            // ── RecordViewer ──────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(18, 18, 18);
            Controls.Add(dataGridView1);
            Controls.Add(pnlToolbar);
            Name = "RecordViewer";
            Size = new Size(791, 545);

            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel        pnlToolbar;
        private DataGridView dataGridView1;
        private Label        label1;
        private ComboBox     cmbStatusFilter;
        private ComboBox     cmbPaymentFilter;
        private TextBox      txtSearch;
        private Button       btnFilter;
        private Button       button1;
        private Button       btnExportCsv;
        private Label        label2;
        private Label        Filter;
        private Label        label3;
    }
}
