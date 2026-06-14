/*
 * CAR SYSTEM v1.0 - Handoff Edition
 * ──────────────────────────────────
 * Based on: Rent_Auto_Desktop (MIT License)
 * Original: Clarence Sabangan (Yurei21)
 *           https://github.com/Yurei21/Rent_Auto_Desktop
 *
 * Provider: chan dev
 * GitHub:   https://github.com/workingts/carsystem
 */
namespace CAR_SYSTEM
{
    partial class Admin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle              = new Label();
            lblSub                = new Label();
            label2                = new Label();
            textBox1              = new TextBox();
            label1                = new Label();
            textBox2              = new TextBox();
            checkBoxShowPassword  = new CheckBox();
            signinButton          = new Button();
            closeButton           = new Button();
            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize  = true;
            lblTitle.Font      = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location  = new Point(140, 55);
            lblTitle.Name      = "lblTitle";
            lblTitle.TabIndex  = 0;
            lblTitle.Text      = "CAR SYSTEM";

            // lblSub
            lblSub.AutoSize  = true;
            lblSub.Font      = new Font("Segoe UI", 10F);
            lblSub.ForeColor = Color.Silver;
            lblSub.Location  = new Point(163, 97);
            lblSub.Name      = "lblSub";
            lblSub.TabIndex  = 1;
            lblSub.Text      = "차량검사 접수 관리";

            // label2 — 아이디
            label2.AutoSize  = true;
            label2.Font      = new Font("Segoe UI", 9F);
            label2.ForeColor = Color.Silver;
            label2.Location  = new Point(100, 150);
            label2.Name      = "label2";
            label2.TabIndex  = 2;
            label2.Text      = "아이디 (Admin ID)";

            // textBox1
            textBox1.BackColor   = Color.FromArgb(38, 38, 38);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font        = new Font("Segoe UI", 11F);
            textBox1.ForeColor   = Color.White;
            textBox1.Location    = new Point(100, 170);
            textBox1.Name        = "textBox1";
            textBox1.Size        = new Size(280, 27);
            textBox1.TabIndex    = 3;
            textBox1.KeyDown    += textBox1_KeyDown;

            // label1 — 비밀번호
            label1.AutoSize  = true;
            label1.Font      = new Font("Segoe UI", 9F);
            label1.ForeColor = Color.Silver;
            label1.Location  = new Point(100, 215);
            label1.Name      = "label1";
            label1.TabIndex  = 4;
            label1.Text      = "비밀번호 (Password)";

            // textBox2
            textBox2.BackColor              = Color.FromArgb(38, 38, 38);
            textBox2.BorderStyle            = BorderStyle.FixedSingle;
            textBox2.Font                   = new Font("Segoe UI", 11F);
            textBox2.ForeColor              = Color.White;
            textBox2.Location               = new Point(100, 235);
            textBox2.Name                   = "textBox2";
            textBox2.Size                   = new Size(280, 27);
            textBox2.TabIndex               = 5;
            textBox2.UseSystemPasswordChar  = true;
            textBox2.KeyDown               += textBox2_KeyDown;

            // checkBoxShowPassword
            checkBoxShowPassword.AutoSize  = true;
            checkBoxShowPassword.Font      = new Font("Segoe UI", 9F);
            checkBoxShowPassword.ForeColor = Color.Silver;
            checkBoxShowPassword.Location  = new Point(100, 270);
            checkBoxShowPassword.Name      = "checkBoxShowPassword";
            checkBoxShowPassword.TabIndex  = 6;
            checkBoxShowPassword.Text      = "비밀번호 표시";
            checkBoxShowPassword.UseVisualStyleBackColor = false;
            checkBoxShowPassword.BackColor = Color.Transparent;
            checkBoxShowPassword.CheckedChanged += checkBoxShowPassword_CheckedChanged;

            // signinButton
            signinButton.BackColor = Color.SlateBlue;
            signinButton.Cursor    = Cursors.Hand;
            signinButton.FlatAppearance.BorderSize = 0;
            signinButton.FlatStyle  = FlatStyle.Flat;
            signinButton.Font       = new Font("Segoe UI", 11F, FontStyle.Bold);
            signinButton.ForeColor  = Color.White;
            signinButton.Location   = new Point(100, 315);
            signinButton.Name       = "signinButton";
            signinButton.Size       = new Size(280, 40);
            signinButton.TabIndex   = 7;
            signinButton.Text       = "로  그  인";
            signinButton.UseVisualStyleBackColor = false;
            signinButton.Click += signinButton_Click;

            // closeButton (X 상단 우측)
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle  = FlatStyle.Flat;
            closeButton.Font       = new Font("Segoe UI", 10F, FontStyle.Bold);
            closeButton.ForeColor  = Color.Gray;
            closeButton.Location   = new Point(451, 8);
            closeButton.Name       = "closeButton";
            closeButton.Size       = new Size(26, 26);
            closeButton.TabIndex   = 8;
            closeButton.Text       = "✕";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;

            // Admin
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(18, 18, 18);
            ClientSize          = new Size(480, 390);
            Controls.Add(closeButton);
            Controls.Add(lblTitle);
            Controls.Add(lblSub);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(checkBoxShowPassword);
            Controls.Add(signinButton);
            FormBorderStyle = FormBorderStyle.None;
            Name            = "Admin";
            StartPosition   = FormStartPosition.CenterScreen;
            Text            = "CAR SYSTEM";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label    lblTitle;
        private Label    lblSub;
        private Label    label2;
        private TextBox  textBox1;
        private Label    label1;
        private TextBox  textBox2;
        private CheckBox checkBoxShowPassword;
        private Button   signinButton;
        private Button   closeButton;
    }
}
