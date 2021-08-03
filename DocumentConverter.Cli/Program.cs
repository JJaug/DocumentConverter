using DocumentConverter.BusinessLogic.Classes.DocumentHandler;
using DocumentConverter.BusinessLogic.Classes.InternalFormat;
using DocumentConverter.BusinessLogic.Classes.OrganizationHandler;
using DocumentConverter.Contracts.Interfaces;
using DocumentConverter.Contracts.Interfaces.DocumentHandler;
using DocumentConverter.Contracts.Interfaces.InternalFormat;
using DocumentConverter.Contracts.Interfaces.OrganizationHandler;
using DocumentConverter.EF.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appSettings.json", true, true);
            var config = builder.Build();
            var connectionString = config["ConnectionString"];
            using IHost host = CreateHostBuilder(args, connectionString).Build();
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

        static IHostBuilder CreateHostBuilder(string[] args, string connectionString) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                            services.AddDbContext<OrganizationsAndDocumentsContext>(options =>
                            options.UseSqlServer(connectionString))
                            .AddSingleton<IOrganizationHandlerRepository, OrganizationHandlerRepository>()
                            .AddSingleton<IOrganizationHandlerService, OrganizationHandlerService>()
                            .AddSingleton<IInternalFormatService, InternalFormatService>()
                            .AddSingleton<IInternalFormatRepository, InternalFormatRepository>()
                            .AddSingleton<IDocumentHandlerService, DocumentHandlerService>()
                            .AddSingleton<IDocumentHandlerRepository, DocumentHandlerRepository>()
                            .AddSingleton<IOperationsCli, OperationsCli>());

    }
}
