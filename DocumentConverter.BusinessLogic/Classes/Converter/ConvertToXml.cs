using DocumentConverter.Contracts.Interfaces.Converter;
using DocumentConverter.Models.Models;
using System.IO;
using System.Xml.Serialization;

namespace DocumentConverter.BusinessLogic.Classes.Converter
{
    public class ConvertToXml : IConverter
    {
        public Order Convert(Stream stream)
        {
            var overrides = new XmlAttributeOverrides();
            var attribs = new XmlAttributes();
            overrides.Add(typeof(Order), new XmlAttributes { XmlRoot = new XmlRootAttribute("Order") });
            overrides.Add(typeof(Line), new XmlAttributes { XmlRoot = new XmlRootAttribute("Line") });
            overrides.Add(typeof(AdditionalItemProperty), new XmlAttributes { XmlRoot = new XmlRootAttribute("AdditionalItemProperty") });
            attribs.XmlElements.Add(new XmlElementAttribute("Line"));
            overrides.Add(typeof(Order), "Line", attribs);

            var attribs2 = new XmlAttributes();
            attribs2.XmlElements.Add(new XmlElementAttribute("AdditionalItemProperty"));
            overrides.Add(typeof(Item), "AdditionalItemProperty", attribs2);

            var serializer = new XmlSerializer(typeof(Order), overrides);

            var order = (Order)serializer.Deserialize(stream);
            return order;
        }

    }
}
