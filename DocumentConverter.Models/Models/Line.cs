namespace DocumentConverter.Models.Models
{
    public class Line
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Quantity Quantity { get; set; }
        public Item Item { get; set; }

    }
}
