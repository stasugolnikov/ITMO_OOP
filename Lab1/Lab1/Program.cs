using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            IniParser p = new IniParser();
            p.ParseIniFile("file.ini");
            int x = p.Get<int>("sdag", "sageg");
            Console.WriteLine(x);
            int y = p.Get<int>("COMMON", "DiskCachePath");
            Console.WriteLine(y);
            double z = p.Get<double>("ADC_DEV", "BufferLenSecons");
            Console.WriteLine(z);
        }
    }
}