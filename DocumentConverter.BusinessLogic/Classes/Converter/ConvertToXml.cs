using DocumentConverter.Contracts.Interfaces.Converter;
using DocumentConverter.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DocumentConverter.BusinessLogic.Classes.Converter
{
    public class ConvertToXml : IConverter
    {
        public Order Convert(Stream stream)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Order));
            var order = (Order)xs.Deserialize(stream);
            // position?
            order.Line = BuildLines(xs);
            return order;
        }

        private List<Line> BuildLines(XmlSerializer xs)
        {
            throw new NotImplementedException();
        }
    }
}
