using DocumentConverter.EF.Core.Models;

namespace DocumentConverter.Contracts.Interfaces.OrganizationHandler
{
    public interface IOrganizationHandlerRepository
    {
        public void AddToDatabase(Organization organization);
        public int GetFormatId(string formatName);
        public void DeleteFromDatabase(int id, string name);
    }
}
