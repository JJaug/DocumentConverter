using DocumentConverter.Models.Models;

namespace DocumentConverter.Contracts.Interfaces.Documents
{
    public interface IDocumentService
    {
        public void LogExportedDocumentToDatabase(Order order, string fileName);
        public string GetExportedDocumentsInfo(string organizationId);

    }
}
