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
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace CAR_SYSTEM
{
    public partial class CustomerForm : UserControl
    {
        public CustomerForm()
        {
            InitializeComponent();
            EnsureColumns();
        }

        private void EnsureColumns()
        {
            DBHelper db = new DBHelper();
            string[] cols = { "구동방식 TEXT", "배출가스 TEXT", "검사주기 TEXT", "결재구분 TEXT", "유효만료일 TEXT" };
            foreach (string col in cols)
            {
                using (SqliteConnection conn = db.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        using (SqliteCommand cmd = new SqliteCommand("ALTER TABLE 접수 ADD COLUMN " + col, conn))
                            cmd.ExecuteNonQuery();
                    }
                    catch { }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string carNo     = txtCarNo.Text.Trim();
            string ownerName = txtOwnerName.Text.Trim();
            string phone     = txtPhone.Text.Trim();

            string inspType = "";
            if (cmbType.SelectedItem != null) inspType = cmbType.SelectedItem.ToString();
            string fuel = "";
            if (cmbFuel.SelectedItem != null) fuel = cmbFuel.SelectedItem.ToString();
            string drive = "";
            if (cmbDrive.SelectedItem != null) drive = cmbDrive.SelectedItem.ToString();
            string emission = "";
            if (cmbEmission.SelectedItem != null) emission = cmbEmission.SelectedItem.ToString();
            string cycle = "";
            if (cmbCycle.SelectedItem != null) cycle = cmbCycle.SelectedItem.ToString();
            string payment = "";
            if (cmbPayment.SelectedItem != null) payment = cmbPayment.SelectedItem.ToString();

            string expiry = txtExpiry.Text.Trim();
            string memo   = txtMemo.Text.Trim();

            if (string.IsNullOrEmpty(carNo) || string.IsNullOrEmpty(ownerName) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("차량번호, 차주명, 연락처를 입력하세요.", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(inspType) || string.IsNullOrEmpty(fuel))
            {
                MessageBox.Show("검사종류와 유종을 선택하세요.", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int fee = 0;
            try { fee = Convert.ToInt32(cmbFee.Text.Replace(",", "")); }
            catch { fee = 0; }

            string encCarNo     = CryptoHelper.Encrypt(carNo);
            string encOwnerName = CryptoHelper.Encrypt(ownerName);
            string encPhone     = CryptoHelper.Encrypt(phone);

            DBHelper db = new DBHelper();

            using (SqliteConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    long chajuNo = GetOrCreateChaju(conn, encOwnerName, encPhone);
                    if (chajuNo <= 0)
                    {
                        MessageBox.Show("차주 정보 처리 중 오류가 발생했습니다.");
                        return;
                    }

                    string insertDate = dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss");

                    string query =
                        "INSERT INTO 접수 (차주번호, 차량번호, 검사종류, 유종, 구동방식, 배출가스, 검사주기," +
                        " 접수일시, 유효만료일, 수수료, 결재구분, 진행상태, 비고)" +
                        " VALUES (@chajuNo, @carNo, @inspType, @fuel, @drive, @emission, @cycle," +
                        " @date, @expiry, @fee, @payment, @state, @memo)";

                    using (SqliteCommand cmd = new SqliteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@chajuNo",  chajuNo);
                        cmd.Parameters.AddWithValue("@carNo",    encCarNo);
                        cmd.Parameters.AddWithValue("@inspType", inspType);
                        cmd.Parameters.AddWithValue("@fuel",     fuel);
                        cmd.Parameters.AddWithValue("@drive",    drive);
                        cmd.Parameters.AddWithValue("@emission", emission);
                        cmd.Parameters.AddWithValue("@cycle",    cycle);
                        cmd.Parameters.AddWithValue("@date",     insertDate);
                        cmd.Parameters.AddWithValue("@expiry",   expiry);
                        cmd.Parameters.AddWithValue("@fee",      fee);
                        cmd.Parameters.AddWithValue("@payment",  payment);
                        cmd.Parameters.AddWithValue("@state",    "진행중");
                        cmd.Parameters.AddWithValue("@memo",     memo);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("접수가 완료되었습니다.", "저장 완료",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
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
            cmbType.SelectedIndex     = -1;
            cmbFuel.SelectedIndex     = -1;
            cmbDrive.SelectedIndex    = -1;
            cmbEmission.SelectedIndex = -1;
            cmbCycle.SelectedIndex    = -1;
            dtpDate.Value             = DateTime.Now;
            txtExpiry.Clear();
            cmbFee.SelectedIndex      = 0;
            cmbPayment.SelectedIndex  = -1;
            txtMemo.Clear();
        }
    }
}
