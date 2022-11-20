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

                    if (SharedValues.IntegerSearchPattern != null)
                    {
                        initialResult = Regex.Match(SharedValues.TxtLines[line], SharedValues.IntegerSearchPattern);
                    }
                    else
                    {
                        Console.WriteLine("Invalid pattern: '{0}'", SharedValues.IntegerSearchPattern);
                        Program.AskRestart();
                        break;
                    }

                    if (initialResult.Success && SharedValues.secondaryStringWithinEachPrimaryPatternResult != null)
                    {
                        finalResult = Regex.Match(initialResult.Value, SharedValues.secondaryStringWithinEachPrimaryPatternResult);
                    }
                    else
                    {
                        Console.WriteLine("Invalid pattern: '{0}'", SharedValues.secondaryStringWithinEachPrimaryPatternResult);
                        Program.AskRestart();
                        break;
                    }

                    //Proceed

                    bool success = int.TryParse(finalResult.Value, out int convertedNumber); // this value it the one we need to check for incrementing
                    if (success)
                    {
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
                    else
                    {
                        Console.WriteLine("Invalid value: '{0}'", finalResult.Value);
                        Program.AskRestart();
                        break;
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
