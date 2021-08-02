namespace DocumentConverter.Contracts.Interfaces.InternalFormat
{
    public interface IInternalFormatService
    {
        public bool CheckIfOrganizationsInFilePathExist(string documentPath);
    }
}
