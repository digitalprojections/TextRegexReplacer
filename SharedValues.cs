using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRegexReplacer
{
    public static class SharedValues
    {
        public static string? yesno;

        public static string MainPattern { get; set; } = String.Empty;
        public static string StringToBeReplaced { get; set; } = String.Empty;
        public static string[]? AllTextLines { get; set; }
        public static string ReplacementString { get; set; } = String.Empty;
        public static string IntegerSearchPattern { get; set; } = String.Empty;
        public static string filepath { get; set; } = String.Empty;

        public const string integerSearchMessage = "Input regex pattern to identify line numbers for each row";
        public const string filepathinputrequest = "Input source text file path";
        public const string primaryPatternToSearchFor = "Input the main (regex) pattern to search for:";        
        public const string secondaryStringWithinEachPrimaryPatternResult = "input string you wish to replace within search results:";
        public const string finalStringToReplace = "finally, input the replacement string";        
        public const string filePathCantBeNull = "File path can`t be null";
        public const string textFileEmpty = "Selected text file is empty";
    }
}
