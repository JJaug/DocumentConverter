using System.IO;

namespace DocumentConverter.Contracts.Interfaces.InternalFormat
{
    public interface IInternalFormatService
    {
        public Stream ConvertXmlFileToStream(string documentPath);

    }
}
