using DocumentConverter.Contracts.Interfaces.Documents;
using DocumentConverter.EF.Core.Models;
using DocumentConverter.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace DocumentConverter.BusinessLogic.Classes.Documents
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly OrganizationsAndDocumentsContext _context;
        public DocumentRepository(OrganizationsAndDocumentsContext context)
        {
            _context = context;
        }
        public void AddExportedDocumentLogToDatabase(ExportedDocumentsDto documentDto)
        {
            var exportedDocument = new ExportedDocument { OrganizationId = documentDto.OrganizationId, FormatId = documentDto.FormatId, FileName = documentDto.FileName, ExportedDate = documentDto.ExportedDate };
            _context.ExportedDocuments.Add(exportedDocument);
            _context.SaveChanges();
        }
        public List<ExportedDocument> GetExportedDocumentsByOrganizationId(string organizationId)
        {
            return _context.ExportedDocuments.Where(e => e.OrganizationId == organizationId).ToList();
        }
    }
}
