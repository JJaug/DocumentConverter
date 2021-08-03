﻿using DocumentConverter.Contracts.Interfaces.DocumentHandler;
using DocumentConverter.EF.Core.Models;
using DocumentConverter.Models.Models;

namespace DocumentConverter.BusinessLogic.Classes.DocumentHandler
{
    public class DocumentRepository : IDocumentRepository
    {
        private OrganizationsAndDocumentsContext _context;
        public DocumentRepository(OrganizationsAndDocumentsContext context)
        {
            _context = context;
        }
        public void AddExportedDocumentLogToDatabase(ExportedDocumentsDto documentDto)
        {
            var exportedDocument = new ExportedDocument { OrganizationId = documentDto.OrganizationId, FormatId = documentDto.FormatId, FileName = documentDto.FileName, ExportedDate = documentDto.ExportedDate };
            _context.ExportedDocuments.Add(exportedDocument);
        }
    }
}
