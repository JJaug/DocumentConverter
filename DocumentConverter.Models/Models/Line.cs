using System.Xml.Serialization;

namespace DocumentConverter.Models.Models
{
    [XmlRoot]
    public class Line
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Quantity Quantity { get; set; }
        public Item Item { get; set; }

    }
}
