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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            string adminUsername = textBox1.Text.Trim();
            string adminPassword = textBox2.Text;

            if (string.IsNullOrWhiteSpace(adminUsername) || string.IsNullOrWhiteSpace(adminPassword))
            {
                MessageBox.Show("아이디와 비밀번호를 입력하세요.", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DBHelper db = new DBHelper();
            string query = "SELECT COUNT(*) FROM Admins WHERE username = @username AND password = @password";
            SqliteParameter[] parameters =
            {
                new SqliteParameter("@username", adminUsername),
                new SqliteParameter("@password", adminPassword)
            };

            object result = db.ExecuteScalar(query, parameters);
            long count = (result != null && result != DBNull.Value) ? Convert.ToInt64(result) : 0;

            if (count > 0)
            {
                MainDashboard dashboard = new MainDashboard();
                dashboard.FormClosed += (s, args) => Application.Exit();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호가 틀렸습니다.", "로그인 실패",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Clear();
                textBox2.Focus();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                signinButton_Click(sender, e);
        }
    }
}
