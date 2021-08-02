using System;
using System.Collections.Generic;

namespace DocumentConverter.Models.Models
{
    public class DataModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public SenderModel Sender { get; set; }
        public ReceiverModel Receiver { get; set; }
        public List<LineModel> Line { get; set; }
    }
}
