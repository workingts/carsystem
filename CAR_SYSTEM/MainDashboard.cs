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
    public partial class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeComponent();
            this.Load += MainDashboard_Load;
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text            = "집계표";
            frm.BackColor       = Color.FromArgb(18, 18, 18);
            frm.WindowState     = FormWindowState.Maximized;
            frm.FormBorderStyle = FormBorderStyle.Sizable;
            ReportViewer rv     = new ReportViewer();
            rv.Dock             = DockStyle.Fill;
            frm.Controls.Add(rv);
            frm.ShowDialog(this);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text            = "수수료내역";
            frm.BackColor       = Color.FromArgb(18, 18, 18);
            frm.WindowState     = FormWindowState.Maximized;
            frm.FormBorderStyle = FormBorderStyle.Sizable;
            PaymentViewer pv    = new PaymentViewer();
            pv.Dock             = DockStyle.Fill;
            frm.Controls.Add(pv);
            frm.ShowDialog(this);
        }

        private void btnExpiry_Click(object sender, EventArgs e)
        {
            ExpiryListForm frm  = new ExpiryListForm();
            frm.WindowState     = FormWindowState.Maximized;
            frm.ShowDialog(this);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            new AccountForm().ShowDialog(this);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog(this);
        }
    }
}
