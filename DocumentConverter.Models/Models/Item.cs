using System.Collections.Generic;

namespace DocumentConverter.Models.Models
{
    public class Item
    {
        public string Note { get; set; }
        public string Dimensions { get; set; }
        public decimal? Weight { get; set; }
        public List<AdditionalItemProperty> AdditionalItemProperty { get; set; }
    }
}
