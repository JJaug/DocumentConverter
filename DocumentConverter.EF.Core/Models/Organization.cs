using System;

#nullable disable

namespace DocumentConverter.EF.Core.Models
{
    public partial class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExportPath { get; set; }
        public DateTime CreatedDate { get; set; }
        public int FormatId { get; set; }

        public virtual Format Format { get; set; }
    }
}
