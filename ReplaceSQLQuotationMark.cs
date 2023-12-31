using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRegexReplacer
{
    internal class ReplaceSQLQuotationMark
    {
        private const string path_suffix = "_converted.txt";
        private const string dot = ".";
        private const string underscore = "_";
        public ReplaceSQLQuotationMark(string startIndex)
        {
            StartIndex = startIndex;
        }

        public string StartIndex { get; }

        public void FixQuotationMarks()
        {
            if(StartIndex != null)
            {
                //C:\Users\denta\OneDrive\Documents\quronuzlatinSQLstatements
                string newValue;

                var directory = Path.GetDirectoryName(SharedValues.filepath);
                var filename = Path.GetFileName(SharedValues.filepath);
                if (Directory.Exists(directory))
                {
                    StreamWriter sw = new StreamWriter(
                        Path.Combine(directory, filename.Substring(0, filename.IndexOf(dot))) +
                        underscore +
                        DateTime.Now.TimeOfDay.ToString().Replace(":", "") +
                        path_suffix,
                        true,
                        Encoding.UTF8);

                    if (SharedValues.AllTextLines != null && SharedValues.AllTextLines.Length > 0)
                    {
                        for (int line = 0; line < SharedValues.AllTextLines.Count(); line++)
                        {
                            int quote = 0;
                            string transliterationResult = string.Empty;
                            for (int srcLetter = 56; srcLetter < SharedValues.AllTextLines[line].Length; srcLetter++)
                            {
                                if (SharedValues.AllTextLines[line][srcLetter]=='"')
                                {
                                    quote++;
                                    if(quote > 9)
                                    {

                                    }
                                }
                            }

                            sw.WriteLine(transliterationResult);
                        }
                    }
                    sw.Close();
                }
            }
        }
    }
}
