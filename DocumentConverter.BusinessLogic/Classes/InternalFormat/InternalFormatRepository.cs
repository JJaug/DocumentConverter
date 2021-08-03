using DocumentConverter.Contracts.Interfaces.InternalFormat;
using DocumentConverter.EF.Core.Models;

namespace DocumentConverter.BusinessLogic.Classes.InternalFormat
{
    public class InternalFormatRepository : IInternalFormatRepository
    {
        private readonly OrganizationsAndDocumentsContext _organizationsAndDocumentsContext;
        public InternalFormatRepository(OrganizationsAndDocumentsContext organizationsAndDocumentsContext)
        {
            _organizationsAndDocumentsContext = organizationsAndDocumentsContext;
        }

    }
}
