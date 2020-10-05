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

        private void ParseLine(string line, out string[] strs)
        {
            RemoveComments(ref line);
            strs = line.Split(new[] {' ', '='}, StringSplitOptions.RemoveEmptyEntries);
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
                    ParseLine(line, out string[] strs);
                    if (strs.Length == 0) continue;
                    if (CheckValidSection(strs[0]))
                    {
                        section = strs[0].Substring(1, strs[0].Length - 2);
                        data[section] = new Dictionary<string, string>();
                    }
                    else
                    {
                        if (CheckValidParameter(strs[0]) && CheckValidValue(strs[1]) &&
                            !String.IsNullOrEmpty(section))
                        {
                            data[section][strs[0]] = strs[1];
                            continue;
                        }

                        throw new InvalidFormatException("Ini file format error in line " + line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool TryGetValue(string section, string parameter, out string ans)
        {
            if (data.ContainsKey(section) && data[section].ContainsKey(parameter))
            {
                ans = data[section][parameter];
                return true;
            }
            else
            {
                ans = default;
                return false;
            }
        }

        public T Get<T>(string section, string parameter)
        {
            if (TryGetValue(section, parameter, out string val))
            {
                try
                {
                    return (T) Convert.ChangeType(val, typeof(T));
                }
                catch (FormatException)
                {
                    throw new FormatingException("Can not convert " + data[section][parameter] + " to " + typeof(T));
                }
            }
            else
            {
                throw new UnknownPairException("Unknown pair '" + section + "' '" + parameter + "' in data");
            }
           
        }
    }
}