using DocumentConverter.Contracts.Interfaces.InternalFormat;
using System.IO;
using System.Text;

namespace DocumentConverter.BusinessLogic.Classes.InternalFormat
{
    public class InternalFormatService : IInternalFormatService
    {
        private readonly IInternalFormatRepository _internalFormatRepository;
        public InternalFormatService(IInternalFormatRepository internalFormatRepository)
        {
            _internalFormatRepository = internalFormatRepository;
        }


    }
}
