using DocumentConverter.Contracts.Interfaces;
using DocumentConverter.Models.Models;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DocumentConverter.BusinessLogic.Classes.Exporter

{
    public class ExportAsXml : IExporter
    {
        public Stream Export(Order order)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Order));
            using var stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
                xs.Serialize(writer, order);
            var xmlString = stringWriter.ToString();
            byte[] byteArray = Encoding.ASCII.GetBytes(xmlString);
            Stream stream = new MemoryStream(byteArray);
            return stream;
        }
    }
}
