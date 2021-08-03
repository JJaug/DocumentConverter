using DocumentConverter.Models.Models;

namespace DocumentConverter.Contracts.Interfaces.OrganizationHandler
{
    public interface IOrganizationService
    {
        public void AddOrganization(OrganizationDto organizationDto);
        public void RemoveOrganization(string id, string name);
        public bool CheckIfOrganizationsInFilePathExist(Order order);
        public string GetFormatType(Order order);
        public string GetExportPath(Order order);


    }
}
