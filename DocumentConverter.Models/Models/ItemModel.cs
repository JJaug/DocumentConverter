using System.Collections.Generic;

namespace DocumentConverter.Models.Models
{
    public class ItemModel
    {
        public string Note { get; set; }
        public string Dimensions { get; set; }
        public decimal Weight { get; set; }
        public List<AdditionalItemPropertyModel> AdditionalItemProperty { get; set; }
    }
}
