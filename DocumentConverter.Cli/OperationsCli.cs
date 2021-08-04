using DocumentConverter.BusinessLogic.FactoryPattern;
using DocumentConverter.Contracts.Interfaces;
using DocumentConverter.Contracts.Interfaces.Converter;
using DocumentConverter.Contracts.Interfaces.DocumentHandler;
using DocumentConverter.Contracts.Interfaces.InternalFormat;
using DocumentConverter.Contracts.Interfaces.OrganizationHandler;
using DocumentConverter.Models.Models;
using System;
using System.IO;

namespace DocumentConverter.Cli
{
    public class OperationsCli : IOperationsCli
    {
        private readonly IOrganizationService _organizationService;
        private readonly IInternalFormatService _internalFormatService;
        private readonly IStreamService _streamService;
        private readonly IDocumentService _documentService;

        public OperationsCli(IOrganizationService organizationService, IInternalFormatService internalFormat, IStreamService streamService, IDocumentService documentService)
        {
            _organizationService = organizationService;
            _internalFormatService = internalFormat;
            _streamService = streamService;
            _documentService = documentService;
        }
        public void ExecuteProgram(int input)
        {
            switch (input)
            {
                case 1:
                    ExportFile();
                    break;
                case 2:
                    CheckFiles();
                    break;
                case 3:
                    AddOrganization();
                    break;
                case 4:
                    RemoveOrganization();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Type in number from 1 to 5.");
                    break;
            }
        }
        public void ExportFile()
        {
            Console.WriteLine("Please type in document path:");
            var documentPath = Console.ReadLine();
            var stream = _streamService.Read(documentPath);
            var orderToGetFormatType = _streamService.GetInstanceOfOrderFromStream(stream);
            var formatType = _organizationService.GetFormatType(orderToGetFormatType);
            ExportFactory exportFactory = new ConcreteExportFactory();
            ConvertFactory convertFactory = new ConcreteConvertFactory();
            IExporter _exporter = exportFactory.GetFileType(formatType);
            IConverter converter = convertFactory.GetFileType(formatType);
            var order = converter.Convert(stream);


            if (_organizationService.CheckIfOrganizationsInFilePathExist(order))
            {
                Console.WriteLine($"Receiving organization ID {order.Receiver.ID}");
                var folderPath = _organizationService.GetExportPath(order);
                var fileName = $"{DateTime.Now}_exported_{order.Name}.{formatType.ToLower()}";
                var filePath = Path.Combine(folderPath, fileName);
                Console.WriteLine($"Exporting to: {filePath}");

                Console.WriteLine($"Exporting using {formatType} format");
                switch (formatType)
                {
                    case "XML":
                        var xmlStream = _exporter.Export(order);
                        if (_streamService.Write(xmlStream, filePath))
                        {
                            _documentService.LogExportedDocumentToDatabase(order, fileName);
                            Console.WriteLine($"Document was successfully exported! Devilvered to {filePath}");
                        }
                        else
                        {
                            Console.WriteLine("unexpected error occured.");
                        }
                        break;
                    case "JSON":
                        var jsonStream = _exporter.Export(order);
                        if (_streamService.Write(jsonStream, filePath))
                        {
                            _documentService.LogExportedDocumentToDatabase(order, fileName);
                            Console.WriteLine($"Document was successfully exported! Devilvered to {filePath}");
                        }
                        else
                        {
                            Console.WriteLine("unexpected error occured.");
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Bad filepath or no organizatios");
            }
        }
        public void CheckFiles()
        {
            Console.WriteLine("Please type in ID of organization you want to see exported files log of:");
            var organizationId = Console.ReadLine();
            _documentService.GetExportedDocumentsInfo(organizationId);
        }
        public void AddOrganization()
        {
            Console.WriteLine("Organization ID");
            var id = Console.ReadLine();
            Console.WriteLine("Organization Name");
            var name = Console.ReadLine();
            Console.WriteLine("Organization Format Name");
            var format = Console.ReadLine();
            Console.WriteLine("Organization Export Path");
            var path = Console.ReadLine();
            var organizationDto = new OrganizationDto { Id = id, Name = name, FormatName = format, ExportPath = path };
            try
            {
                _organizationService.AddOrganization(organizationDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void RemoveOrganization()
        {
            Console.WriteLine("Organization Id");
            var id = Console.ReadLine();
            Console.WriteLine("Organization Name");
            var name = Console.ReadLine();
            try
            {
                _organizationService.RemoveOrganization(id, name);
            }
            catch
            {
                Console.WriteLine("Wrong organization ID or Name");
            }
        }
        public void CliInformation()
        {
            Console.WriteLine("Type in the number");
            Console.WriteLine("1. Export file");
            Console.WriteLine("2. Check files");
            Console.WriteLine("3. Add organization");
            Console.WriteLine("4. Remove organization");
            Console.WriteLine("5. Exit");
        }
    }
}
