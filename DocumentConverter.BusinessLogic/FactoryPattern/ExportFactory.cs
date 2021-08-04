using DocumentConverter.BusinessLogic.Classes.Exporter;
using DocumentConverter.Contracts.Interfaces;
using System;

namespace DocumentConverter.BusinessLogic.FactoryPattern
{

    public abstract class ExportFactory
    {
        public abstract IExporter GetFileType(string fileType);
    }

    public class ConcreteExportFactory : ExportFactory
    {
        public override IExporter GetFileType(string fileType)
        {
            switch (fileType)
            {
                case "JSON":
                    return new ExportAsJson();
                case "XML":
                    return new ExportAsXml();
                default:
                    throw new ApplicationException(string.Format("Error"));
            }
        }

    }

}

