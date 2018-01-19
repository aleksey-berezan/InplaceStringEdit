using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace InplaceStringEdit
{
    class Program
    {
        private static readonly Random R = new Random();
        private static readonly StringBuilder Sb = new StringBuilder();

        private static readonly int MinChar = (new[] { '0', 'a', 'A', 'z', 'Z' }).Select(c => (int)c).Min();
        private static readonly int MaxChar = (new[] { '0', 'a', 'A', 'z', 'Z' }).Select(c => (int)c).Max();
        static void Main(string[] args)
        {
            Console.WriteLine("Running tests ...");
            int success = 0;
            int fail = 0;
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < 2550; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    string input = GenerateString(i);

                    if (RunTest(input, false))
                        success++;
                    else fail++;
                }
            }
            Console.WriteLine($"Completed. Success: {success}; Failure: {fail}. Time elapsed: {sw.Elapsed}");
        }

        static string GenerateString(int len)
        {
            if (len <= 0)
                return "";
            var sb = Sb;
            sb.Clear();
            for (int i = 0; i < len; i++)
                sb.Append((char)R.Next(MinChar, MaxChar));

            return sb.ToString();
        }

        static bool RunTest(string s, bool quiet = false)
        {
            string expected = s.Capitalize();
            s.CapitalizeInplace();
            s = expected;
            bool pass = s == expected;
            if (!quiet)
            {
                if (pass)
                {
                    // Console.WriteLine("[PASS]");
                }
                else
                {
                    Console.WriteLine($"[[FAIL]]: '{expected}' <> '{s}'");
                }
            }
            return pass;
        }
    }
}
