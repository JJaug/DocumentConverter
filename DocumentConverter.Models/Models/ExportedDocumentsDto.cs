using System;

namespace DocumentConverter.Models.Models
{
    public class ExportedDocumentsDto
    {
        public string OrganizationId { get; set; }
        public int FormatId { get; set; }
        public string FileName { get; set; }
        public DateTime ExportedDate { get; set; }

    }
}
