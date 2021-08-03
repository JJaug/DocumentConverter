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
            services.AddTransient<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IInternalFormatService, InternalFormatService>();
            services.AddScoped<IInternalFormatRepository, InternalFormatRepository>();
            services.AddScoped<IDocumentHandlerService, DocumentHandlerService>();
            services.AddScoped<IDocumentHandlerRepository, DocumentHandlerRepository>();
            services.AddScoped<IOperationsCli, OperationsCli>();
        }
    }
}
