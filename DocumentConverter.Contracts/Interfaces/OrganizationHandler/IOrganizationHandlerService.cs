namespace DocumentConverter.Contracts.Interfaces.OrganizationHandler
{
    public interface IOrganizationHandlerService
    {
        public void AddOrganization(string naem, string format, string filePath);
        public void RemoveOrganization();
        public void UpdateOrganization();
    }
}
