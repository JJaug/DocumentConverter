using System.Collections.Generic;
using System.Xml.Serialization;

namespace DocumentConverter.Models.Models
{
    [XmlRoot]
    public class Order
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Note { get; set; }
        public Sender Sender { get; set; }
        public Receiver Receiver { get; set; }
        [XmlElement]
        public List<Line> Line { get; set; }
    }
}
