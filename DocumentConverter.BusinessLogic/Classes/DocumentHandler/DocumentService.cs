using DocumentConverter.Contracts.Interfaces.DocumentHandler;
using DocumentConverter.Contracts.Interfaces.Organizations;
using DocumentConverter.Models.Models;
using System;

namespace DocumentConverter.BusinessLogic.Classes.DocumentHandler
{
    public class DocumentService : IDocumentService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IDocumentRepository _documentRepository;
        public DocumentService(IOrganizationRepository organizationRepository, IDocumentRepository documentRepository)
        {
            _organizationRepository = organizationRepository;
            _documentRepository = documentRepository;
        }
        public void LogExportedDocumentToDatabase(Order order, string fileName)
        {
            var formatId = _organizationRepository.GetFormatId(_organizationRepository.GetFormatType(order.Sender.ID));
            var documentDto = new ExportedDocumentsDto { OrganizationId = order.Sender.ID, FormatId = formatId, FileName = fileName, ExportedDate = DateTime.Now };
            _documentRepository.AddExportedDocumentLogToDatabase(documentDto);
        }
        public string GetExportedDocumentsInfo(string organizationId)
        {
            try
            {
                var stringOfExportedDocuments = string.Empty;
                var exportedDocuments = _documentRepository.GetExportedDocumentsByOrganizationId(organizationId);
                foreach (var document in exportedDocuments)
                {
                    stringOfExportedDocuments += $"Document ID: {document.Id}, Organization ID: {document.OrganizationId}, Format ID: {document.FormatId}, File Name: {document.FileName}, Exported Date: {document.ExportedDate}\n";
                }
                return stringOfExportedDocuments;
            }
            catch
            {
                return "Wrong organization ID, or organization has no exported documents.";
            }

        }
    }
}
