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
                var isCommandNumber = Int32.TryParse(command, out input);
                if (isCommandNumber)
                {
                    cli.ExecuteProgram(input);
                }
                else
                {
                    Console.WriteLine("Dont type in letters or decimals!");
                }
                if (input == 5)
                {
                    Console.WriteLine("Bye bye!");
                    break;
                }
            }
        }
    }
}
