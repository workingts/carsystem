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
using System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace CAR_SYSTEM
{
    public partial class ReportViewer : UserControl
    {
        private DataTable _printTable = null;

        public ReportViewer()
        {
            InitializeComponent();
            SetupGrid();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value   = DateTime.Now;
        }

        private void SetupGrid()
        {
            dgvSummary.Columns.Clear();

            AddCol("기간",   "기간",   120, "Left");
            AddCol("6.5만",  "cnt65",   62, "Right");
            AddCol("5.5만",  "cnt55",   62, "Right");
            AddCol("5.0만",  "cnt50",   62, "Right");
            AddCol("4.0만",  "cnt40",   62, "Right");
            AddCol("3.0만",  "cnt30",   62, "Right");
            AddCol("기타",   "cnt기타", 55, "Right");
            AddCol("수납건수","수납건수",70, "Right");
            AddCol("총건수", "총건수",  65, "Right");
            AddCol("수납금액","수납금액",90, "Right");

            dgvSummary.AutoSizeColumnsMode           = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSummary.DefaultCellStyle.BackColor    = Color.FromArgb(30, 30, 30);
            dgvSummary.DefaultCellStyle.ForeColor    = Color.White;
            dgvSummary.DefaultCellStyle.Font         = new Font("Segoe UI", 10F);
            dgvSummary.CellBorderStyle               = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSummary.DefaultCellStyle.SelectionBackColor = Color.FromArgb(80, 80, 130);
            dgvSummary.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSummary.CellFormatting               += dgvSummary_CellFormatting;
        }

        private void AddCol(string header, string prop, int fillWeight, string align)
        {
            var col = new DataGridViewTextBoxColumn();
            col.HeaderText       = header;
            col.DataPropertyName = prop;
            col.Name             = prop;
            col.FillWeight       = fillWeight;
            col.DefaultCellStyle.Alignment =
                align == "Right" ? DataGridViewContentAlignment.MiddleRight
                                 : DataGridViewContentAlignment.MiddleLeft;
            dgvSummary.Columns.Add(col);
        }

        private void dgvSummary_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value) return;
            string colName = dgvSummary.Columns[e.ColumnIndex].Name;

            if (colName == "수납금액")
            {
                long val = 0;
                if (long.TryParse(e.Value.ToString(), out val))
                {
                    e.Value = val.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
            else if (colName != "기간")
            {
                // 숫자 컬럼 0이면 빈칸
                long val = 0;
                if (long.TryParse(e.Value.ToString(), out val))
                {
                    e.Value = val == 0 ? "" : val.ToString("N0");
                    e.FormattingApplied = true;
                }
            }

            // 합계 행 강조
            DataTable dt = dgvSummary.DataSource as DataTable;
            if (dt != null && e.RowIndex == dt.Rows.Count - 1)
            {
                e.CellStyle.BackColor = Color.FromArgb(50, 50, 80);
                e.CellStyle.Font      = new Font(dgvSummary.Font, FontStyle.Bold);
                e.CellStyle.ForeColor = Color.Yellow;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string table = rbCar.Checked ? "접수" : "이륜접수";

            string groupBy;
            if (cmbPeriod.SelectedIndex == 1)
                groupBy = "strftime('%Y-%m', 접수일시)";
            else if (cmbPeriod.SelectedIndex == 2)
                groupBy = "strftime('%Y', 접수일시)";
            else
                groupBy = "strftime('%Y-%m-%d', 접수일시)";

            string start = dtpStart.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string end   = dtpEnd.Value.ToString("yyyy-MM-dd")   + " 23:59:59";

            string query =
                "SELECT " + groupBy + " AS 기간," +
                " SUM(CASE WHEN 수수료=65000 THEN 1 ELSE 0 END) AS cnt65," +
                " SUM(CASE WHEN 수수료=55000 THEN 1 ELSE 0 END) AS cnt55," +
                " SUM(CASE WHEN 수수료=50000 THEN 1 ELSE 0 END) AS cnt50," +
                " SUM(CASE WHEN 수수료=40000 THEN 1 ELSE 0 END) AS cnt40," +
                " SUM(CASE WHEN 수수료=30000 THEN 1 ELSE 0 END) AS cnt30," +
                " SUM(CASE WHEN 수수료 NOT IN (65000,55000,50000,40000,30000) AND 수수료>0 THEN 1 ELSE 0 END) AS cnt기타," +
                " SUM(CASE WHEN 수수료>0 THEN 1 ELSE 0 END) AS 수납건수," +
                " COUNT(*) AS 총건수," +
                " SUM(CASE WHEN 수수료 IS NOT NULL THEN 수수료 ELSE 0 END) AS 수납금액" +
                " FROM " + table +
                " WHERE 접수일시 BETWEEN @start AND @end" +
                " GROUP BY " + groupBy +
                " ORDER BY 기간";

            SqliteParameter[] parameters = new SqliteParameter[]
            {
                new SqliteParameter("@start", start),
                new SqliteParameter("@end",   end)
            };

            DBHelper db = new DBHelper();
            DataTable dt = db.FetchData(query, parameters);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("조회된 데이터가 없습니다.", "집계표",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvSummary.DataSource = null;
                _printTable = null;
                return;
            }

            // 합계 행 추가
            long t65=0, t55=0, t50=0, t40=0, t30=0, t기타=0, t수납=0, t총=0, t금액=0;
            int i = 0;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                t65   += ToLong(dt.Rows[i]["cnt65"]);
                t55   += ToLong(dt.Rows[i]["cnt55"]);
                t50   += ToLong(dt.Rows[i]["cnt50"]);
                t40   += ToLong(dt.Rows[i]["cnt40"]);
                t30   += ToLong(dt.Rows[i]["cnt30"]);
                t기타 += ToLong(dt.Rows[i]["cnt기타"]);
                t수납 += ToLong(dt.Rows[i]["수납건수"]);
                t총   += ToLong(dt.Rows[i]["총건수"]);
                t금액 += ToLong(dt.Rows[i]["수납금액"]);
            }

            DataRow totalRow = dt.NewRow();
            totalRow["기간"]   = "합  계";
            totalRow["cnt65"]  = t65;
            totalRow["cnt55"]  = t55;
            totalRow["cnt50"]  = t50;
            totalRow["cnt40"]  = t40;
            totalRow["cnt30"]  = t30;
            totalRow["cnt기타"] = t기타;
            totalRow["수납건수"] = t수납;
            totalRow["총건수"]  = t총;
            totalRow["수납금액"] = t금액;
            dt.Rows.Add(totalRow);

            _printTable = dt;
            dgvSummary.DataSource = dt;
        }

        private static long ToLong(object val)
        {
            if (val == null || val == DBNull.Value) return 0;
            long result = 0;
            long.TryParse(val.ToString(), out result);
            return result;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_printTable == null || _printTable.Rows.Count == 0)
            {
                MessageBox.Show("먼저 조회를 실행하세요.");
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = true;
            pd.PrintPage += PrintPage;

            PrintDialog dlg = new PrintDialog();
            dlg.Document = pd;
            if (dlg.ShowDialog() == DialogResult.OK)
                pd.Print();
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont   = new Font("맑은 고딕", 13F, FontStyle.Bold);
            Font headerFont  = new Font("맑은 고딕",  9F, FontStyle.Bold);
            Font bodyFont    = new Font("맑은 고딕",  9F);
            SolidBrush hdrBrush  = new SolidBrush(Color.FromArgb(68, 114, 196));
            SolidBrush altBrush  = new SolidBrush(Color.FromArgb(240, 240, 250));

            try
            {
                string vehicleType = rbCar.Checked ? "자동차" : "이륜";
                string period = cmbPeriod.SelectedItem != null ? cmbPeriod.SelectedItem.ToString() : "일별";
                string title  = vehicleType + " 집계표 (" + period + ")  " +
                                dtpStart.Value.ToString("yyyy-MM-dd") + " ~ " +
                                dtpEnd.Value.ToString("yyyy-MM-dd");

                float x    = 40F;
                float y    = 40F;
                float rowH = 20F;

                float[] colW    = { 110F, 58F, 58F, 58F, 58F, 58F, 50F, 68F, 60F, 90F };
                string[] headers = { "기간", "6.5만", "5.5만", "5.0만", "4.0만", "3.0만", "기타", "수납건수", "총건수", "수납금액" };
                string[] props   = { "기간","cnt65","cnt55","cnt50","cnt40","cnt30","cnt기타","수납건수","총건수","수납금액" };

                g.DrawString(title, titleFont, Brushes.Black, x, y);
                y += 28F;

                float cx = x;
                for (int h = 0; h < headers.Length; h++)
                {
                    g.FillRectangle(hdrBrush, cx, y, colW[h], rowH);
                    g.DrawString(headers[h], headerFont, Brushes.White, cx + 2, y + 3);
                    g.DrawRectangle(Pens.White, cx, y, colW[h], rowH);
                    cx += colW[h];
                }
                y += rowH;

                if (_printTable != null)
                {
                    for (int i = 0; i < _printTable.Rows.Count; i++)
                    {
                        DataRow row = _printTable.Rows[i];
                        bool isTotal = i == _printTable.Rows.Count - 1;
                        Brush bg  = isTotal ? Brushes.LightYellow : (i % 2 == 0 ? Brushes.White : altBrush);
                        Font  fnt = isTotal ? headerFont : bodyFont;

                        cx = x;
                        for (int j = 0; j < props.Length; j++)
                        {
                            string cellVal = row[props[j]] == DBNull.Value ? "" : row[props[j]].ToString();
                            if (j > 0 && j < props.Length - 1)
                            {
                                long n = 0;
                                cellVal = long.TryParse(cellVal, out n) ? (n == 0 ? "" : n.ToString("N0")) : cellVal;
                            }
                            else if (j == props.Length - 1)
                            {
                                long n = 0;
                                cellVal = long.TryParse(cellVal, out n) ? n.ToString("N0") : cellVal;
                            }

                            g.FillRectangle(bg, cx, y, colW[j], rowH);
                            g.DrawString(cellVal, fnt, Brushes.Black, cx + 2, y + 3);
                            g.DrawRectangle(Pens.Gray, cx, y, colW[j], rowH);
                            cx += colW[j];
                        }
                        y += rowH;
                    }
                }
            }
            finally
            {
                titleFont.Dispose();
                headerFont.Dispose();
                bodyFont.Dispose();
                hdrBrush.Dispose();
                altBrush.Dispose();
            }
        }
    }
}
