using DocumentConverter.BusinessLogic.Classes.Exporter;
using DocumentConverter.Contracts.Interfaces;
using System;

namespace DocumentConverter.BusinessLogic.FactoryPattern
{

    public abstract class ExportFactory
    {
        public abstract IExporter GetFileType(int fileType);
    }

    public class ConcreteExportFactory : ExportFactory
    {
        public override IExporter GetFileType(int fileType)
        {
            switch (fileType)
            {
                case 1:
                    return new ExportAsJson();
                case 2:
                    return new ExportAsXml();
                default:
                    throw new ApplicationException(string.Format("Error"));
            }
        }

    }

}

