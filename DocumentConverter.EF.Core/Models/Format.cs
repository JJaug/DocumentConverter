using System.Collections.Generic;

#nullable disable

namespace DocumentConverter.EF.Core.Models
{
    public partial class Format
    {
        public Format()
        {
            ExportedDocuments = new HashSet<ExportedDocument>();
            Organizations = new HashSet<Organization>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExportedDocument> ExportedDocuments { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
    }
}
