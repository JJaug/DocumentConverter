using System.IO;

namespace DocumentConverter.Contracts.Interfaces
{
    public interface IStreamService
    {
        public Stream Read(string documentPath);
        public bool Write(Stream stream, string filePath);
    }
}
