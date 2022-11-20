using System.Text;
using System.Text.RegularExpressions;
using TextRegexReplacer;

namespace TextReplacer
{
    /// <summary>
    /// Will replace text in a txt file according to a pattern within pattern
    /// </summary>
    public static class TextReplacer
    {
        private const string path_suffix = "_converted.txt";
        private const string dot = ".";
        private const string underscore = "_";

        public static void SaveNewConvertedFile()
        {
            string newValue;

            var directory = Path.GetDirectoryName(SharedValues.filepath);
            var filename = Path.GetFileName(SharedValues.filepath);

            if (Directory.Exists(directory))
            {
                StreamWriter sw = new StreamWriter(
                    Path.Combine(directory, filename.Substring(0, filename.IndexOf(dot))) +
                    underscore + 
                    DateTime.Now.Ticks.ToString() +
                    path_suffix, 
                    true, 
                    Encoding.UTF8);

                if (SharedValues.TxtLines != null && SharedValues.TxtLines.Length > 0)
                {
                    for (int line = 0; line < SharedValues.TxtLines.Count(); line++)
                    {
                        foreach (Match searchResult in Regex.Matches(SharedValues.TxtLines[line], SharedValues.MainPattern))
                        {
                            // Console.WriteLine("\n");

                            // Console.WriteLine("'{0}' found at index {1}", m.Value, m.Index);

                            newValue = SharedValues.TxtLines[line].Replace(searchResult.Value, searchResult.Value.Replace(SharedValues.StringToBeReplaced, SharedValues.ReplacementString));

                            // Console.WriteLine("'{0}' is the new value to be inserted", newValue);

                            sw.WriteLine(newValue);
                        }
                    }
                }
                sw.Close();
            }            
        }
    }
}