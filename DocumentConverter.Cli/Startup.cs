using DocumentConverter.BusinessLogic.Classes;
using DocumentConverter.BusinessLogic.Classes.DocumentHandler;
using DocumentConverter.BusinessLogic.Classes.InternalFormat;
using DocumentConverter.BusinessLogic.Classes.Organizations;
using DocumentConverter.BusinessLogic.FactoryPattern;
using DocumentConverter.Contracts.Interfaces;
using DocumentConverter.Contracts.Interfaces.DocumentHandler;
using DocumentConverter.Contracts.Interfaces.InternalFormat;
using DocumentConverter.Contracts.Interfaces.OrganizationHandler;
using DocumentConverter.Contracts.Interfaces.Organizations;
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
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<IInternalFormatService, InternalFormatService>();
            services.AddTransient<IInternalFormatRepository, InternalFormatRepository>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IDocumentRepository, DocumentRepository>();
            services.AddTransient<IDocumentRepository, DocumentRepository>();
            services.AddTransient<IStreamService, StreamService>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IDocumentRepository, DocumentRepository>();
            services.AddTransient<IConvertFactory, ConvertFactory>();
            services.AddTransient<IExportFactory, ExportFactory>();
            services.AddTransient<IOperationsCli, OperationsCli>();
        }
    }
}
