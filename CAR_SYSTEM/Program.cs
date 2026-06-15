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
namespace CAR_SYSTEM
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            DBHelper db = new DBHelper();
            db.InitializeDatabase();
            db.AdminInitiate();

            string appDataDir  = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "CAR SYSTEM");
            string acceptedFlag = Path.Combine(appDataDir, "accepted.flag");

            if (!File.Exists(acceptedFlag))
            {
                DisclaimerForm disclaimer = new DisclaimerForm();
                disclaimer.ShowDialog();
                if (!disclaimer.Accepted)
                    return;
                Directory.CreateDirectory(appDataDir);
                File.WriteAllText(acceptedFlag, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            Application.Run(new Admin());
        }
    }
}
