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

            if (words.Length == 0) return;

            if (words.Length == 1)
            {
                if (CheckValidSection(words[0]))
                {
                    strs = words;
                    return;
                }
                else
                {
                    throw new InvalidSectionException("Invalid section: " + words[0]);
                }
            }

            if (words.Length == 2)
            {
                if (CheckValidParameter(words[0]))
                {
                    if (CheckValidValue(words[1]))
                    {
                        strs = words;
                        return;
                    }
                    else
                    {
                        throw new InvalidValueException("Invalid value: " + words[1]);
                    }
                }
                else
                {
                    throw new InvalidParameterException("Invalid Parameter: " + words[0]);
                }
            }

            throw new InvalidLineException("Invalid line: " + line);
        }

        public void ParseIniFile()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    throw new FileNotFoundException("Unable to find the file: " + FilePath);
                }

                if (Path.GetExtension(FilePath) != ".ini")
                {
                    throw new InvalidFileTypeException("File tyoe must be .ini, not " + Path.GetExtension(FilePath));
                }
                
                var file = new StreamReader(FilePath);
                string line;
                string section = "";
                while ((line = file.ReadLine()) != null)
                {
                    string[] strs;
                    TryParseLine(line, out strs);
                    if (strs.Length == 1)
                    {
                        section = strs[0].Substring(1, strs[0].Length - 2);
                        data[section] = new Dictionary<string, string>();
                    }

                    if (strs.Length == 2)
                    {
                        if (String.IsNullOrEmpty(section))
                        {
                            throw new InvalidSectionException("Section must be non-empty string");
                        }
                        else
                        {
                            data[section][strs[0]] = strs[1];
                        }
                    }
                }

                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}