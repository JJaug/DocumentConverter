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
                    Console.WriteLine("Wrong input value.");
                    break;
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
            _organizationService.AddOrganization(organizationDto);
        }
        public void RemoveOrganization()
        {
            Console.WriteLine("Organization Id");
            var id = Console.ReadLine();
            Console.WriteLine("Organization Name");
            var name = Console.ReadLine();
            _organizationService.RemoveOrganization(id, name);
        }
        public void ExportFile()
        {
            Console.WriteLine("Please type in document path:");
            var documentPath = Console.ReadLine();
            ExportFactory exportFactory = new ConcreteExportFactory();
            IExporter _exportAsXml = exportFactory.GetFileType(2); 
            ConvertFactory convertFactory = new ConcreteConvertFactory();
            IConverter convertToXml = convertFactory.GetFileType(2);
            var stream = _streamService.Read(documentPath);
            var order = convertToXml.Convert(stream);


            if (_organizationService.CheckIfOrganizationsInFilePathExist(order))
            {
                Console.WriteLine($"Receiving organization ID {order.Receiver.ID}");
                var folderPath = _organizationService.GetExportPath(order);
                var fileName = $"{DateTime.Now}_exported_{order.Name}.xml";
                var filePath = Path.Combine(folderPath, fileName);
                Console.WriteLine($"Exporting to: {filePath}");
                var formatType = _organizationService.GetFormatType(order);
                Console.WriteLine($"Exporting using {formatType} format");
                switch (formatType)
                {
                    case "XML":
                        var xmlStream = _exportAsXml.Export(order);
                        if(_streamService.Write(xmlStream, filePath))
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

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Bad filepath or no organizatios");
            }
        }
    }
}
