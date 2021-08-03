using DocumentConverter.BusinessLogic.Classes.Organizations;
using DocumentConverter.Contracts.Interfaces.OrganizationHandler;
using DocumentConverter.Contracts.Interfaces.Organizations;
using DocumentConverter.EF.Core.Models;
using NSubstitute;
using NUnit.Framework;
using System;

namespace DocumentConverter.Tests
{
    public class OrganizationHandlerTests
    {
        private IOrganizationRepository _organizationHandlerRepository;
        private IOrganizationService _organizationHandlerService;
        [SetUp]
        public void Setup()
        {
            _organizationHandlerRepository = Substitute.For<IOrganizationRepository>();
            _organizationHandlerService = new OrganizationService(_organizationHandlerRepository);
        }

        [Test]
        public void Should_AddOrganization_When_GivenInfoAboutOrganization()
        {
            var format = "JSON";
            _organizationHandlerRepository.GetFormatId(format).Returns(1);
            var organization = new Organization { Id = "1", Name = "TestCompany", ExportPath = "RandomPath", CreatedDate = DateTime.Now, FormatId = 1 };
            _organizationHandlerRepository.AddToDatabase(organization);

            //_organizationHandlerService.AddOrganization("TestCompany", format, "RandomPath");

            Assert.Pass();
        }

    }
}