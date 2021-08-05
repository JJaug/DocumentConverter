namespace DocumentConverter.Models.Models
{
    public class OrganizationDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FormatName { get; set; }
        public int FormatId { get; set; }
        public string ExportPath { get; set; }
    }
}
