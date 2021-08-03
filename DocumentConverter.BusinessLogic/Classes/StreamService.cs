using DocumentConverter.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentConverter.BusinessLogic.Classes
{
    public class StreamService : IStreamService
    {
        public Stream Read(string documentPath)
        {
            string xmlString = File.ReadAllText(documentPath);
            byte[] byteArray = Encoding.ASCII.GetBytes(xmlString);
            Stream stream = new MemoryStream(byteArray);
            return stream;
        }
        public bool Write(Stream stream, string filePath)
        {
            using FileStream outputFileStream = new FileStream(filePath, FileMode.Create);
            stream.CopyTo(outputFileStream);
            return outputFileStream != null;
        }
    }
}
