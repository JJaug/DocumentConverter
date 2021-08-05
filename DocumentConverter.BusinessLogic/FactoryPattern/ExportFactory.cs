using DocumentConverter.BusinessLogic.Classes.Exporter;
using DocumentConverter.Contracts.Interfaces;
using System;

namespace DocumentConverter.BusinessLogic.FactoryPattern
{

    public interface IExportFactory
    {
        public IExporter GetFileType(string fileType);
    }
    public class ExportFactory : IExportFactory
    {
        public IExporter GetFileType(string fileType)
        {
            switch (fileType)
            {
                case "JSON":
                    return new ExportAsJson();
                case "XML":
                    return new ExportAsXml();
                case "CSV":
                    return new ExportAsCsv();
                default:
                    throw new ApplicationException(string.Format("Error"));
            }
        }
    }

}

