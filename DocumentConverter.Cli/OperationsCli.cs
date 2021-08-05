﻿using DocumentConverter.BusinessLogic.FactoryPattern;
using DocumentConverter.Contracts.Interfaces;
using DocumentConverter.Contracts.Interfaces.Documents;
using DocumentConverter.Contracts.Interfaces.Organizations;
using DocumentConverter.Models.Models;
using System;
using System.IO;

namespace DocumentConverter.Cli
{
    public class OperationsCli : IOperationsCli
    {
        private readonly IOrganizationService _organizationService;
        private readonly IExportFactory _exportFactory;
        private readonly IConvertFactory _convertFactory;
        private readonly IStreamService _streamService;
        private readonly IDocumentService _documentService;

        public OperationsCli(IOrganizationService organizationService, IStreamService streamService, IDocumentService documentService, IExportFactory exportFactory, IConvertFactory convertFactory)
        {
            _organizationService = organizationService;
            _convertFactory = convertFactory;
            _exportFactory = exportFactory;
            _streamService = streamService;
            _documentService = documentService;
        }
        public void ExecuteProgram(int input)
        {
            switch (input)
            {
                case 1:
                    Console.WriteLine(ExportFile());
                    break;
                case 2:
                    Console.WriteLine(CheckFiles());
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
        public string ExportFile()
        {
            Console.WriteLine("Please type in document path:");
            var documentPath = Console.ReadLine();
            var stream = _streamService.Read(documentPath);
            Console.WriteLine("Type in format type ");
            var formatType = Console.ReadLine().ToUpper();

            var converter = _convertFactory.GetFileType(formatType);
            var order = converter.Convert(stream);


            if (_organizationService.CheckIfOrganizationsInFilePathExist(order))
            {
                Console.WriteLine($"Receiving organization ID {order.Receiver.ID}");
                var folderPath = _organizationService.GetExportPath(order);
                var receiverFormatType = _organizationService.GetFormatType(order);
                var exporter = _exportFactory.GetFileType(receiverFormatType);
                var fileName = $"_exported_{order.Name}.{receiverFormatType.ToLower()}";
                var filePath = Path.Combine(folderPath, fileName);
                Console.WriteLine($"Exporting to: {filePath}");
                Console.WriteLine($"Exporting using {receiverFormatType} format");
                var formatTypeStream = exporter.Export(order);
                if (_streamService.Write(formatTypeStream, filePath))
                {
                    _documentService.LogExportedDocumentToDatabase(order, fileName);
                    return $"Document was successfully exported! Devilvered to {filePath}";
                }
                else
                {
                    return "unexpected error occured.";
                }
            }
            else
            {
                return "Bad filepath or no organizatios";
            }
        }
        public string CheckFiles()
        {
            Console.WriteLine("Please type in ID of organization you want to see exported files log of:");
            var organizationId = Console.ReadLine();
            return _documentService.GetExportedDocumentsInfo(organizationId);
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
                if (_organizationService.AddOrganization(organizationDto))
                {
                    Console.WriteLine("Organization was added successfuly!");
                }
                else
                {
                    Console.WriteLine("There seems to be a problem, try again.");
                }
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
                if (_organizationService.RemoveOrganization(id, name))
                {
                    Console.WriteLine("Organization has been removed.");
                }
                else
                {
                    Console.WriteLine("Organization could not be removed.");
                }
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
