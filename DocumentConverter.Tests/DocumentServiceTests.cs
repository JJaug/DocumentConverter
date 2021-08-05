using DocumentConverter.BusinessLogic.Classes.DocumentHandler;
using DocumentConverter.Contracts.Interfaces.DocumentHandler;
using DocumentConverter.Contracts.Interfaces.Organizations;
using DocumentConverter.Tests.TestData;
using NSubstitute;
using NUnit.Framework;

namespace DocumentConverter.Tests
{
    [TestFixture]
    public class DocumentServiceTests
    {
        private IOrganizationRepository _organizationRepository;
        private IDocumentRepository _documentRepository;
        private IDocumentService _documentService;
        private ModelsForTests _modelsForTests;
        [SetUp]
        public void Setup()
        {
            _organizationRepository = Substitute.For<IOrganizationRepository>();
            _documentRepository = Substitute.For<IDocumentRepository>();
            _documentService = new DocumentService(_organizationRepository, _documentRepository);
            _modelsForTests = new ModelsForTests();
        }
        [Test]
        public void Should_GetExportedDocumentsInfo_When_GivenOrganizationId()
        {
            var listOfDocuments = _modelsForTests.GetListOfExportedDocuments();
            var stringOfExportedDocuments = string.Empty;
            _documentRepository.GetExportedDocumentsByOrganizationId("123").Returns(listOfDocuments);
            foreach (var document in listOfDocuments)
            {
                stringOfExportedDocuments += $"Document ID: {document.Id}, Organization ID: {document.OrganizationId}, Format ID: {document.FormatId}, File Name: {document.FileName}, Exported Date: {document.ExportedDate}\n";
            }

            var result = _documentService.GetExportedDocumentsInfo("123");

            Assert.AreEqual(stringOfExportedDocuments, result);
        }
    }
}
