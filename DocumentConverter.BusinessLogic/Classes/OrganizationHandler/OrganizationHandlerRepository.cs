using DocumentConverter.Contracts.Interfaces.OrganizationHandler;
using DocumentConverter.EF.Core.Models;
using System.Linq;

namespace DocumentConverter.BusinessLogic.Classes.OrganizationHandler
{
    public class OrganizationHandlerRepository : IOrganizationHandlerRepository
    {
        private readonly OrganizationsAndDocumentsContext _context;
        public OrganizationHandlerRepository(OrganizationsAndDocumentsContext context)
        {
            _context = context;
        }
        public void AddToDatabase(Organization organization)
        {
            _context.Organizations.Add(organization);
            _context.SaveChanges();
        }

        public void DeleteFromDatabase(int id, string name)
        {
            var organization = _context.Organizations.FirstOrDefault(o => o.Id == id && o.Name == name);
            _context.Organizations.Remove(organization);
        }

        public int GetFormatId(string formatName)
        {
            var format = _context.Formats.FirstOrDefault(f => f.Name == formatName);
            return format.Id;
        }
    }
}
