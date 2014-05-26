using System;
using System.IO;
using System.Linq;
using Interpreter;

namespace TennisScores
{
    public class Program
    {
        private static byte REQUIRED_ARGS_LENGTH = 2;
        private static byte INPUT_FILE_ARG = 0;
        private static byte OUTPUT_FILE_ARG = 1;

        public static void Main(string[] args)
        {
            if (args.Length == REQUIRED_ARGS_LENGTH)
            {
                // Check the input file exists.   
                if (File.Exists(args[INPUT_FILE_ARG]))
                {
                    string[] inputFile = File.ReadAllLines(args[INPUT_FILE_ARG]);
                    
                    // Test if output directory exists. Create it if not?
                    ScoreInterpreter interpreter = new ScoreInterpreter();
                    interpreter.Interpret(inputFile);
                }
                else
                {
                    Console.WriteLine("Input file could not be found");
                }
            }
            else
            {
                Console.WriteLine("Incorrect arguments entered");
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
