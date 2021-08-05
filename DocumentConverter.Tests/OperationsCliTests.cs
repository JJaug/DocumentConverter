using DocumentConverter.BusinessLogic.Classes;
using DocumentConverter.BusinessLogic.FactoryPattern;
using DocumentConverter.Cli;
using DocumentConverter.Contracts.Interfaces;
using DocumentConverter.Contracts.Interfaces.Documents;
using DocumentConverter.Contracts.Interfaces.Organizations;
using DocumentConverter.Tests.TestData;
using NSubstitute;
using NUnit.Framework;
using System.IO;

namespace DocumentConverter.Tests
{
    [TestFixture]
    public class OperationsCliTests
    {
        private IStreamService _streamService;
        private IStreamService _streamServiceSubstitute;
        private IConvertFactory _convertFactory;
        private IOrganizationService _organizationService;
        private IExportFactory _exportFactory;
        private IDocumentService _documentService;
        private IOperationsCli _operationsCli;
        private IExportFactory _exportFactorySubstitute;
        private IConvertFactory _convertFactorySubstitute;
        private string documentPath;
        private ModelsForTests _modelsForTests;


        [SetUp]
        public void Setup()
        {
            _modelsForTests = new ModelsForTests();
            _streamServiceSubstitute = Substitute.For<IStreamService>();
            _streamService = new StreamService();
            _convertFactory = new ConvertFactory();
            _convertFactorySubstitute = Substitute.For<IConvertFactory>();
            _organizationService = Substitute.For<IOrganizationService>();
            _exportFactory = new ExportFactory();
            _exportFactorySubstitute = Substitute.For<IExportFactory>();
            _documentService = Substitute.For<IDocumentService>();
            _operationsCli = new OperationsCli(_organizationService, _streamServiceSubstitute, _documentService, _exportFactorySubstitute, _convertFactorySubstitute);
            documentPath = "C:\\Users\\jonas.jaugelis\\source\\repos\\DocumentConverter\\FilesToExport\\BooksOrder.xml";

        }
        [Test]
        public void Should_ReturnFirstIfAsFalse_When_NoOrganizationExistInFilePath()
        {
            var stream = _streamService.Read(documentPath);
            var formatType = "XML";
            var converter = _convertFactory.GetFileType(formatType);
            var order = converter.Convert(stream);

            _organizationService.CheckIfOrganizationsInFilePathExist(order).Returns(false);

            var result = _operationsCli.ExportFile();

            Assert.AreEqual(result, "Bad filepath or no organizatios");

        }
        [Test]
        public void Should_ReturnSecondIfFalse_When_CouldNotWriteStreamIntoFilePath()
        {
            var stream = _streamService.Read(documentPath);
            var formatType = "XML";
            var converter = _convertFactory.GetFileType(formatType);
            var order = converter.Convert(stream);
            var folderPath = "C:\\Users\\jonas.jaugelis\\source\\repos\\DocumentConverter\\FilesForOrganizations\\Organization546545\\";
            var fileName = $"_exported_{order.Name}.json";
            var filePath = Path.Combine(folderPath, fileName);
            _organizationService.CheckIfOrganizationsInFilePathExist(order).Returns(true);
            _organizationService.GetExportPath(order).Returns(folderPath);
            _organizationService.GetFormatType(order).Returns("JSON");
            var exporter = _exportFactory.GetFileType("JSON");
            var formatTypeStream = exporter.Export(order);
            _streamServiceSubstitute.Write(formatTypeStream, filePath).Returns(false);

            var result = _operationsCli.ExportFile();

            Assert.AreEqual(result, "unexpected error occured.");
        }
        [Test]
        public void Should_ReturnSecondIfTrue_When_StreamAndFormatAreCorrect()
        {
            var stream = _streamService.Read(documentPath);
            var formatType = "XML";
            var converter = _convertFactory.GetFileType(formatType);
            var order = converter.Convert(stream);
            var folderPath = "C:\\Users\\jonas.jaugelis\\source\\repos\\DocumentConverter\\FilesForOrganizations\\Organization546545\\";
            var fileName = $"_exported_{order.Name}.json";
            var filePath = Path.Combine(folderPath, fileName);
            _organizationService.CheckIfOrganizationsInFilePathExist(order).Returns(true);
            _organizationService.GetExportPath(order).Returns(folderPath);
            _organizationService.GetFormatType(order).Returns("JSON");
            var exporter = _exportFactory.GetFileType("JSON");
            var formatTypeStream = exporter.Export(order);
            _streamServiceSubstitute.Write(formatTypeStream, filePath).Returns(true);

            var result = _operationsCli.ExportFile();

            Assert.AreEqual(result, $"Document was successfully exported! Devilvered to { filePath}");
        }
        [Test]
        public void Should_ReturnExportedDocumentsInfo_When_GivenOrganizationId()
        {

        }
    }
}
