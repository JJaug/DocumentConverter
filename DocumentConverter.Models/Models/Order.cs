using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DocumentConverter.Models.Models
{
    [JsonObject]
    [XmlRoot]
    public class Order
    {
        [JsonProperty]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Note { get; set; }
        public Sender Sender { get; set; }
        public Receiver Receiver { get; set; }
        [JsonExtensionData]
        [XmlElement]
        public List<Line> Line { get; set; }
    }
}
