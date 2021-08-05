using DocumentConverter.BusinessLogic.Classes.Organizations;
using DocumentConverter.Contracts.Interfaces.OrganizationHandler;
using DocumentConverter.Contracts.Interfaces.Organizations;
using DocumentConverter.EF.Core.Models;
using DocumentConverter.Models.Models;
using DocumentConverter.Tests.TestData;
using NSubstitute;
using NUnit.Framework;
using System;

namespace DocumentConverter.Tests
{
    [TestFixture]
    public class OrganizationServiceTests
    {
        private IOrganizationRepository _organizationRepository;
        private IOrganizationService _organizationService;
        private ModelsForTests _testModels;
        [SetUp]
        public void Setup()
        {
            _testModels = new ModelsForTests();
            _organizationRepository = Substitute.For<IOrganizationRepository>();
            _organizationService = new OrganizationService(_organizationRepository);
        }

        [Test]
        public void Should_AddOrganization_When_GivenInfoAboutOrganization()
        {
            var format = "JSON";
            _organizationRepository.GetFormatId(format).Returns(1);
            var organization = new Organization { Id = "1", Name = "TestCompany", ExportPath = "RandomPath", CreatedDate = DateTime.Now, FormatId = 1 };
            var organizationDto = new OrganizationDto { Id = "1", Name = "TestCompany", ExportPath = "RandomPath", FormatId = 1, FormatName = "JSON" };
            _organizationRepository.AddToDatabase(organization);

            var result = _organizationService.AddOrganization(organizationDto);

            Assert.That(result, Is.True);
        }
        [Test]
        public void Should_ReturnTrue_When_GivenExistingOrganizations()
        {
            var order = _testModels.GetOrderModelWithReceiverAndSender();
            _organizationRepository.FindOrganizationById(order.Sender.ID).Returns(true);
            _organizationRepository.FindOrganizationById(order.Receiver.ID).Returns(true);

            var result = _organizationService.CheckIfOrganizationsInFilePathExist(order);

            Assert.That(result, Is.True);
        }
        [Test]
        public void Should_ReturnFaslse_When_WithNoExistingOrganization()
        {
            var order = _testModels.GetOrderModelWithReceiverAndSender();
            _organizationRepository.FindOrganizationById(order.Sender.ID).Returns(true);
            _organizationRepository.FindOrganizationById(order.Receiver.ID).Returns(false);

            var result = _organizationService.CheckIfOrganizationsInFilePathExist(order);
            Assert.That(result, Is.False);
        }
        [Test]
        public void Should_ReturnFaslse_When_WithNoExistingOrganizations()
        {
            var order = _testModels.GetOrderModelWithReceiverAndSender();
            _organizationRepository.FindOrganizationById(order.Sender.ID).Returns(false);
            _organizationRepository.FindOrganizationById(order.Receiver.ID).Returns(false);

            var result = _organizationService.CheckIfOrganizationsInFilePathExist(order);
            Assert.That(result, Is.False);
        }
        [Test]
        public void Should_ReturnFormatType_When_GivenOrder()
        {
            var order = _testModels.GetOrderModelWithReceiverAndSender();
            var formatType = "JSON";
            _organizationRepository.GetFormatType(order.Receiver.ID).Returns(formatType);

            var result = _organizationService.GetFormatType(order);

            Assert.AreEqual(result, formatType);
        }
        [Test]
        public void Should_ReturnExportPath_When_GivenOrder()
        {
            var order = _testModels.GetOrderModelWithReceiverAndSender();
            var exportPath = "TestExportPath";
            _organizationRepository.GetOrganizationFilePath(order.Receiver.ID).Returns(exportPath);

            var result = _organizationService.GetExportPath(order);

            Assert.AreEqual(result, exportPath);
        }



    }
}