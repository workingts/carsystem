/*
 * CAR SYSTEM v1.0 - Handoff Edition
 * ──────────────────────────────────
 * Based on: Rent_Auto_Desktop (MIT License)
 * Original: Clarence Sabangan (Yurei21)
 *           https://github.com/Yurei21/Rent_Auto_Desktop
 *
 * Provider: chan dev
 * GitHub:   https://github.com/workingts/carsystem
 *
 * [Handoff Edition]
 * 본 버전은 핸드오프(인계) 목적으로 제공됩니다.
 * 추가 개발 및 완성은 수령자의 책임입니다.
 *
 * ✅ 추가 개발 / 사업화 허용 (MIT 조건 내)
 * ❌ 엑셀 파일 저작권 주장 불가
 * ❌ 제공자 책임 없음
 */
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CAR_SYSTEM
{
    public class ExpiryListForm : Form
    {
        private DataGridView dgvExpiry;
        private Button btnExportCsv;
        private Button btnClose;
        private Label lblInfo;

        public ExpiryListForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            dgvExpiry    = new DataGridView();
            btnExportCsv = new Button();
            btnClose     = new Button();
            lblInfo      = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvExpiry).BeginInit();
            SuspendLayout();

            // headerStyle
            headerStyle.Alignment          = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor          = Color.FromArgb(113, 96, 232);
            headerStyle.Font               = new Font("Segoe UI", 10F, FontStyle.Bold);
            headerStyle.ForeColor          = Color.White;
            headerStyle.SelectionBackColor = Color.FromArgb(113, 96, 232);
            headerStyle.SelectionForeColor = Color.White;
            headerStyle.WrapMode           = DataGridViewTriState.True;

            // lblInfo
            lblInfo.AutoSize  = true;
            lblInfo.Font      = new Font("Segoe UI", 10F);
            lblInfo.ForeColor = Color.LightGray;
            lblInfo.Location  = new Point(12, 12);
            lblInfo.Name      = "lblInfo";
            lblInfo.TabIndex  = 3;
            lblInfo.Text      = "조회 기준: D-90 ~ D+31 (자동)     더블클릭 → 상세보기";

            // dgvExpiry
            dgvExpiry.AutoGenerateColumns           = false;
            dgvExpiry.BackgroundColor               = Color.FromArgb(18, 18, 18);
            dgvExpiry.BorderStyle                   = BorderStyle.None;
            dgvExpiry.CellBorderStyle               = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvExpiry.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvExpiry.ColumnHeadersHeightSizeMode   = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpiry.DefaultCellStyle.BackColor    = Color.FromArgb(18, 18, 18);
            dgvExpiry.DefaultCellStyle.ForeColor    = Color.White;
            dgvExpiry.DefaultCellStyle.Font         = new Font("Segoe UI", 10F);
            dgvExpiry.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 100);
            dgvExpiry.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvExpiry.EnableHeadersVisualStyles     = false;
            dgvExpiry.GridColor                     = Color.SlateBlue;
            dgvExpiry.Location                      = new Point(12, 38);
            dgvExpiry.Name                          = "dgvExpiry";
            dgvExpiry.RowHeadersVisible             = false;
            dgvExpiry.Size                          = new Size(860, 468);
            dgvExpiry.TabIndex                      = 0;
            dgvExpiry.AutoSizeColumnsMode           = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpiry.CellFormatting               += new DataGridViewCellFormattingEventHandler(dgvExpiry_CellFormatting);
            dgvExpiry.CellDoubleClick              += new DataGridViewCellEventHandler(dgvExpiry_CellDoubleClick);

            DataGridViewTextBoxColumn col접수번호 = new DataGridViewTextBoxColumn();
            col접수번호.DataPropertyName = "접수번호";
            col접수번호.HeaderText       = "접수번호";
            col접수번호.Name             = "접수번호";
            col접수번호.FillWeight       = 60;
            dgvExpiry.Columns.Add(col접수번호);

            DataGridViewTextBoxColumn col차량번호 = new DataGridViewTextBoxColumn();
            col차량번호.DataPropertyName = "차량번호";
            col차량번호.HeaderText       = "차량번호";
            col차량번호.Name             = "차량번호";
            col차량번호.FillWeight       = 100;
            dgvExpiry.Columns.Add(col차량번호);

            DataGridViewTextBoxColumn col차주명 = new DataGridViewTextBoxColumn();
            col차주명.DataPropertyName = "차주명";
            col차주명.HeaderText       = "차주명";
            col차주명.Name             = "차주명";
            col차주명.FillWeight       = 80;
            dgvExpiry.Columns.Add(col차주명);

            DataGridViewTextBoxColumn col연락처 = new DataGridViewTextBoxColumn();
            col연락처.DataPropertyName = "연락처";
            col연락처.HeaderText       = "연락처";
            col연락처.Name             = "연락처";
            col연락처.FillWeight       = 100;
            dgvExpiry.Columns.Add(col연락처);

            DataGridViewTextBoxColumn col검사종류 = new DataGridViewTextBoxColumn();
            col검사종류.DataPropertyName = "검사종류";
            col검사종류.HeaderText       = "검사종류";
            col검사종류.Name             = "검사종류";
            col검사종류.FillWeight       = 100;
            dgvExpiry.Columns.Add(col검사종류);

            DataGridViewTextBoxColumn col유효만료일 = new DataGridViewTextBoxColumn();
            col유효만료일.DataPropertyName = "유효만료일";
            col유효만료일.HeaderText       = "유효만료일";
            col유효만료일.Name             = "유효만료일";
            col유효만료일.FillWeight       = 100;
            dgvExpiry.Columns.Add(col유효만료일);

            DataGridViewTextBoxColumn colDday = new DataGridViewTextBoxColumn();
            colDday.DataPropertyName = "DDAY";
            colDday.HeaderText       = "D-day";
            colDday.Name             = "DDAY";
            colDday.FillWeight       = 70;
            dgvExpiry.Columns.Add(colDday);

            // btnExportCsv
            btnExportCsv.BackColor = Color.DarkGreen;
            btnExportCsv.FlatAppearance.BorderSize = 0;
            btnExportCsv.FlatStyle  = FlatStyle.Flat;
            btnExportCsv.Font       = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportCsv.ForeColor  = Color.White;
            btnExportCsv.Location   = new Point(12, 520);
            btnExportCsv.Name       = "btnExportCsv";
            btnExportCsv.Size       = new Size(120, 28);
            btnExportCsv.TabIndex   = 1;
            btnExportCsv.Text       = "CSV 내보내기";
            btnExportCsv.UseVisualStyleBackColor = false;
            btnExportCsv.Click += new EventHandler(btnExportCsv_Click);

            // btnClose
            btnClose.BackColor = Color.DimGray;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle  = FlatStyle.Flat;
            btnClose.Font       = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClose.ForeColor  = Color.White;
            btnClose.Location   = new Point(752, 520);
            btnClose.Name       = "btnClose";
            btnClose.Size       = new Size(120, 28);
            btnClose.TabIndex   = 2;
            btnClose.Text       = "닫기";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += new EventHandler(btnClose_Click);

            // ExpiryListForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(18, 18, 18);
            ClientSize          = new Size(884, 560);
            Controls.Add(lblInfo);
            Controls.Add(dgvExpiry);
            Controls.Add(btnExportCsv);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox     = true;
            MinimizeBox     = true;
            Name            = "ExpiryListForm";
            StartPosition   = FormStartPosition.CenterParent;
            Text            = "검사대상차량 리스트";
            ((System.ComponentModel.ISupportInitialize)dgvExpiry).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void LoadData()
        {
            string query =
                "SELECT j.접수번호, j.차량번호, c.차주명, c.연락처," +
                " j.검사종류, j.유효만료일," +
                " CAST((julianday(j.유효만료일) - julianday('now','localtime')) AS INTEGER) AS DDAY" +
                " FROM 접수 j" +
                " INNER JOIN 차주 c ON j.차주번호 = c.차주번호" +
                " WHERE j.유효만료일 BETWEEN" +
                " date('now','localtime','-90 days')" +
                " AND date('now','localtime','+31 days')" +
                " UNION ALL" +
                " SELECT j.접수번호, j.차량번호, c.차주명, c.연락처," +
                " j.검사종류, j.유효만료일," +
                " CAST((julianday(j.유효만료일) - julianday('now','localtime')) AS INTEGER) AS DDAY" +
                " FROM 이륜접수 j" +
                " INNER JOIN 차주 c ON j.차주번호 = c.차주번호" +
                " WHERE j.유효만료일 BETWEEN" +
                " date('now','localtime','-90 days')" +
                " AND date('now','localtime','+31 days')" +
                " ORDER BY 유효만료일 ASC";

            DBHelper db = new DBHelper();
            DataTable dt = db.FetchData(query, null);
            dgvExpiry.DataSource = dt;
        }

        private void dgvExpiry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string colName = dgvExpiry.Columns[e.ColumnIndex].Name;

            if (colName == "차량번호")
            {
                if (e.Value == null || e.Value == DBNull.Value) return;
                e.Value = CryptoHelper.MaskCarNo(CryptoHelper.Decrypt(e.Value.ToString()));
                e.FormattingApplied = true;
            }
            else if (colName == "차주명")
            {
                if (e.Value == null || e.Value == DBNull.Value) return;
                e.Value = CryptoHelper.MaskName(CryptoHelper.Decrypt(e.Value.ToString()));
                e.FormattingApplied = true;
            }
            else if (colName == "연락처")
            {
                if (e.Value == null || e.Value == DBNull.Value) return;
                e.Value = CryptoHelper.MaskPhone(CryptoHelper.Decrypt(e.Value.ToString()));
                e.FormattingApplied = true;
            }
            else if (colName == "DDAY")
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    e.Value = "-";
                    e.FormattingApplied = true;
                    return;
                }
                int dday = Convert.ToInt32(e.Value);
                if (dday > 0)
                {
                    e.Value = "D-" + dday.ToString();
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (dday < 0)
                {
                    e.Value = "D+" + Math.Abs(dday).ToString();
                    e.CellStyle.ForeColor = Color.CornflowerBlue;
                }
                else
                {
                    e.Value = "D-Day";
                    e.CellStyle.Font      = new Font(dgvExpiry.Font, FontStyle.Bold);
                    e.CellStyle.ForeColor = Color.DarkRed;
                }
                e.FormattingApplied = true;
            }
        }

        private void dgvExpiry_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataTable dt = (DataTable)dgvExpiry.DataSource;
            if (dt == null) return;
            DataRow row  = dt.Rows[e.RowIndex];
            string carNo = CryptoHelper.Decrypt(row["차량번호"].ToString());
            string name  = CryptoHelper.Decrypt(row["차주명"].ToString());
            string phone = CryptoHelper.Decrypt(row["연락처"].ToString());
            int dday = (row["DDAY"] == DBNull.Value)
                ? 0
                : Convert.ToInt32(row["DDAY"]);
            string ddayStr = dday >= 0 ? "D-" + dday.ToString() : "D+" + Math.Abs(dday).ToString();

            MessageBox.Show(
                "차량번호: " + carNo + "\n" +
                "차주명:   " + name  + "\n" +
                "연락처:   " + phone + "\n" +
                "유효만료일: " + row["유효만료일"] + "\n" +
                "D-day:    " + ddayStr,
                "검사대상 상세정보",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter   = "CSV 파일 (*.csv)|*.csv";
            dlg.FileName = "검사대상리스트_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (StreamWriter sw = new StreamWriter(dlg.FileName, false, Encoding.UTF8))
                {
                    sw.Write('﻿');
                    sw.WriteLine("접수번호,차량번호,차주명,연락처,검사종류,유효만료일,D-day");

                    DataTable dt = (DataTable)dgvExpiry.DataSource;
                    if (dt != null)
                    {
                        int i = 0;
                        for (i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow row = dt.Rows[i];
                            long ddayVal  = row["DDAY"] == DBNull.Value ? 0L : Convert.ToInt64(row["DDAY"]);
                            string ddayStr = ddayVal >= 0 ? "D-" + ddayVal.ToString() : "D+" + Math.Abs(ddayVal).ToString();
                            sw.WriteLine(
                                row["접수번호"]    + "," +
                                CryptoHelper.Decrypt(row["차량번호"].ToString()) + "," +
                                CryptoHelper.Decrypt(row["차주명"].ToString())   + "," +
                                CryptoHelper.Decrypt(row["연락처"].ToString())   + "," +
                                row["검사종류"]    + "," +
                                row["유효만료일"]  + "," +
                                ddayStr
                            );
                        }
                    }
                }
                MessageBox.Show("저장 완료: " + dlg.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CSV 저장 오류: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
