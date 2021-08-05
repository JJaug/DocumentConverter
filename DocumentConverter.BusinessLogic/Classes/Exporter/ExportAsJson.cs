using DocumentConverter.Contracts.Interfaces;
using DocumentConverter.Models.Models;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace DocumentConverter.BusinessLogic.Classes.Exporter
{
    public class ExportAsJson : IExporter
    {
        public Stream Export(Order order)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Order));
            Stream streamObject = new MemoryStream();
            js.WriteObject(streamObject, order);
            streamObject.Position = 0;
            StreamReader sr = new StreamReader(streamObject);
            var jsonString = sr.ReadToEnd();
            sr.Close();
            streamObject.Close();
            byte[] byteArray = Encoding.ASCII.GetBytes(jsonString);
            Stream stream = new MemoryStream(byteArray);
            return stream;
        }
    }
}
