using System;

#nullable disable

namespace DocumentConverter.EF.Core.Models
{
    public partial class ExportedDocument
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string FileName { get; set; }
        public DateTime ExportedDate { get; set; }
        public int FormatId { get; set; }

        public virtual Format Format { get; set; }
    }
}
