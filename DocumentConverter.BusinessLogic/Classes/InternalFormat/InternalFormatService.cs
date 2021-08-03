using DocumentConverter.Contracts.Interfaces.InternalFormat;
using System.IO;
using System.Text;

namespace DocumentConverter.BusinessLogic.Classes.InternalFormat
{
    public class InternalFormatService : IInternalFormatService
    {
        private readonly IInternalFormatRepository _internalFormatRepository;
        public InternalFormatService(IInternalFormatRepository internalFormatRepository)
        {
            _internalFormatRepository = internalFormatRepository;
        }
        public Stream ConvertXmlFileToStream(string documentPath)
        {
            string xmlString = File.ReadAllText(documentPath);
            byte[] byteArray = Encoding.ASCII.GetBytes(xmlString);
            Stream stream = new MemoryStream(byteArray);
            return stream;
        }

    }
}
