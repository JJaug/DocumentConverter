using DocumentConverter.Contracts.Interfaces;
using DocumentConverter.Models.Models;
using System.IO;
using System.Text;
using System.Xml.Serialization;

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
        public Order GetInstanceOfOrderFromStream(Stream stream)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Order));
            var order = (Order)xs.Deserialize(stream);
            return order;
        }
    }
}
