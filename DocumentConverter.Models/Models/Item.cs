using System.Collections.Generic;
using System.Xml.Serialization;

namespace DocumentConverter.Models.Models
{
    public class Item
    {
        public string Note { get; set; }
        public string Dimensions { get; set; }
        public decimal Weight { get; set; }
        [XmlElement]
        public List<AdditionalItemProperty> AdditionalItemProperty { get; set; }
    }
}
