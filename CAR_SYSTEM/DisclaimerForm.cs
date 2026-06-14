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
using System.Drawing;
using System.Windows.Forms;

namespace CAR_SYSTEM
{
    public class DisclaimerForm : Form
    {
        public bool Accepted { get; private set; } = false;

        public DisclaimerForm()
        {
            BuildUI();
        }

        private void BuildUI()
        {
            SuspendLayout();

            this.Text            = "CAR SYSTEM — 이용 동의 및 면책 고지";
            this.ClientSize      = new Size(620, 560);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.BackColor       = Color.FromArgb(18, 18, 18);

            Label lblTitle = new Label();
            lblTitle.Text      = "CAR SYSTEM  —  차량검사 접수 관리";
            lblTitle.Font      = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize  = true;
            lblTitle.Location  = new Point(20, 20);
            this.Controls.Add(lblTitle);

            Label lblVer = new Label();
            lblVer.Text      = "v1.0  |  Based on Car Rental System (MIT License)";
            lblVer.Font      = new Font("Segoe UI", 9F);
            lblVer.ForeColor = Color.Silver;
            lblVer.AutoSize  = true;
            lblVer.Location  = new Point(22, 52);
            this.Controls.Add(lblVer);

            RichTextBox rtb = new RichTextBox();
            rtb.Location      = new Point(20, 85);
            rtb.Size          = new Size(578, 390);
            rtb.ReadOnly      = true;
            rtb.BackColor     = Color.FromArgb(28, 28, 28);
            rtb.ForeColor     = Color.WhiteSmoke;
            rtb.Font          = new Font("맑은 고딕", 10F);
            rtb.BorderStyle   = BorderStyle.None;
            rtb.ScrollBars    = RichTextBoxScrollBars.Vertical;
            rtb.Text          = GetDisclaimerText();
            this.Controls.Add(rtb);

            Button btnAccept = new Button();
            btnAccept.Text      = "동 의 하 고 시 작";
            btnAccept.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAccept.ForeColor = Color.White;
            btnAccept.BackColor = Color.SlateBlue;
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.FlatAppearance.BorderSize = 0;
            btnAccept.Size      = new Size(160, 38);
            btnAccept.Location  = new Point(270, 492);
            btnAccept.Cursor    = Cursors.Hand;
            btnAccept.Click    += (s, e) => { Accepted = true; this.Close(); };
            this.Controls.Add(btnAccept);

            Button btnDecline = new Button();
            btnDecline.Text      = "종 료";
            btnDecline.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDecline.ForeColor = Color.White;
            btnDecline.BackColor = Color.FromArgb(80, 80, 80);
            btnDecline.FlatStyle = FlatStyle.Flat;
            btnDecline.FlatAppearance.BorderSize = 0;
            btnDecline.Size      = new Size(90, 38);
            btnDecline.Location  = new Point(440, 492);
            btnDecline.Cursor    = Cursors.Hand;
            btnDecline.Click    += (s, e) => { Accepted = false; this.Close(); };
            this.Controls.Add(btnDecline);

            ResumeLayout(false);
        }

        private static string GetDisclaimerText()
        {
            return
"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n" +
"  원본 소스 및 라이선스 고지 (Original Source Notice)\n" +
"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n\n" +
"본 소프트웨어(CAR SYSTEM)는 오픈소스 프로젝트\n" +
"\"Car Rental System\" 을 기반으로 재구성한 차량검사 접수 관리 프로그램입니다.\n\n" +
"원본 프로젝트는 MIT 라이선스 하에 배포되었으며, 본 소프트웨어도\n" +
"동일한 MIT 라이선스 조건을 준수합니다.\n" +
"라이선스 전문은 프로그램 폴더 내 LICENSE 파일을 참조하십시오.\n\n" +
"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n" +
"  데이터 백업 권고 (Data Backup Recommendation)\n" +
"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n\n" +
"본 프로그램의 데이터는 로컬 SQLite 데이터베이스(app.db)에 저장됩니다.\n\n" +
"⚠  데이터 보호를 위해 반드시 아래 사항을 준수하십시오:\n\n" +
"  1. CSV 내보내기 기능을 이용하여 데이터를 정기적으로 추출하고,\n" +
"     MS Excel 또는 한글(HWP) 등 별도 오피스 파일로 저장하십시오.\n\n" +
"  2. app.db 파일을 USB·외장 드라이브·클라우드 스토리지 등에\n" +
"     주기적으로 백업하십시오.\n\n" +
"  3. 운영체제 재설치, PC 교체, 저장 장치 오류 등이 예상될 경우\n" +
"     반드시 사전에 백업을 완료하십시오.\n\n" +
"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n" +
"  면책 조항 (Disclaimer of Liability)\n" +
"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n\n" +
"본 소프트웨어는 \"있는 그대로(AS IS)\" 제공됩니다.\n\n" +
"개발자 및 배포자는 다음 각 호의 사유로 발생하는 어떠한 손해에 대해서도\n" +
"법적·도의적 책임을 지지 않습니다:\n\n" +
"  • 소프트웨어 결함·버그·예기치 않은 동작으로 인한 데이터 손실\n" +
"  • 데이터베이스 파일(app.db) 손상, 삭제, 또는 접근 불가\n" +
"  • 암호화 키 분실 또는 변경으로 인한 데이터 복구 불가\n" +
"  • 운영체제·하드웨어 오류로 인한 데이터 유실\n" +
"  • 백업 미실시로 인한 데이터 복구 불가 상황\n" +
"  • 제3자의 무단 접근 또는 보안 침해\n" +
"  • 본 소프트웨어 사용으로 인한 직접적·간접적·파생적 손해\n\n" +
"본 소프트웨어를 계속 사용함으로써 귀하는 위 면책 조항에 동의한 것으로\n" +
"간주됩니다.\n\n" +
"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n";
        }
    }
}
