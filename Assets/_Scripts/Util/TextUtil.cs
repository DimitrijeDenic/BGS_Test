using System;

namespace BGS.Util
{
    public static class TextUtil
    {
        public static string WithSuffix(this float val, string format, int decimals = 2)
        {
            var suffixes = new[] { "", "K", "M", "B", "T" };
            var suffixIndex = 0;

            while (val >= 1000 && suffixIndex < suffixes.Length - 1)
            {
                val /= 1000;
                suffixIndex++;
            }

            return $"{Math.Round(val, decimals)}{suffixes[suffixIndex]}";
        }
    }
}