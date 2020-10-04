using System;
using System.IO;
using System.Text.RegularExpressions;


namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            IniParser p = new IniParser("file.ini");
            p.ParseIniFile();
        }
    }
}