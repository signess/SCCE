using System;

namespace SCCE.Extensions
{
    public static class Extensions
    {
        public static string RemoveWhitespace(this string str)
        {
            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }

        public static string RemoveStart(this string s, string text)
        {
            return s.Substring(s.IndexOf(s) + text.Length, s.Length - text.Length);
        }
    }
}
