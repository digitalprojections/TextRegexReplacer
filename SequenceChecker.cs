using System.Text.RegularExpressions;
using TextReplacer;

namespace TextRegexReplacer
{
    public static class SequenceChecker
    {
        private static Match? initialResult;
        private static Match? finalResult;
        public static void StartSequenceChecking()
        {
            //string pattern = @"^[\d]+:[\d]+[\*]*.";

            int chapternumber = 0;
            int increment = 0;


            if (SharedValues.TxtLines != null && SharedValues.TxtLines.Length > 0)
            {
                for (int line = 0; line < SharedValues.TxtLines.Count(); line++)
                {
                    increment++;
                    
                    if (SharedValues.StringToBeReplaced != null)
                    {
                        initialResult = Regex.Match(SharedValues.TxtLines[line], SharedValues.StringToBeReplaced);
                    }
                    else
                    {
                        Console.WriteLine("Invalid pattern: '{0}'", SharedValues.StringToBeReplaced);
                        Program.AskRestart();
                        break;
                    }

                    if (initialResult.Success && SharedValues.ReplacementString != null)
                    {
                        finalResult = Regex.Match(initialResult.Value, SharedValues.ReplacementString);
                    }
                    else
                    {
                        Console.WriteLine("Invalid pattern: '{0}'", SharedValues.ReplacementString);
                        Program.AskRestart();
                        break;
                    }

                    //Proceed

                    int convertedNumber = int.Parse(finalResult.Value); // this value it the one we need to check for incrementing

                    if (convertedNumber == increment)
                    {
                        Console.WriteLine("{0} is the same as {1}", increment, convertedNumber);
                    }
                    else
                    {
                        chapternumber++;
                        increment = 1;//reset the increment
                        if (convertedNumber == increment)
                        {
                            Console.WriteLine("{0} is the same as {1}", increment, convertedNumber);
                        }
                        else
                        {
                            Console.WriteLine("'{0}' NOT SAME AS '{1}' in chapter '{2}'", increment, convertedNumber, chapternumber);
                            break;
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine(SharedValues.textFileEmpty);
                Program.AskRestart();
            }


        }

    }
}
