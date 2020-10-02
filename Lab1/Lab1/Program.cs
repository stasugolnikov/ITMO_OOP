using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab1
{
    class Program
    {
        private static bool CheckValidParameter(string str)
        {
            Regex regex = new Regex(@"^\w+$");
            return regex.IsMatch(str);
        }

        private static bool CheckValidValue(string str)
        {
            Regex regex = new Regex(@"^\w\.\/+$");
            return regex.IsMatch(str);
        }

        static void Main(string[] args)
        {
            IniParser p = new IniParser("file.ini");
            p.ParseIniFile();
        }
    }
}