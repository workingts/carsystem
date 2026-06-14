using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace CAR_SYSTEM
{
    public class AccountForm : Form
    {
        private TextBox txtCurrentId;
        private TextBox txtCurrentPw;
        private TextBox txtNewId;
        private TextBox txtNewPw;
        private TextBox txtConfirmPw;

        public AccountForm()
        {
            BuildUI();
        }

        private void BuildUI()
        {
            SuspendLayout();

            this.Text            = "계정 관리";
            this.ClientSize      = new Size(380, 340);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.StartPosition   = FormStartPosition.CenterParent;
            this.BackColor       = Color.FromArgb(18, 18, 18);

            int labelW = 100;
            int fieldX = 120;
            int fieldW = 220;
            int y      = 24;
            int rowH   = 36;

            // 현재 아이디
            AddLabel("현재 아이디", labelX: 20, labelY: y);
            txtCurrentId           = AddTextBox(fieldX, y, fieldW);

            y += rowH;

            // 현재 비밀번호
            AddLabel("현재 비밀번호", labelX: 20, labelY: y);
            txtCurrentPw                  = AddTextBox(fieldX, y, fieldW);
            txtCurrentPw.PasswordChar     = '*';

            y += rowH + 10;

            // 구분선
            Panel sep      = new Panel();
            sep.BackColor  = Color.FromArgb(60, 60, 80);
            sep.Location   = new Point(20, y);
            sep.Size       = new Size(338, 1);
            this.Controls.Add(sep);

            y += 14;

            // 새 아이디
            AddLabel("새 아이디", labelX: 20, labelY: y);
            txtNewId = AddTextBox(fieldX, y, fieldW);

            y += rowH;

            // 새 비밀번호
            AddLabel("새 비밀번호", labelX: 20, labelY: y);
            txtNewPw               = AddTextBox(fieldX, y, fieldW);
            txtNewPw.PasswordChar  = '*';

            y += rowH;

            // 비밀번호 확인
            AddLabel("비밀번호 확인", labelX: 20, labelY: y);
            txtConfirmPw              = AddTextBox(fieldX, y, fieldW);
            txtConfirmPw.PasswordChar = '*';

            y += rowH + 16;

            // [변경] 버튼
            Button btnChange       = new Button();
            btnChange.Text         = "변 경";
            btnChange.Font         = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChange.ForeColor    = Color.White;
            btnChange.BackColor    = Color.SlateBlue;
            btnChange.FlatStyle    = FlatStyle.Flat;
            btnChange.FlatAppearance.BorderSize = 0;
            btnChange.Size         = new Size(110, 34);
            btnChange.Location     = new Point(118, y);
            btnChange.Cursor       = Cursors.Hand;
            btnChange.Click       += btnChange_Click;
            this.Controls.Add(btnChange);

            // [취소] 버튼
            Button btnCancel       = new Button();
            btnCancel.Text         = "취 소";
            btnCancel.Font         = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor    = Color.White;
            btnCancel.BackColor    = Color.FromArgb(70, 70, 70);
            btnCancel.FlatStyle    = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Size         = new Size(90, 34);
            btnCancel.Location     = new Point(238, y);
            btnCancel.Cursor       = Cursors.Hand;
            btnCancel.Click       += (s, e) => this.Close();
            this.Controls.Add(btnCancel);

            this.ClientSize = new Size(380, y + 60);

            ResumeLayout(false);
        }

        private void AddLabel(string text, int labelX, int labelY)
        {
            Label lbl      = new Label();
            lbl.Text       = text;
            lbl.Font       = new Font("맑은 고딕", 10F);
            lbl.ForeColor  = Color.WhiteSmoke;
            lbl.AutoSize   = true;
            lbl.Location   = new Point(labelX, labelY + 4);
            this.Controls.Add(lbl);
        }

        private TextBox AddTextBox(int x, int y, int w)
        {
            TextBox tb      = new TextBox();
            tb.Font         = new Font("맑은 고딕", 10F);
            tb.BackColor    = Color.FromArgb(36, 36, 50);
            tb.ForeColor    = Color.White;
            tb.BorderStyle  = BorderStyle.FixedSingle;
            tb.Location     = new Point(x, y);
            tb.Size         = new Size(w, 26);
            this.Controls.Add(tb);
            return tb;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string oldId  = txtCurrentId.Text.Trim();
            string oldPw  = txtCurrentPw.Text;
            string newId  = txtNewId.Text.Trim();
            string newPw  = txtNewPw.Text;
            string confPw = txtConfirmPw.Text;

            // 현재 자격증명 DB 검증
            DBHelper db = new DBHelper();
            string checkSql = "SELECT COUNT(*) FROM Admins WHERE username=@u AND password=@p";
            SqliteParameter[] checkParams =
            {
                new SqliteParameter("@u", oldId),
                new SqliteParameter("@p", oldPw)
            };
            object result = db.ExecuteScalar(checkSql, checkParams);
            long count = (result != null && result != DBNull.Value) ? Convert.ToInt64(result) : 0;

            if (count == 0)
            {
                MessageBox.Show("현재 아이디 또는 비밀번호가 일치하지 않습니다.",
                    "인증 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrentPw.Clear();
                txtCurrentPw.Focus();
                return;
            }

            // 새 아이디 공백 체크
            if (string.IsNullOrWhiteSpace(newId))
            {
                MessageBox.Show("새 아이디를 입력하세요.",
                    "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewId.Focus();
                return;
            }

            // 새 비밀번호 일치 체크
            if (newPw != confPw)
            {
                MessageBox.Show("새 비밀번호와 비밀번호 확인이 일치하지 않습니다.",
                    "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPw.Clear();
                txtConfirmPw.Focus();
                return;
            }

            // UPDATE
            string updateSql = "UPDATE Admins SET username=@newId, password=@newPw WHERE username=@oldId AND password=@oldPw";
            SqliteParameter[] updateParams =
            {
                new SqliteParameter("@newId",  newId),
                new SqliteParameter("@newPw",  newPw),
                new SqliteParameter("@oldId",  oldId),
                new SqliteParameter("@oldPw",  oldPw)
            };

            bool ok = db.ExecuteQuery(updateSql, updateParams);
            if (ok)
            {
                MessageBox.Show("변경완료. 다시 로그인해 주세요.",
                    "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                Application.Restart();
            }
        }
    }
}
