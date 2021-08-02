using DocumentConverter.Contracts.Interfaces;
using DocumentConverter.Contracts.Interfaces.OrganizationHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentConverter.Cli
{
    public class OperationsCli : IOperationsCli
    {
        private readonly IOrganizationHandlerService _organizationHandlerService;
        public OperationsCli(IOrganizationHandlerService organizationHandlerService)
        {
            _organizationHandlerService = organizationHandlerService;
        }
        public void ExecuteProgram(int input)
        {
            switch (input)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    AddOrganization();
                    break;
                case 4:
                    RemoveOrganization();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Wrong input value.");
                    break;
            }
        }
        public void CliInformation()
        {
            Console.WriteLine("Type in the number");
            Console.WriteLine("1. Export file");
            Console.WriteLine("2. Check files");
            Console.WriteLine("3. Add organization");
            Console.WriteLine("4. Remove organization");
            Console.WriteLine("5. Exit");
        }
        public void AddOrganization()
        {
            Console.WriteLine("Organization Name");
            var name = Console.ReadLine();
            Console.WriteLine("Organization Format Name");
            var format = Console.ReadLine();
            Console.WriteLine("Organization Export Path");
            var path = Console.ReadLine();
            _organizationHandlerService.AddOrganization(name, format, path);
        }
        public void RemoveOrganization()
        {
            Console.WriteLine("Organization Id");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Organization Name");
            var name = Console.ReadLine();
            _organizationHandlerService.RemoveOrganization(id, name);

        }
    }
}
