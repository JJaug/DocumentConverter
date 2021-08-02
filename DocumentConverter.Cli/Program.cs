using DocumentConverter.BusinessLogic.Classes.OrganizationHandler;
using DocumentConverter.Contracts.Interfaces;
using DocumentConverter.Contracts.Interfaces.OrganizationHandler;
using DocumentConverter.EF.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace DocumentConverter.Cli
{
    class Program
    {
        static Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            var service = host.Services;
            var cli = service.GetService<IOperationsCli>();
            Console.WriteLine("Welcome to DocumentExporter!");

            while (true)
            {
                cli.CliInformation();
                var command = Console.ReadLine();
                var input = int.Parse(command);
                cli.ExecuteProgram(input);
                if (input == 5)
                {
                    Console.WriteLine("Bye bye!");
                    break;
                }
            }
            return host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                            services.AddDbContext<OrganizationsAndDocumentsContext>(options =>
                            options.UseSqlServer("Data Source=LT-LIT-SC-0597\\MSSQLSERVER01;Initial Catalog=OrganizationsAndDocuments;Integrated Security=True"))
                            .AddSingleton<IOrganizationHandlerRepository, OrganizationHandlerRepository>()
                            .AddSingleton<IOrganizationHandlerService, OrganizationHandlerService>()
                            .AddSingleton<IOperationsCli, OperationsCli>());

    }
}
