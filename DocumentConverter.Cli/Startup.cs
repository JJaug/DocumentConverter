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

namespace DocumentConverter.Cli
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json");

            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfigurationRoot>(Configuration);
            var connectionString = Configuration.GetValue<string>("ConnectionString");
            services.AddDbContext<OrganizationsAndDocumentsContext>(options =>
            options.UseSqlServer(connectionString));
            services.AddSingleton<IOrganizationHandlerRepository, OrganizationHandlerRepository>();
            services.AddSingleton<IOrganizationHandlerService, OrganizationHandlerService>();
            services.AddSingleton<IInternalFormatService, InternalFormatService>();
            services.AddSingleton<IInternalFormatRepository, InternalFormatRepository>();
            services.AddSingleton<IDocumentHandlerService, DocumentHandlerService>();
            services.AddSingleton<IDocumentHandlerRepository, DocumentHandlerRepository>();
            services.AddSingleton<IOperationsCli, OperationsCli>();
        }
    }
}
