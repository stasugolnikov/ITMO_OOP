using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab1
{
    public class IniParser
    {
        private Dictionary<string, Dictionary<string, string>> data;

        public IniParser()
        {
            this.data = new Dictionary<string, Dictionary<string, string>>();
        }

        private void RemoveComments(ref string line)
        {
            int pos = line.IndexOf(';');
            if (pos != -1)
            {
                line = line.Remove(pos, line.Length - pos);
            }
        }

        private bool CheckValidSection(string str)
        {
            Regex regex = new Regex(@"^\[\w+\]+$");
            return regex.IsMatch(str);
        }

        private bool CheckValidParameter(string str)
        {
            Regex regex = new Regex(@"^\w+$");
            return regex.IsMatch(str);
        }

        private bool CheckValidValue(string str)
        {
            Regex regex = new Regex(@"^[\w\.\/]+$");
            return regex.IsMatch(str);
        }

        private void TryParseLine(string line, out string[] strs)
        {
            RemoveComments(ref line);
            string[] words = line.Split(new[] {' ', '='}, StringSplitOptions.RemoveEmptyEntries);
            strs = new string[] { };

            if (words.Length == 0) return;

            if (words.Length == 1 && CheckValidSection(words[0]))
            {
                strs = words;
                return;
            }

            if (words.Length == 2 && CheckValidParameter(words[0]) && CheckValidValue(words[1]))
            {
                strs = words;
                return;
            }

            throw new InvalidFormatException("Ini file format error in line: " + words[0]);
        }

        public void ParseIniFile(string FilePath)
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    throw new FileNotFoundException("Unable to find the file: " + FilePath);
                }

                if (Path.GetExtension(FilePath) != ".ini")
                {
                    throw new InvalidFileTypeException("File type must be .ini, not " + Path.GetExtension(FilePath));
                }

                var file = new StreamReader(FilePath);
                string line;
                string section = "";
                while ((line = file.ReadLine()) != null)
                {
                    TryParseLine(line, out string[] strs);
                    if (strs.Length == 1)
                    {
                        section = strs[0].Substring(1, strs[0].Length - 2);
                        data[section] = new Dictionary<string, string>();
                    }

                    if (strs.Length == 2)
                    {
                        if (String.IsNullOrEmpty(section))
                        {
                            throw new InvalidFormatException("Ini file format error");
                        }
                        else
                        {
                            data[section][strs[0]] = strs[1];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void TryGetValue(string section, string parameter, out string ans)
        {
            try
            {
                ans = data[section][parameter];
            }
            catch (Exception)
            {
                ans = default;
                throw new UnknownPairException("Pair '" + section + "' '" + parameter + "' does not exists");
            }
        }

        public T Get<T>(string section, string parameter)
        {
            try
            {
                TryGetValue(section, parameter, out string val);
                return (T) Convert.ChangeType(val, typeof(T));
            }
            catch (UnknownPairException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Can not convert {0} to {1}", data[section][parameter], typeof(T));
            }

            return default;
        }
    }
}