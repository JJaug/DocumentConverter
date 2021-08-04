using DocumentConverter.Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DocumentConverter.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var cli = serviceProvider.GetService<IOperationsCli>();
            Console.WriteLine("Welcome to DocumentExporter!");

            while (true)
            {
                cli.CliInformation();
                var command = Console.ReadLine();
                int input;
                try
                {
                    input = int.Parse(command);
                    cli.ExecuteProgram(input);
                    if (input == 5)
                    {
                        Console.WriteLine("Bye bye!");
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Type in a number, no decimals or letters");
                }
            }
        }
    }
}
