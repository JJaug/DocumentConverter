using DocumentConverter.Contracts.Interfaces.Exporter;
using DocumentConverter.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
