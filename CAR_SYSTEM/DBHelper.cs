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
using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CAR_SYSTEM
{
    public class DBHelper
    {
        private string _dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "CAR SYSTEM", "app.db");

        private string GetConnectionString()
        {
            return "Data Source=" + _dbPath;
        }

        public SqliteConnection GetConnection()
        {
            return new SqliteConnection(GetConnectionString());
        }

        public void InitializeDatabase()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_dbPath));
            bool isNew = !File.Exists(_dbPath);

            using (SqliteConnection conn = GetConnection())
            {
                conn.Open();

                if (isNew)
                {
                    string schemaPath = Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "Resources", "schema.sql");

                    if (!File.Exists(schemaPath))
                    {
                        MessageBox.Show("schema.sql 파일을 찾을 수 없습니다: " + schemaPath);
                        return;
                    }

                    string sql = File.ReadAllText(schemaPath, System.Text.Encoding.UTF8);

                    string[] statements = sql.Split(new string[] { ";\r\n", ";\n", ";" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string stmt in statements)
                    {
                        string trimmed = stmt.Trim();
                        if (!string.IsNullOrEmpty(trimmed) && !trimmed.StartsWith("--"))
                        {
                            try
                            {
                                using (SqliteCommand cmd = new SqliteCommand(trimmed, conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        public void AdminInitiate()
        {
            string check = "SELECT COUNT(*) FROM Admins WHERE username = 'admin'";
            object result = ExecuteScalar(check, null);
            long count = 0;
            if (result != null)
                count = Convert.ToInt64(result);

            if (count == 0)
            {
                string insert = "INSERT INTO Admins (username, password) VALUES ('admin', 'Admin21')";
                ExecuteQuery(insert, null);
            }
        }

        public DataTable FetchData(string query, SqliteParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqliteConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqliteCommand cmd = new SqliteCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (SqliteParameter p in parameters)
                                cmd.Parameters.Add(p);
                        }

                        using (SqliteDataReader reader = cmd.ExecuteReader())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                                dt.Columns.Add(reader.GetName(i));

                            while (reader.Read())
                            {
                                DataRow row = dt.NewRow();
                                for (int i = 0; i < reader.FieldCount; i++)
                                    row[i] = reader.IsDBNull(i) ? (object)DBNull.Value : reader.GetValue(i);
                                dt.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB 오류: " + ex.Message);
            }
            return dt;
        }

        public bool ExecuteQuery(string query, SqliteParameter[] parameters)
        {
            try
            {
                using (SqliteConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqliteCommand cmd = new SqliteCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (SqliteParameter p in parameters)
                                cmd.Parameters.Add(p);
                        }

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB 오류: " + ex.Message);
                return false;
            }
        }

        public object ExecuteScalar(string query, SqliteParameter[] parameters)
        {
            try
            {
                using (SqliteConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqliteCommand cmd = new SqliteCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (SqliteParameter p in parameters)
                                cmd.Parameters.Add(p);
                        }

                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB 오류: " + ex.Message);
                return null;
            }
        }
    }
}
