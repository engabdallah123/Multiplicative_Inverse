namespace Multiplicative_Inverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (choice)
                {
                    // ── 1. Just find the inverse ─────────────────────────────
                    case "1":
                        {
                            int a = ReadInt("  Enter a : ");
                            int m = ReadInt("  Enter m : ");
                            try
                            {
                                int inv = CipherHelper.ModularInverse(a, m);
                                Console.WriteLine($"\n  ✔ Inverse of {a} mod {m} = {inv}");
                                Console.WriteLine($"  Check : {a} × {inv} mod {m} = {(a * inv) % m}  (should be 1)");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"\n  ✘ {ex.Message}");
                            }
                            break;
                        }

                    // ── 2. Encrypt only ──────────────────────────────────────
                    case "2":
                        {
                            int m = ReadInt("  Modulus m (26 for English alphabet) : ");
                            int a = ReadInt("  Key a : ");
                            int b = ReadInt("  Key b : ");

                            if (CipherHelper.GCD(a, m) != 1)
                            {
                                Console.WriteLine($"\n  ✘ gcd({a},{m}) ≠ 1 — key 'a' invalid, no inverse exists.");
                                break;
                            }

                            string plain = ReadText("  Plain text  : ");
                            string enc = CipherHelper.Encrypt(plain, a, b, m);
                            Console.WriteLine($"\n  Formula    : E(x) = ({a}·x + {b}) mod {m}");
                            Console.WriteLine($"  Encrypted  : {enc}");
                            break;
                        }

                    // ── 3. Decrypt only ──────────────────────────────────────
                    case "3":
                        {
                            int m = ReadInt("  Modulus m (26 for English alphabet) : ");
                            int a = ReadInt("  Key a : ");
                            int b = ReadInt("  Key b : ");

                            if (CipherHelper.GCD(a, m) != 1)
                            {
                                Console.WriteLine($"\n  ✘ gcd({a},{m}) ≠ 1 — key 'a' invalid.");
                                break;
                            }

                            int inv = CipherHelper.ModularInverse(a, m);
                            string cipher = ReadText("  Cipher text : ");
                            string dec = CipherHelper.Decrypt(cipher, a, b, m);
                            Console.WriteLine($"\n  a⁻¹ mod {m}  : {inv}");
                            Console.WriteLine($"  Formula     : D(y) = {inv}·(y − {b}) mod {m}");
                            Console.WriteLine($"  Decrypted   : {dec}");
                            break;
                        }

                    // ── 4. Full round-trip ───────────────────────────────────
                    case "4":
                        {
                            int m = ReadInt("  Modulus m (26 for English alphabet) : ");
                            int a = ReadInt("  Key a : ");
                            int b = ReadInt("  Key b : ");

                            if (CipherHelper.GCD(a, m) != 1)
                            {
                                Console.WriteLine($"\n  ✘ gcd({a},{m}) ≠ 1 — key 'a' invalid.");
                                break;
                            }

                            int inv = CipherHelper.ModularInverse(a, m);
                            string plain = ReadText("  Plain text  : ");
                            string enc = CipherHelper.Encrypt(plain, a, b, m);
                            string dec = CipherHelper.Decrypt(enc, a, b, m);

                            Console.WriteLine($"\n  ── Keys ──────────────────────────────");
                            Console.WriteLine($"  a = {a},  b = {b},  m = {m}");
                            Console.WriteLine($"  a⁻¹ mod {m} = {inv}  (check: {a}×{inv} mod {m} = {(a * inv) % m})");
                            Console.WriteLine($"\n  ── Result ────────────────────────────");
                            Console.WriteLine($"  Original  : {plain.ToUpper()}");
                            Console.WriteLine($"  Encrypted : {enc}");
                            Console.WriteLine($"  Decrypted : {dec}");
                            Console.WriteLine($"  Match     : {(dec == plain.ToUpper() ? "✔ YES" : "✘ NO")}");
                            break;
                        }

                    // ── 5. Check existence ───────────────────────────────────
                    case "5":
                        {
                            int a = ReadInt("  Enter a : ");
                            int m = ReadInt("  Enter m : ");
                            int g = CipherHelper.GCD(((a % m) + m) % m, m);

                            if (g == 1)
                                Console.WriteLine($"\n  ✔ Inverse EXISTS — gcd({a},{m}) = 1");
                            else
                                Console.WriteLine($"\n  ✘ No inverse — gcd({a},{m}) = {g} ≠ 1");
                            break;
                        }

                    case "0":
                        Console.WriteLine("  Bye!");
                        return;

                    default:
                        Console.WriteLine("  [!] Invalid choice.");
                        break;
                }

                Console.WriteLine("\n  Press Enter to continue...");
                Console.ReadLine();
            }

            static int ReadInt(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    if (int.TryParse(Console.ReadLine(), out int val)) return val;
                    Console.WriteLine("  [!] Invalid input. Enter a whole number.");
                }
            }

            // ===== Read non-empty string =====
            static string ReadText(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    string val = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(val)) return val;
                    Console.WriteLine("  [!] Text cannot be empty.");
                }
            }

            // ===== Menu =====
            static void ShowMenu()
            {
                Console.WriteLine();
                Console.WriteLine("╔══════════════════════════════════════╗");
                Console.WriteLine("║     Multiplicative Inverse Toolkit   ║");
                Console.WriteLine("╠══════════════════════════════════════╣");
                Console.WriteLine("║  1. Find Modular Inverse (a⁻¹ mod m) ║");
                Console.WriteLine("║  2. Encrypt text (Affine Cipher)     ║");
                Console.WriteLine("║  3. Decrypt text (Affine Cipher)     ║");
                Console.WriteLine("║  4. Encrypt + Decrypt (full round)   ║");
                Console.WriteLine("║  5. Check if inverse exists          ║");
                Console.WriteLine("║  0. Exit                             ║");
                Console.WriteLine("╚══════════════════════════════════════╝");
                Console.Write("  Choose: ");
            }
        }
    }
}
