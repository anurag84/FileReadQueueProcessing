using System;

namespace GlobalSignConsoleApp.Extensions
{
    public static class StringExtension
    {
        public static string[] StringSplit(this string str)
        {
            return str.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '"', '-', '(', ')', '[', ']', '*','#' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
