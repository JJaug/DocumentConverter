using DocumentConverter.BusinessLogic.Classes.Converter;
using DocumentConverter.Contracts.Interfaces.Converter;
using System;

namespace DocumentConverter.BusinessLogic.FactoryPattern
{
    public interface IConvertFactory
    {
        public IConverter GetFileType(string fileType);
    }
    public class ConvertFactory : IConvertFactory
    {
        public IConverter GetFileType(string fileType)
        {
            switch (fileType)
            {
                case "JSON":
                    return new ConvertToJson();
                case "XML":
                    return new ConvertToXml();
                default:
                    throw new ApplicationException(string.Format("Error"));
            }
        }
    }
}
