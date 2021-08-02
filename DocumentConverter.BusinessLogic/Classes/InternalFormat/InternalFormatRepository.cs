using DocumentConverter.Contracts.Interfaces.InternalFormat;
using DocumentConverter.EF.Core.Models;
using System.Linq;

namespace DocumentConverter.BusinessLogic.Classes.InternalFormat
{
    public class InternalFormatRepository : IInternalFormatRepository
    {
        private readonly OrganizationsAndDocumentsContext _organizationsAndDocumentsContext;
        public InternalFormatRepository(OrganizationsAndDocumentsContext organizationsAndDocumentsContext)
        {
            _organizationsAndDocumentsContext = organizationsAndDocumentsContext;
        }
        public bool FindOrganizationById(int id)
        {
            var organization = _organizationsAndDocumentsContext.Organizations.FirstOrDefault(o => o.Id == id);
            if (organization != null)
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
