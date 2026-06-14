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
using Microsoft.Data.Sqlite;

namespace CAR_SYSTEM
{
    public partial class RecordViewer : UserControl
    {
        private DataTable _rawTable = null;
        private bool _isBike = false;

        public RecordViewer()
        {
            InitializeComponent();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            SetupColumns();
            LoadRecords();
        }

        private void rdoCar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCar.Checked)
            {
                _isBike = false;
                label1.Text = "접수 목록";
                LoadRecords();
            }
        }

        private void rdoBike_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBike.Checked)
            {
                _isBike = true;
                label1.Text = "접수 목록 (이륜)";
                LoadRecords();
            }
        }

        private void SetupColumns()
        {
            dataGridView1.Columns.Clear();

            DataGridViewTextBoxColumn col접수번호 = new DataGridViewTextBoxColumn();
            col접수번호.DataPropertyName = "접수번호";
            col접수번호.HeaderText = "접수번호";
            col접수번호.Name = "접수번호";
            dataGridView1.Columns.Add(col접수번호);

            DataGridViewTextBoxColumn col차주명 = new DataGridViewTextBoxColumn();
            col차주명.DataPropertyName = "차주명";
            col차주명.HeaderText = "차주명";
            col차주명.Name = "차주명";
            dataGridView1.Columns.Add(col차주명);

            DataGridViewTextBoxColumn col차량번호 = new DataGridViewTextBoxColumn();
            col차량번호.DataPropertyName = "차량번호";
            col차량번호.HeaderText = "차량번호";
            col차량번호.Name = "차량번호";
            dataGridView1.Columns.Add(col차량번호);

            DataGridViewTextBoxColumn col검사종류 = new DataGridViewTextBoxColumn();
            col검사종류.DataPropertyName = "검사종류";
            col검사종류.HeaderText = "검사종류";
            col검사종류.Name = "검사종류";
            dataGridView1.Columns.Add(col검사종류);

            DataGridViewTextBoxColumn col접수일시 = new DataGridViewTextBoxColumn();
            col접수일시.DataPropertyName = "접수일시";
            col접수일시.HeaderText = "접수일시";
            col접수일시.Name = "접수일시";
            dataGridView1.Columns.Add(col접수일시);

            DataGridViewTextBoxColumn col수수료 = new DataGridViewTextBoxColumn();
            col수수료.DataPropertyName = "수수료";
            col수수료.HeaderText = "수수료";
            col수수료.Name = "수수료";
            col수수료.DefaultCellStyle.Format = "'₩'#,##0";
            dataGridView1.Columns.Add(col수수료);

            DataGridViewTextBoxColumn col검사결과 = new DataGridViewTextBoxColumn();
            col검사결과.DataPropertyName = "검사결과";
            col검사결과.HeaderText = "검사결과";
            col검사결과.Name = "검사결과";
            dataGridView1.Columns.Add(col검사결과);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.BackgroundColor = Color.FromArgb(30, 30, 30);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(210, 210, 210);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 250);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void LoadRecords(string keyword = "")
        {
            string table = _isBike ? "이륜접수" : "접수";
            string query =
                "SELECT" +
                " j.접수번호," +
                " c.차주명," +
                " j.차량번호," +
                " j.검사종류," +
                " j.접수일시," +
                " j.수수료," +
                " j.검사결과," +
                " c.연락처" +
                " FROM " + table + " j" +
                " INNER JOIN 차주 c ON j.차주번호 = c.차주번호" +
                " WHERE (c.차주명 LIKE @keyword OR j.차량번호 LIKE @keyword)";

            DBHelper db = new DBHelper();
            SqliteParameter[] parameters = new SqliteParameter[]
            {
                new SqliteParameter("@keyword", "%" + keyword + "%")
            };

            _rawTable = db.FetchData(query, parameters);

            DataTable displayTable = _rawTable.Copy();
            int i = 0;
            for (i = 0; i < displayTable.Rows.Count; i++)
            {
                DataRow row = displayTable.Rows[i];
                row["차량번호"] = CryptoHelper.MaskCarNo(CryptoHelper.Decrypt(row["차량번호"].ToString()));
                row["차주명"]   = CryptoHelper.MaskName(CryptoHelper.Decrypt(row["차주명"].ToString()));
            }

            dataGridView1.DataSource = displayTable;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dt = dataGridView1.DataSource as DataTable;
            if (dt == null || e.RowIndex >= dt.Rows.Count) return;
            DataRow row = dt.Rows[e.RowIndex];
            string carNo = CryptoHelper.Decrypt(row["차량번호"].ToString());
            string name  = CryptoHelper.Decrypt(row["차주명"].ToString());
            string phone = CryptoHelper.Decrypt(row["연락처"].ToString());
            MessageBox.Show(
                "차량번호: " + carNo + "\n" +
                "차주명:   " + name  + "\n" +
                "연락처:   " + phone,
                "상세정보",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadRecords(txtSearch.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadRecords();
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (_rawTable == null || _rawTable.Rows.Count == 0)
            {
                MessageBox.Show("내보낼 데이터가 없습니다.");
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "CSV 파일 (*.csv)|*.csv";
            dlg.FileName = "검사대상목록_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (StreamWriter sw = new StreamWriter(dlg.FileName, false, Encoding.UTF8))
                {
                    sw.Write('﻿');
                    sw.WriteLine("접수번호,차주명,차량번호,검사종류,접수일시,수수료,검사결과");

                    int i = 0;
                    for (i = 0; i < _rawTable.Rows.Count; i++)
                    {
                        DataRow row = _rawTable.Rows[i];
                        string plainName  = CryptoHelper.Decrypt(row["차주명"].ToString());
                        string plainCarNo = CryptoHelper.Decrypt(row["차량번호"].ToString());
                        sw.WriteLine(
                            row["접수번호"]    + "," +
                            plainName          + "," +
                            plainCarNo         + "," +
                            row["검사종류"]    + "," +
                            row["접수일시"]    + "," +
                            row["수수료"]      + "," +
                            row["검사결과"]
                        );
                    }
                }
                MessageBox.Show("CSV 저장 완료: " + dlg.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CSV 저장 오류: " + ex.Message);
            }
        }
    }
}
