using DocumentConverter.Contracts.Interfaces.Organizations;
using DocumentConverter.EF.Core.Models;
using System.Linq;

namespace DocumentConverter.BusinessLogic.Classes.Organizations
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly OrganizationsAndDocumentsContext _context;
        public OrganizationRepository(OrganizationsAndDocumentsContext context)
        {
            _context = context;
        }
        public void AddToDatabase(Organization organization)
        {
            _context.Organizations.Add(organization);
            _context.SaveChanges();
        }

        public void DeleteFromDatabase(string id, string name)
        {
            var organization = _context.Organizations.FirstOrDefault(o => o.Id == id && o.Name == name);
            _context.Organizations.Remove(organization);
        }

        public int GetFormatId(string formatName)
        {
            return _context.Formats.FirstOrDefault(f => f.Name == formatName).Id;
        }
        public bool FindOrganizationById(string id)
        {
            var organization = _context.Organizations.FirstOrDefault(o => o.Id == id);
            return organization != null;
        }
        public string GetFormatType(string organizationId)
        {
            var formatId = _context.Organizations.FirstOrDefault(o => o.Id == organizationId).FormatId;
            return _context.Formats.FirstOrDefault(f => f.Id == formatId).Name;

        }
        public string GetOrganizationFilePath(string organizationId)
        {
            return _context.Organizations.FirstOrDefault(o => o.Id == organizationId).ExportPath;
        }
    }
}
