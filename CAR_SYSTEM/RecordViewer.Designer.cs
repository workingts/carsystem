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
            pnlToolbar    = new Panel();
            rdoCar        = new RadioButton();
            rdoBike       = new RadioButton();
            label1        = new Label();
            label2        = new Label();
            txtSearch     = new TextBox();
            btnFilter     = new Button();
            button1       = new Button();
            btnExportCsv  = new Button();
            dataGridView1 = new DataGridView();

            pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // ── pnlToolbar ───────────────────────────────────────────
            pnlToolbar.BackColor = Color.FromArgb(18, 18, 18);
            pnlToolbar.Dock      = DockStyle.Top;
            pnlToolbar.Height    = 85;
            pnlToolbar.Name      = "pnlToolbar";
            pnlToolbar.Controls.Add(label1);
            pnlToolbar.Controls.Add(rdoCar);
            pnlToolbar.Controls.Add(rdoBike);
            pnlToolbar.Controls.Add(label2);
            pnlToolbar.Controls.Add(txtSearch);
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

            // rdoCar
            rdoCar.AutoSize  = true;
            rdoCar.Checked   = true;
            rdoCar.Font      = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            rdoCar.ForeColor = Color.White;
            rdoCar.Location  = new Point(210, 8);
            rdoCar.Name      = "rdoCar";
            rdoCar.Text      = "자동차";
            rdoCar.TabIndex  = 31;
            rdoCar.CheckedChanged += rdoCar_CheckedChanged;

            // rdoBike
            rdoBike.AutoSize  = true;
            rdoBike.Font      = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            rdoBike.ForeColor = Color.LightSkyBlue;
            rdoBike.Location  = new Point(295, 8);
            rdoBike.Name      = "rdoBike";
            rdoBike.Text      = "이륜";
            rdoBike.TabIndex  = 32;
            rdoBike.CheckedChanged += rdoBike_CheckedChanged;

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

            // btnFilter
            btnFilter.BackColor = Color.SlateBlue;
            btnFilter.FlatStyle = FlatStyle.Popup;
            btnFilter.Font      = new Font("Segoe UI", 9F);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location  = new Point(214, 54);
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
            button1.Location  = new Point(284, 54);
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
            btnExportCsv.Location  = new Point(344, 54);
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
        private RadioButton  rdoCar;
        private RadioButton  rdoBike;
        private Label        label1;
        private TextBox      txtSearch;
        private Button       btnFilter;
        private Button       button1;
        private Button       btnExportCsv;
        private Label        label2;
    }
}
