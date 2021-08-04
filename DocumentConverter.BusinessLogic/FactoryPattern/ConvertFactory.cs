using DocumentConverter.BusinessLogic.Classes.Converter;
using DocumentConverter.Contracts.Interfaces.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentConverter.BusinessLogic.FactoryPattern
{
    public abstract class ConvertFactory
    {
        public abstract IConverter GetFileType(string fileType);
    }

    public class ConcreteConvertFactory : ConvertFactory
    {
        public override IConverter GetFileType(string fileType)
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
