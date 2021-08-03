using DocumentConverter.Contracts.Interfaces.InternalFormat;

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
