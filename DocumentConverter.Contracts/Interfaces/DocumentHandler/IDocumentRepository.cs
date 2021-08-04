using DocumentConverter.EF.Core.Models;
using DocumentConverter.Models.Models;
using System.Collections.Generic;

namespace DocumentConverter.Contracts.Interfaces.DocumentHandler
{
    public interface IDocumentRepository
    {
        public void AddExportedDocumentLogToDatabase(ExportedDocumentsDto documentDto);
        public List<ExportedDocument> GetExportedDocumentsByOrganizationId(string organizationId);

    }
}
