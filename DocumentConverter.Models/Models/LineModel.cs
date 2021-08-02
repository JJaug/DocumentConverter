namespace DocumentConverter.Models.Models
{
    public class LineModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public QuantityModel Quantity { get; set; }
        public ItemModel Item { get; set; }

    }
}
