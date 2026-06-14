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
 * ❌ 레퍼런스 소스 파일 저작권 주장 불가
 * ❌ 제공자 책임 없음
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CAR_SYSTEM
{
    public class AboutForm : Form
    {
        public AboutForm()
        {
            BuildUI();
        }

        private void BuildUI()
        {
            SuspendLayout();

            this.Text            = "About — CAR SYSTEM";
            this.ClientSize      = new Size(500, 480);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.StartPosition   = FormStartPosition.CenterParent;
            this.BackColor       = Color.FromArgb(18, 18, 18);

            Label lblTitle = new Label();
            lblTitle.Text      = "CAR SYSTEM v1.0";
            lblTitle.Font      = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize  = true;
            lblTitle.Location  = new Point(30, 28);
            this.Controls.Add(lblTitle);

            Label lblEdition = new Label();
            lblEdition.Text      = "Handoff Edition";
            lblEdition.Font      = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblEdition.ForeColor = Color.SlateBlue;
            lblEdition.AutoSize  = true;
            lblEdition.Location  = new Point(34, 68);
            this.Controls.Add(lblEdition);

            Panel separator = new Panel();
            separator.BackColor = Color.FromArgb(60, 60, 80);
            separator.Location  = new Point(30, 100);
            separator.Size      = new Size(440, 1);
            this.Controls.Add(separator);

            RichTextBox rtb = new RichTextBox();
            rtb.Location    = new Point(30, 115);
            rtb.Size        = new Size(440, 265);
            rtb.ReadOnly    = true;
            rtb.BackColor   = Color.FromArgb(26, 26, 26);
            rtb.ForeColor   = Color.WhiteSmoke;
            rtb.Font        = new Font("맑은 고딕", 10F);
            rtb.BorderStyle = BorderStyle.None;
            rtb.Text        =
"기초 구조 및 마이그레이션 기반 제공\n" +
"추가 개발 및 완성은 수령자 몫입니다.\n\n" +
"Based on: Rent_Auto_Desktop (MIT License)\n" +
"Original: Clarence Sabangan (Yurei21)\n" +
"Provider: chan dev\n\n" +
"✅ 추가 개발 / 사업화 허용 (MIT 조건 내)\n" +
"❌ 레퍼런스 소스 파일 저작권 주장 불가\n" +
"❌ 제공자 책임 없음\n\n" +
"전체 조건: NOTICE.md 참조\n\n" +
"─────────────────────────────────────\n\n" +
"데이터 손실에 대해 제공자는 책임지지 않습니다.\n" +
"정기적으로 CSV 내보내기 및 MS Office 파일로\n" +
"별도 백업하시기 바랍니다.";
            this.Controls.Add(rtb);

            Button btnGithub = new Button();
            btnGithub.Text      = "GitHub 열기";
            btnGithub.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGithub.ForeColor = Color.White;
            btnGithub.BackColor = Color.FromArgb(36, 41, 46);
            btnGithub.FlatStyle = FlatStyle.Flat;
            btnGithub.FlatAppearance.BorderColor = Color.SlateBlue;
            btnGithub.FlatAppearance.BorderSize  = 1;
            btnGithub.Size      = new Size(140, 36);
            btnGithub.Location  = new Point(30, 400);
            btnGithub.Cursor    = Cursors.Hand;
            btnGithub.Click    += (s, e) =>
            {
                try
                {
                    Process.Start(new ProcessStartInfo("https://github.com/workingts/carsystem")
                    {
                        UseShellExecute = true
                    });
                }
                catch { }
            };
            this.Controls.Add(btnGithub);

            Button btnClose = new Button();
            btnClose.Text      = "닫 기";
            btnClose.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.BackColor = Color.FromArgb(60, 60, 60);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Size      = new Size(100, 36);
            btnClose.Location  = new Point(370, 400);
            btnClose.Cursor    = Cursors.Hand;
            btnClose.Click    += (s, e) => this.Close();
            this.Controls.Add(btnClose);

            ResumeLayout(false);
        }
    }
}
