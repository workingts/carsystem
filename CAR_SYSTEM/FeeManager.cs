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
using System.Collections.Generic;

namespace CAR_SYSTEM
{
    public static class FeeManager
    {
        public static Dictionary<string, int> 수수료표 = new Dictionary<string, int>()
        {
            { "정기_가솔린",           23000 },
            { "정기_디젤",             23000 },
            { "정기_LPG",              23000 },
            { "정기_가솔린 하이브리드", 23000 },
            { "정기_LPG 하이브리드",   23000 },
            { "정기_전기",             23000 },
            { "정기_수소",             23000 },
            { "정기_CNG",              23000 },
            { "종합_가솔린",           48000 },
            { "종합_디젤",             60000 },
            { "종합_LPG",              48000 },
            { "종합_가솔린 하이브리드", 48000 },
            { "종합_LPG 하이브리드",   48000 },
            { "종합_전기",             48000 },
            { "종합_수소",             48000 },
            { "종합_CNG",              48000 },
            { "종합 NOx_가솔린",       48000 },
            { "종합 NOx_디젤",         60000 },
            { "종합 NOx_LPG",          48000 },
            { "배출면제_가솔린",        0 },
            { "배출면제_전기",          0 },
            { "이륜차검사_가솔린",     16000 },
            { "이륜차검사_전기",       16000 },
        };

        public static int GetFee(string 검사종류, string 유종)
        {
            string key = 검사종류 + "_" + 유종;
            int fee = 0;
            if (수수료표.ContainsKey(key))
                fee = 수수료표[key];
            return fee;
        }

    }
}
