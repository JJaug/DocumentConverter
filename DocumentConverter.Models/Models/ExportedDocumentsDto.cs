using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
