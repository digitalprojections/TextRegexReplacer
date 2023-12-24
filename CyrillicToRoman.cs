using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextRegexReplacer
{
    internal class CyrillicToRoman
    {
        #region FIELDS
        private const string path_suffix = "_converted.txt";
        private const string dot = ".";
        private const string underscore = "_";

        private string[,] cyrillicSet =
            { { "А", "а" }, { "Б", "б" }, { "В", "в" }, { "Г", "г" }, { "Д", "д" },
            { "Е", "е" }, { "Ё", "ё" }, { "Ж", "ж" }, { "З", "з" }, { "И", "и" },
            { "Й", "й" }, { "К", "к" }, { "Л", "л" }, { "М", "м" }, { "Н", "н" },
            { "О", "о" }, { "П", "п" }, { "Р", "р" }, { "С", "с" }, { "Т", "т" },
            { "У", "у" }, { "Ф", "ф" }, { "Х", "х" }, { "Ц", "ц" }, { "Ч", "ч" },
            { "Ш", "ш" }, { "Э", "э" }, { "Ю", "ю" }, { "Я", "я" }, { "Ъ", "ъ" },
            { "Ь", "ь" }, { "Ў", "ў" }, { "Қ", "қ" }, { "Ғ", "ғ" }, { "Ҳ", "ҳ" },
            { "“", "”" } , { " ", " "}, {",", "." }, {":", ";" }, {"(", ")" },
            {"~", "!" } ,{"?", "#" } ,{"/", "\\" } ,{"+", "-" }, {"0", "1"}, 
            {"2", "3"}, {"4", "5"}, {"6", "7"}, {"8", "9"}};
        private string[,] alphabetSet =
            { { "A", "a" }, { "B", "b" }, { "V", "v" }, { "G", "g" }, { "D", "d" },
            { "Ye", "ye" }, { "Yo", "yo" }, { "J", "j" }, { "Z", "z" }, { "I", "i" },
            { "Y", "y" }, { "K", "k" }, { "L", "l" }, { "M", "m" }, { "N", "n" },
            { "O", "o" }, { "P", "p" }, { "R", "r" }, { "S", "s" }, { "T", "t" },
            { "U", "u" }, { "F", "f" }, { "X", "x" }, { "Ts", "ts" }, { "Ç", "ç" },
            { "Ş", "ş" }, { "E", "e" }, { "Yu", "yu" }, { "Ya", "ya" }, { "`", "`" },
            { "", "" }, { "Õ", "õ" }, { "Q", "q" }, { "Ǵ", "ǵ" }, { "H", "h" },
            { "\"","\"" }, { " ", " " }, {",", "." }, {":", ";" }, {"(", ")" }, 
            {"~", "!" } ,{"?", "#" } ,{"/", "\\" } ,{"+", "-" }, {"0", "1"}, 
            {"2", "3"}, {"4", "5"}, {"6", "7"}, {"8", "9"} };
        #endregion

        public void ConvertText()
        {
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
                        string transliterationResult = string.Empty;
                        for (int srcLetter = 0; srcLetter < SharedValues.AllTextLines[line].Length; srcLetter++)
                        {
                            
                            bool untranslatable = true;
                            for (int dstLetter = 0; dstLetter < cyrillicSet.Length / 2; dstLetter++)
                            {
                                //Capital letter
                                if (SharedValues.AllTextLines[line][srcLetter].ToString().CompareTo(cyrillicSet[dstLetter, 0]) == 0)
                                {
                                    if (dstLetter == 5)
                                    {
                                        //Handle "E"
                                        if (srcLetter == 0 ||
                                            SharedValues.AllTextLines[line][srcLetter - 1].ToString() == "\"" ||
                                            SharedValues.AllTextLines[line][srcLetter - 1].ToString() == ":" ||
                                            SharedValues.AllTextLines[line][srcLetter - 1].ToString() == "-" ||
                                            SharedValues.AllTextLines[line][srcLetter - 1].ToString() == " "
                                            )
                                            transliterationResult += alphabetSet[dstLetter, 0];
                                        else
                                            transliterationResult += alphabetSet[26, 0];
                                    }
                                    else
                                    {
                                        transliterationResult += alphabetSet[dstLetter, 0];
                                    }
                                    untranslatable = false;
                                    break;
                                }
                                //lower case
                                else if (SharedValues.AllTextLines[line][srcLetter].ToString().CompareTo(cyrillicSet[dstLetter, 1]) == 0)
                                {
                                    if (dstLetter == 5)
                                    {
                                        //Handle "e"
                                        if (srcLetter == 0 || 
                                            SharedValues.AllTextLines[line][srcLetter - 1].ToString() == "\"" ||
                                            SharedValues.AllTextLines[line][srcLetter - 1].ToString() == ":" ||
                                            SharedValues.AllTextLines[line][srcLetter - 1].ToString() == "-" ||
                                            SharedValues.AllTextLines[line][srcLetter - 1].ToString() == " "
                                            )
                                            transliterationResult += alphabetSet[dstLetter, 1];
                                        else
                                            transliterationResult += alphabetSet[26, 1];
                                    }
                                    else
                                    {
                                        transliterationResult += alphabetSet[dstLetter, 1];
                                    }
                                    untranslatable = false;
                                    break;
                                }
                                
                            }
                            if (untranslatable)
                            {                                
                                transliterationResult += SharedValues.AllTextLines[line][srcLetter].ToString();
                                untranslatable = false;
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
