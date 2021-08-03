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
        public abstract IConverter GetFileType(int fileType);
    }

    public class ConcreteConvertFactory : ConvertFactory
    {
        public override IConverter GetFileType(int fileType)
        {
            switch (fileType)
            {
                case 1:
                    return new ConvertToJson();
                case 2:
                    return new ConvertToXml();
                default:
                    throw new ApplicationException(string.Format("Error"));
            }
        }

    }
}
