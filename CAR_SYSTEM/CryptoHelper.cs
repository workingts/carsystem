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
using System.Security.Cryptography;
using System.Text;

namespace CAR_SYSTEM
{
    public static class CryptoHelper
    {
        private static byte[] _key = Encoding.UTF8.GetBytes("Xk9mP2qL7nR4vB8wY1hT6cA3jF5eD0sZ");
        private static byte[] _iv  = Encoding.UTF8.GetBytes("Wz3nK8pQ2mX5rL7t");

        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return plainText;
            using (Aes aes = Aes.Create())
            {
                aes.Mode    = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key     = _key;
                aes.IV      = _iv;
                ICryptoTransform enc = aes.CreateEncryptor();
                byte[] input  = Encoding.UTF8.GetBytes(plainText);
                byte[] result = enc.TransformFinalBlock(input, 0, input.Length);
                return Convert.ToBase64String(result);
            }
        }

        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText)) return cipherText;
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Mode    = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Key     = _key;
                    aes.IV      = _iv;
                    ICryptoTransform dec = aes.CreateDecryptor();
                    byte[] input  = Convert.FromBase64String(cipherText);
                    byte[] result = dec.TransformFinalBlock(input, 0, input.Length);
                    return Encoding.UTF8.GetString(result);
                }
            }
            catch { return cipherText; }
        }

        public static string MaskCarNo(string plain)
        {
            if (plain.Length < 4) return plain;
            return new string('*', plain.Length - 4) + plain.Substring(plain.Length - 4);
        }

        public static string MaskPhone(string plain)
        {
            if (plain.Length < 4) return plain;
            return new string('*', plain.Length - 4) + plain.Substring(plain.Length - 4);
        }

        public static string MaskName(string plain)
        {
            if (plain.Length < 2) return plain;
            return plain.Substring(0, 1) + new string('*', plain.Length - 1);
        }
    }
}
