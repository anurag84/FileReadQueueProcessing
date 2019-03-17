using System;

namespace GlobalSignConsoleApp.Extensions
{
    public static class StringExtension
    {
        //Lines in the file are splitted using this extension function, for the purpose of test I ahve used standard way of splitting,
        //This can be further optimised to split lines.
        public static string[] StringSplit(this string str)
        {
            return str.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '"', '-', '(', ')', '[', ']', '*','#' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
