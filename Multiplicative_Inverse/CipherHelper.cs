using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplicative_Inverse
{
    internal class CipherHelper
    {
        // ===== Extended Euclidean Algorithm =====
        // بيرجع الـ gcd وبيحسب x, y بحيث: a*x + m*y = gcd(a, m)
        private static int ExtendedGCD(int a, int m, out int x, out int y)
        {
            if (a == 0)
            {
                x = 0; y = 1;
                return m;
            }

            int gcd = ExtendedGCD(m % a, a, out int x1, out int y1);

            x = y1 - (m / a) * x1;
            y = x1;

            return gcd;
        }

        // ===== Multiplicative Inverse =====
        // بيلاقي العكس الضربي لـ a modulo m
        public static int ModularInverse(int a, int m)
        {
            int gcd = ExtendedGCD(a % m, m, out int x, out _);

            if (gcd != 1)
                throw new InvalidOperationException(
                    $"No multiplicative inverse exists for {a} mod {m} — gcd must be 1, but got {gcd}");

            // بنضمن النتيجة موجبة
            return (x % m + m) % m;
        }

        // ===== Affine Cipher Encryption =====
        // الصيغة: E(x) = (a*x + b) mod 26
        // ===== Affine Encrypt =====
       public static string Encrypt(string text, int a, int b, int m)
        {
            string result = "";
            foreach (char c in text.ToUpper())
            {
                if (char.IsLetter(c))
                {
                    int x = c - 'A';
                    result += (char)(((a * x + b) % m) + 'A');
                }
                else result += c;
            }
            return result;
        }

        // ===== Affine Decrypt =====
      public  static string Decrypt(string text, int a, int b, int m)
        {
            int aInv = ModularInverse(a, m);
            string result = "";
            foreach (char c in text.ToUpper())
            {
                if (char.IsLetter(c))
                {
                    int y = c - 'A';
                    result += (char)((((aInv * (y - b + m)) % m) + m) % m + 'A');
                }
                else result += c;
            }
            return result;
        }
        // ===== Key Validation =====
        private static void ValidateKey(int a, int m)
        {
            int gcd = ExtendedGCD(a % m, m, out _, out _);
            if (gcd != 1)
                throw new ArgumentException(
                    $"Invalid key: 'a' = {a} must be coprime with {m}. gcd({a},{m}) = {gcd}");
        }
        public static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
    }
}
