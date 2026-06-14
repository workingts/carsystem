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
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace CAR_SYSTEM
{
    public partial class BikeCustomerForm : UserControl
    {
        private int _editAcceptNo = -1;
        private bool IsEditMode => _editAcceptNo > 0;

        public BikeCustomerForm()
        {
            InitializeComponent();
            EnsureColumns();
        }

        public BikeCustomerForm(int acceptNo)
        {
            InitializeComponent();
            _editAcceptNo = acceptNo;
            LoadForEdit();
        }

        private void EnsureColumns()
        {
            DBHelper db = new DBHelper();
            string[] cols = { "검사주기 TEXT", "결재구분 TEXT", "유효만료일 TEXT" };
            foreach (string col in cols)
            {
                using (SqliteConnection conn = db.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        using (SqliteCommand cmd = new SqliteCommand("ALTER TABLE 이륜접수 ADD COLUMN " + col, conn))
                            cmd.ExecuteNonQuery();
                    }
                    catch { }
                }
            }
        }

        private void LoadForEdit()
        {
            DBHelper db = new DBHelper();
            string query =
                "SELECT j.차량번호, j.검사주기, j.접수일시, j.유효만료일," +
                " j.수수료, j.결재구분, j.비고, c.차주명, c.연락처" +
                " FROM 이륜접수 j" +
                " INNER JOIN 차주 c ON j.차주번호 = c.차주번호" +
                " WHERE j.접수번호 = @acceptNo";

            DataTable dt = db.FetchData(query, new SqliteParameter[]
            {
                new SqliteParameter("@acceptNo", _editAcceptNo)
            });

            if (dt.Rows.Count == 0) return;
            DataRow row = dt.Rows[0];

            txtCarNo.Text     = CryptoHelper.Decrypt(row["차량번호"].ToString());
            txtOwnerName.Text = CryptoHelper.Decrypt(row["차주명"].ToString());
            txtPhone.Text     = CryptoHelper.Decrypt(row["연락처"].ToString());

            SetCombo(cmbCycle,   row["검사주기"]);
            SetCombo(cmbPayment, row["결재구분"]);

            if (row["접수일시"] != DBNull.Value &&
                DateTime.TryParse(row["접수일시"].ToString(), out DateTime parsed))
                dtpDate.Value = parsed;

            txtExpiry.Text = row["유효만료일"] == DBNull.Value ? "" : row["유효만료일"].ToString();
            txtMemo.Text   = row["비고"]       == DBNull.Value ? "" : row["비고"].ToString();

            if (row["수수료"] != DBNull.Value)
                cmbFee.Text = Convert.ToInt32(row["수수료"]).ToString("#,##0");
        }

        private void SetCombo(ComboBox cmb, object value)
        {
            if (value == null || value == DBNull.Value) { cmb.SelectedIndex = -1; return; }
            int idx = cmb.Items.IndexOf(value.ToString());
            cmb.SelectedIndex = idx >= 0 ? idx : -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string carNo     = txtCarNo.Text.Trim();
            string ownerName = txtOwnerName.Text.Trim();
            string phone     = txtPhone.Text.Trim();

            string cycle   = cmbCycle.SelectedItem?.ToString()   ?? "";
            string payment = cmbPayment.SelectedItem?.ToString() ?? "";
            string expiry  = txtExpiry.Text.Trim();
            string memo    = txtMemo.Text.Trim();

            if (string.IsNullOrEmpty(carNo) || string.IsNullOrEmpty(ownerName) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("차량번호, 차주명, 연락처를 입력하세요.", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int fee = 0;
            try { fee = Convert.ToInt32(cmbFee.Text.Replace(",", "")); } catch { }

            string encCarNo     = CryptoHelper.Encrypt(carNo);
            string encOwnerName = CryptoHelper.Encrypt(ownerName);
            string encPhone     = CryptoHelper.Encrypt(phone);
            string insertDate   = dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss");

            DBHelper db = new DBHelper();
            using (SqliteConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    long chajuNo = GetOrCreateChaju(conn, encOwnerName, encPhone);
                    if (chajuNo <= 0) { MessageBox.Show("차주 정보 처리 중 오류가 발생했습니다."); return; }

                    if (IsEditMode)
                    {
                        string query =
                            "UPDATE 이륜접수 SET 차주번호=@chajuNo, 차량번호=@carNo, 검사주기=@cycle," +
                            " 접수일시=@date, 유효만료일=@expiry, 수수료=@fee, 결재구분=@payment, 비고=@memo" +
                            " WHERE 접수번호=@acceptNo";

                        using (SqliteCommand cmd = new SqliteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@chajuNo",  chajuNo);
                            cmd.Parameters.AddWithValue("@carNo",    encCarNo);
                            cmd.Parameters.AddWithValue("@cycle",    cycle);
                            cmd.Parameters.AddWithValue("@date",     insertDate);
                            cmd.Parameters.AddWithValue("@expiry",   expiry);
                            cmd.Parameters.AddWithValue("@fee",      fee);
                            cmd.Parameters.AddWithValue("@payment",  payment);
                            cmd.Parameters.AddWithValue("@memo",     memo);
                            cmd.Parameters.AddWithValue("@acceptNo", _editAcceptNo);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("수정이 완료되었습니다.", "저장 완료",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var parentForm = this.FindForm();
                        if (parentForm != null) { parentForm.DialogResult = DialogResult.OK; parentForm.Close(); }
                    }
                    else
                    {
                        string query =
                            "INSERT INTO 이륜접수 (차주번호, 차량번호, 검사종류, 검사주기," +
                            " 접수일시, 유효만료일, 수수료, 결재구분, 진행상태, 비고)" +
                            " VALUES (@chajuNo, @carNo, '이륜차검사', @cycle," +
                            " @date, @expiry, @fee, @payment, '진행중', @memo)";

                        using (SqliteCommand cmd = new SqliteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@chajuNo", chajuNo);
                            cmd.Parameters.AddWithValue("@carNo",   encCarNo);
                            cmd.Parameters.AddWithValue("@cycle",   cycle);
                            cmd.Parameters.AddWithValue("@date",    insertDate);
                            cmd.Parameters.AddWithValue("@expiry",  expiry);
                            cmd.Parameters.AddWithValue("@fee",     fee);
                            cmd.Parameters.AddWithValue("@payment", payment);
                            cmd.Parameters.AddWithValue("@memo",    memo);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("이륜 접수가 완료되었습니다.", "저장 완료",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("저장 오류: " + ex.Message);
                }
            }
        }

        private long GetOrCreateChaju(SqliteConnection conn, string encName, string encPhone)
        {
            string selectQuery = "SELECT 차주번호 FROM 차주 WHERE 차주명 = @name AND 연락처 = @phone LIMIT 1";
            using (SqliteCommand selectCmd = new SqliteCommand(selectQuery, conn))
            {
                selectCmd.Parameters.AddWithValue("@name",  encName);
                selectCmd.Parameters.AddWithValue("@phone", encPhone);
                object found = selectCmd.ExecuteScalar();
                if (found != null && found != DBNull.Value)
                    return Convert.ToInt64(found);
            }

            string insertQuery = "INSERT INTO 차주 (차주명, 연락처) VALUES (@name, @phone)";
            using (SqliteCommand insertCmd = new SqliteCommand(insertQuery, conn))
            {
                insertCmd.Parameters.AddWithValue("@name",  encName);
                insertCmd.Parameters.AddWithValue("@phone", encPhone);
                insertCmd.ExecuteNonQuery();
            }

            using (SqliteCommand lastIdCmd = new SqliteCommand("SELECT last_insert_rowid()", conn))
            {
                return Convert.ToInt64(lastIdCmd.ExecuteScalar());
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtCarNo.Clear();
            txtOwnerName.Clear();
            txtPhone.Clear();
            cmbCycle.SelectedIndex    = -1;
            dtpDate.Value             = DateTime.Now;
            txtExpiry.Clear();
            cmbFee.SelectedIndex      = 0;
            cmbPayment.SelectedIndex  = -1;
            txtMemo.Clear();
        }
    }
}
