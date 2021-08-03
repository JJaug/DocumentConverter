using DocumentConverter.EF.Core.Models;

namespace DocumentConverter.Contracts.Interfaces.OrganizationHandler
{
    public interface IOrganizationRepository
    {
        public void AddToDatabase(Organization organization);
        public int GetFormatId(string formatName);
        public void DeleteFromDatabase(string id, string name);
        public bool FindOrganizationById(string id);
        public int GetFormatType(string organizationId);

    }
}
