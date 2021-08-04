using DocumentConverter.Contracts.Interfaces.OrganizationHandler;
using DocumentConverter.Contracts.Interfaces.Organizations;
using DocumentConverter.EF.Core.Models;
using DocumentConverter.Models.Models;
using System;

namespace DocumentConverter.BusinessLogic.Classes.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }
        public void AddOrganization(OrganizationDto organizationDto)
        {
            int formatId = 0;
            try
            {
                formatId = _organizationRepository.GetFormatId(organizationDto.FormatName);
            }
            catch
            {
                Console.WriteLine("Bad format name, maybe there was a typo.");
            }
            var organization = new Organization { Id = organizationDto.Id, Name = organizationDto.Name, FormatId = formatId, ExportPath = organizationDto.ExportPath, CreatedDate = DateTime.Now };
            _organizationRepository.AddToDatabase(organization);

        }
        public void RemoveOrganization(string id, string name)
        {
            _organizationRepository.DeleteFromDatabase(id, name);
        }
        public bool CheckIfOrganizationsInFilePathExist(Order order)
        {
            var senderId = order.Sender.ID;
            var receiverId = order.Receiver.ID;
            if (_organizationRepository.FindOrganizationById(senderId) && _organizationRepository.FindOrganizationById(receiverId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetFormatType(Order order)
        {
            var receiverOrganizationId = order.Receiver.ID;
            return _organizationRepository.GetFormatType(receiverOrganizationId);
        }
        public string GetExportPath(Order order)
        {
            var receiverOrganizationId = order.Receiver.ID;
            return _organizationRepository.GetOrganizationFilePath(receiverOrganizationId);
        }
    }
}
