using DocumentConverter.Models.Models;

namespace DocumentConverter.Contracts.Interfaces.DocumentHandler
{
    public interface IDocumentRepository
    {
        public void AddExportedDocumentLogToDatabase(ExportedDocumentsDto documentDto);

    }
}
