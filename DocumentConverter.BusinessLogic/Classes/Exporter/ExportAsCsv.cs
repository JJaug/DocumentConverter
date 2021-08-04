using DocumentConverter.Contracts.Interfaces;
using DocumentConverter.Models.Models;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentConverter.BusinessLogic.Classes.Exporter
{
    public class ExportAsCsv : IExporter
    {
        public Stream Export(Order order)
        {
            string csvString = CsvSerializer.SerializeToString<Order>(order);
            byte[] byteArray = Encoding.ASCII.GetBytes(csvString);
            Stream stream = new MemoryStream(byteArray);
            return stream;
        }
    }
}
