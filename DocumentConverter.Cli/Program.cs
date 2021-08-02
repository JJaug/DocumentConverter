using System;

namespace DocumentConverter.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to DocumentExporter!");
                var command = CliInformation();
                var input = int.Parse(command);
                ExecuteProgram(input);
                if (input == 5)
                {
                    Console.WriteLine("Bye bye!");
                    break;
                }
            }

        }
        static void ExecuteProgram(int input)
        {
            switch (input)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Wrong input value.");
                    break;
            }
        }
        static string CliInformation()
        {
            Console.WriteLine("Type in the number");
            Console.WriteLine("1. Export file");
            Console.WriteLine("2. Check files");
            Console.WriteLine("3. Add organization");
            Console.WriteLine("4. Remove organization");
            Console.WriteLine("5. Exit");
            return Console.ReadLine();
        }
    }
}
