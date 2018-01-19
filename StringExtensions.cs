using System;

namespace InplaceStringEdit
{
    public static unsafe class StringExtensions
    {
        public static void ReverseInplace(this string s)
        {
            fixed (char* c = s)
            {
                int n = s.Length;
                for (int i = 0; i < n / 2; i++)
                {
                    int r = n - i - 1;
                    char t = s[i];
                    c[i] = c[r];
                    c[r] = t;
                }
            }
        }

        public static void CapitalizeInplace(this string s)
        {
            if (s.Length == 0)
                return;
            fixed (char* c = s)
            {
                char t = s[0];
                if (char.IsLower(t))
                {
                    c[0] = (char)((int)t + ('A' - 'a'));
                }
            }
        }

        public static string Capitalize(this string s)
        {
            if (s.Length == 0)
                return s;
            char t = s[0];
            if (char.IsLower(t))
            {
                return ((char)((int)t + ('A' - 'a'))).ToString() + s.Substring(1);
            }

            return s;
        }
    }
}