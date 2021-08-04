using System.Collections.Generic;

namespace DocumentConverter.Models.Models
{

    public class Order
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Note { get; set; }
        public Sender Sender { get; set; }
        public Receiver Receiver { get; set; }
        public List<Line> Line { get; set; }
    }
}
