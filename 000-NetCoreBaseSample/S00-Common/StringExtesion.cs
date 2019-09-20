using System;

namespace S00_Common
{
    public static class StringExtesion
    {
        public static void ToWriteLine(this String source)
        {
            Console.WriteLine($"{source}");
        }
    }
}
