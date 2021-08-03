namespace DocumentConverter.Contracts.Interfaces.OrganizationHandler
{
    public interface IOrganizationHandlerService
    {
        public void AddOrganization(string id, string naem, string format, string filePath);
        public void RemoveOrganization(string id, string name);
    }
}
