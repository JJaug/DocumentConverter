using DocumentConverter.Contracts.Interfaces;
using DocumentConverter.Contracts.Interfaces.Converter;
using DocumentConverter.Contracts.Interfaces.InternalFormat;
using DocumentConverter.Contracts.Interfaces.OrganizationHandler;
using DocumentConverter.Models.Models;
using System;
using System.IO;
using System.Text;

namespace DocumentConverter.Cli
{
    public class OperationsCli : IOperationsCli
    {
        private readonly IOrganizationService _organizationService;
        private readonly IInternalFormatService _internalFormatService;
        private readonly IConverterToXml _converterToXml;
        public OperationsCli(IOrganizationService organizationService, IInternalFormatService internalFormat, IConverterToXml converterToXml)
        {
            _organizationService = organizationService;
            _internalFormatService = internalFormat;
            _converterToXml = converterToXml;
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
            var stream = _internalFormatService.ConvertXmlFileToStream(documentPath);
            var order = _converterToXml.Convert(stream);
            if (_organizationService.CheckIfOrganizationsInFilePathExist(order))
            {
                var formatType = _organizationService.GetFormatType(order);
                switch (formatType)
                {

                }
            }
            else
            {
                Console.WriteLine("Bad filepath or no organizatios");
            }
        }
    }
}
