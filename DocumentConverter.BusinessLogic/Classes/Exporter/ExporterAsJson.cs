using DocumentConverter.Contracts.Interfaces.Exporter;
using DocumentConverter.Models.Models;
using System;
using System.IO;

namespace DocumentConverter.BusinessLogic.Classes.Exporter
{
    public class ExporterAsJson : IExporterAsJson
    {
        public Stream Export(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
