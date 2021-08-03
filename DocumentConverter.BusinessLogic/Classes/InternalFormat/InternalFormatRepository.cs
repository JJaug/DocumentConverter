using DocumentConverter.Contracts.Interfaces.InternalFormat;
using DocumentConverter.EF.Core.Models;

namespace DocumentConverter.BusinessLogic.Classes.InternalFormat
{
    public class InternalFormatRepository : IInternalFormatRepository
    {
        private readonly OrganizationsAndDocumentsContext _context;
        public InternalFormatRepository(OrganizationsAndDocumentsContext context)
        {
            _context = context;
        }

    }
}
