using System.Xml.Serialization;

namespace DocumentConverter.Models.Models
{
    [XmlRoot]
    public class AdditionalItemProperty
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
