namespace DocumentConverter.Contracts.Interfaces
{
    public interface IOperationsCli
    {
        public void ExecuteProgram(int input);
        public void CliInformation();
        public string ExportFile();
        public string CheckFiles();
        public void AddOrganization();
        public void RemoveOrganization();
    }
}
