using DocumentConverter.Contracts.Interfaces.OrganizationHandler;
using DocumentConverter.EF.Core.Models;
using DocumentConverter.Models.Models;
using System;
using System.IO;
using System.Xml.Serialization;

namespace DocumentConverter.BusinessLogic.Classes.OrganizationHandler
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
            var formatId = _organizationRepository.GetFormatId(organizationDto.FormatName);
            var organization = new Organization { Id = organizationDto.Id, Name = organizationDto.Name, FormatId = formatId, ExportPath = organizationDto.ExportPath, CreatedDate = DateTime.Now };
            _organizationRepository.AddToDatabase(organization);
        }
        public void RemoveOrganization(string id, string name)
        {
            _organizationRepository.DeleteFromDatabase(id, name);
        }
        public bool CheckIfOrganizationsInFilePathExist(string documentPath)
        {
            var order = new Order();
            XmlSerializer xs = new XmlSerializer(typeof(Order));

            using (FileStream stream = File.Open(documentPath, FileMode.Open))
            {
                order = (Order)xs.Deserialize(stream);
            }
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
    }
}
