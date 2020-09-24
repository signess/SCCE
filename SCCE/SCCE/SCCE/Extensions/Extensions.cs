using System;

namespace SCCE.Extensions
{
    public static class Extensions
    {
        public static string RemoveWhitespace(this string str)
        {
            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
