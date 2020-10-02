using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab1
{
    public class IniParser
    {
        private string FilePath;
        private Dictionary<string, Dictionary<string, string>> data;

        public IniParser(string path)
        {
            this.FilePath = path;
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
            Regex regex = new Regex(@"^\[\w+\]$");
            return regex.IsMatch(str);
        }

        private bool CheckValidParameter(string str)
        {
            Regex regex = new Regex(@"^[\w]+$");
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

            if (words.Length == 1)
            {
                if (words[0].StartsWith('[') && words[0].EndsWith(']'))
                {
                    if (CheckValidSection(words[0])) strs = words;
                    else
                    {
                        // throw
                    }
                }
            }

            if (words.Length == 2)
            {
                if (CheckValidParameter(words[0]) && CheckValidValue(words[1]))
                {
                    strs = words;
                }
                else
                {
                    // throw
                }
            }
        }

        public void ParseIniFile()
        {
            if (!File.Exists(FilePath))
            {
                //throw ex
            }

            var file = new StreamReader(FilePath);
            string line;
            var ParametersValues = new Dictionary<string, string>();
            string section = "";
            while ((line = file.ReadLine()) != null)
            {
                string[] strs;
                TryParseLine(line, out strs);
                if (strs.Length == 1)
                {
                    data[section] = ParametersValues;
                    ParametersValues = new Dictionary<string, string>();
                    section = strs[0];
                }

                if (strs.Length == 2)
                {
                    if (String.IsNullOrEmpty(section))
                    {
                        // throw
                    }
                    else
                    {
                        ParametersValues[strs[0]] = strs[1];
                    }
                }
            }

            data[section] = ParametersValues;
            file.Close();
        }
    }
}