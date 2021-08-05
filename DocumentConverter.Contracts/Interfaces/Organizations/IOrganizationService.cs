using DocumentConverter.Models.Models;

namespace DocumentConverter.Contracts.Interfaces.Organizations
{
    public interface IOrganizationService
    {
        public bool AddOrganization(OrganizationDto organizationDto);
        public bool RemoveOrganization(string id, string name);
        public bool CheckIfOrganizationsInFilePathExist(Order order);
        public string GetFormatType(Order order);
        public string GetExportPath(Order order);


    }
}
