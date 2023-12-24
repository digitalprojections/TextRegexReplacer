using System.Text;
using System.Text.RegularExpressions;
using TextRegexReplacer;

namespace TextReplacer
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            GetUserInput();
        }

        #region USER INPUT CHECK
        private static void GetUserInput()
        {
            Console.WriteLine("|##########################################|");
            Console.WriteLine("|         Free Text Replacer(FTR-22)       |");
            Console.WriteLine("|##########################################|");
            Console.WriteLine("|credits                                   |");
            Console.WriteLine("|##########################################|");
            Console.WriteLine("|Author| Ahmadxon (git: digitalprojections)|");
            Console.WriteLine("|Email |                  fuzalov@gmail.com|");
            Console.WriteLine("|Date  |                         2022-11-20|");
            Console.WriteLine("|Place |                        Kobe, Japan|");
            Console.WriteLine("|Ver.  |                              1.0.0|");
            Console.WriteLine("|##########################################|");
            Console.WriteLine("|You can thank me here:     (PayPal) @fuzal|");
            Console.WriteLine("|##########################################|");


            Console.WriteLine("Choose a task:");

            Console.WriteLine("Text Replacer [0]");
            Console.WriteLine("Transliteration [1]");
            //Console.WriteLine("Line Sequence Checker [1]");
            var choice = Console.ReadLine();

            bool success = int.TryParse(choice, out int choicevalue);

            if (success)
            {
                //Ask to enter the path
                Console.WriteLine(SharedValues.filepathinputrequest);
                //Get the path
                SharedValues.filepath = Console.ReadLine() ?? string.Empty;

                switch (choicevalue)
                {
                    case 0:
                        Console.WriteLine(SharedValues.primaryPatternToSearchFor);
                        SharedValues.MainPattern = Console.ReadLine() ?? string.Empty;

                        Console.WriteLine(SharedValues.secondaryStringWithinEachPrimaryPatternResult);
                        SharedValues.StringToBeReplaced = Console.ReadLine() ?? string.Empty;

                        Console.WriteLine(SharedValues.finalStringToReplace);
                        SharedValues.ReplacementString = Console.ReadLine() ?? string.Empty;
                        GetUserInputs(TextReplacer.SaveNewConvertedFile);
                        break;
                    case 1:

                        //Console.WriteLine(SharedValues.integerSearchMessage);
                        //SharedValues.IntegerSearchPattern = Console.ReadLine() ?? string.Empty;
                        //Console.WriteLine(SharedValues.secondaryStringWithinEachPrimaryPatternResult);
                        //SharedValues.StringToBeReplaced = Console.ReadLine() ?? string.Empty;

                        GetUserInputs(new CyrillicToRoman().ConvertText);
                        break;
                }
            }

        }
        /// <summary>
        /// Make sure all good before go on
        /// </summary>
        /// <param name="nextAction"></param>
        static void GetUserInputs(Action nextAction)
        {


            if (SharedValues.filepath != null)
            {
                try
                {
                    SharedValues.AllTextLines = File.ReadAllLines(SharedValues.filepath);//@"C:\Users\denta\Downloads\Telegram Desktop\quran-uz-k_yoldash-converted.txt"
                }
                catch (Exception fnfx)
                {
                    Console.WriteLine(fnfx.Message);
                    AskRestart();
                    return;
                }
            }
            else
            {
                Console.WriteLine(SharedValues.filePathCantBeNull);
                AskRestart();
                return;
            }

            //All seems OK. Go on!
            nextAction();
        }

        #endregion

        #region ASK RESTART
        public static void AskRestart()
        {
            Console.WriteLine("Do you want to try again? Y=yes, Enter=Quit");
            SharedValues.yesno = Console.ReadLine();
            if (SharedValues.yesno != null && SharedValues.yesno.ToLower().Equals("y"))
            {
                GetUserInput();
            }
            else
            {
                //Do nothing
            }
        }
        #endregion

    }
}