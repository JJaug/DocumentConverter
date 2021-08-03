using DocumentConverter.Contracts.Interfaces.OrganizationHandler;
using DocumentConverter.EF.Core.Models;
using System;

namespace DocumentConverter.BusinessLogic.Classes.OrganizationHandler
{
    public class OrganizationHandlerService : IOrganizationHandlerService
    {
        private readonly IOrganizationHandlerRepository _organizationHandlerRepository;
        public OrganizationHandlerService(IOrganizationHandlerRepository organizationHandlerRepository)
        {
            _organizationHandlerRepository = organizationHandlerRepository;
        }
        public void AddOrganization(string id, string name, string format, string filePath)
        {
            var formatId = _organizationHandlerRepository.GetFormatId(format);
            var organization = new Organization { Id = id, Name = name, FormatId = formatId, ExportPath = filePath, CreatedDate = DateTime.Now };
            _organizationHandlerRepository.AddToDatabase(organization);
        }
        public void RemoveOrganization(string id, string name)
        {
            _organizationHandlerRepository.DeleteFromDatabase(id, name);
        }
    }
}
