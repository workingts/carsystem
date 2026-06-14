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
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace CAR_SYSTEM
{
    public partial class PaymentViewer : UserControl
    {
        public PaymentViewer()
        {
            InitializeComponent();
            label1.Text = "수수료 내역";
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.Text = "검색";
            label2.Font = new Font("Segoe UI", 9F);
            Filter.Text = "진행상태";
            Filter.Font = new Font("Segoe UI", 9F);
            SetupColumns();
            PopulateFilterCombobox();
            LoadRecords();
        }

        private void SetupColumns()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            DataGridViewTextBoxColumn col번호 = new DataGridViewTextBoxColumn();
            col번호.DataPropertyName = "접수번호";
            col번호.HeaderText = "번호";
            col번호.Name = "번호";
            dataGridView1.Columns.Add(col번호);

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

            DataGridViewTextBoxColumn col수수료 = new DataGridViewTextBoxColumn();
            col수수료.DataPropertyName = "수수료";
            col수수료.HeaderText = "수수료";
            col수수료.Name = "수수료";
            col수수료.DefaultCellStyle.Format = "'₩'#,##0";
            dataGridView1.Columns.Add(col수수료);

            DataGridViewTextBoxColumn col접수일시 = new DataGridViewTextBoxColumn();
            col접수일시.DataPropertyName = "접수일시";
            col접수일시.HeaderText = "납부일시";
            col접수일시.Name = "납부일시";
            dataGridView1.Columns.Add(col접수일시);

            DataGridViewTextBoxColumn col진행상태 = new DataGridViewTextBoxColumn();
            col진행상태.DataPropertyName = "진행상태";
            col진행상태.HeaderText = "납부상태";
            col진행상태.Name = "납부상태";
            dataGridView1.Columns.Add(col진행상태);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.FromArgb(18, 18, 18);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(18, 18, 18);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 250);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void LoadRecords(string keyword = "", string paymentStatus = "")
        {
            string query =
                "SELECT" +
                " j.접수번호," +
                " c.차주명," +
                " j.차량번호," +
                " j.검사종류," +
                " j.수수료," +
                " j.접수일시," +
                " j.진행상태" +
                " FROM 접수 j" +
                " INNER JOIN 차주 c ON j.차주번호 = c.차주번호" +
                " WHERE (c.차주명 LIKE @keyword OR j.차량번호 LIKE @keyword)";

            if (!string.IsNullOrEmpty(paymentStatus))
                query += " AND j.진행상태 = @paymentStatus";

            DBHelper db = new DBHelper();
            SqliteParameter[] parameters;

            if (!string.IsNullOrEmpty(paymentStatus))
            {
                parameters = new SqliteParameter[]
                {
                    new SqliteParameter("@keyword",       "%" + keyword + "%"),
                    new SqliteParameter("@paymentStatus", paymentStatus)
                };
            }
            else
            {
                parameters = new SqliteParameter[]
                {
                    new SqliteParameter("@keyword", "%" + keyword + "%")
                };
            }

            DataTable dt = db.FetchData(query, parameters);

            int i = 0;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                row["차주명"]   = CryptoHelper.MaskName(CryptoHelper.Decrypt(row["차주명"].ToString()));
                row["차량번호"] = CryptoHelper.MaskCarNo(CryptoHelper.Decrypt(row["차량번호"].ToString()));
            }

            dataGridView1.DataSource = dt;
        }

        private void PopulateFilterCombobox()
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("완료");
            cmbStatusFilter.Items.Add("진행중");
            cmbStatusFilter.SelectedIndex = -1;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            string status = "";
            if (cmbStatusFilter.SelectedItem != null)
                status = cmbStatusFilter.SelectedItem.ToString();
            LoadRecords(keyword, status);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbStatusFilter.SelectedIndex = -1;
            LoadRecords();
        }
    }
}
