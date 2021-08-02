using DocumentConverter.Contracts.Interfaces.OrganizationHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentConverter.Cli
{
    public class OperationLogger
    {
        private readonly IOrganizationHandlerService _organizationHandlerService;
        private readonly IOrganizationHandlerRepository _organizationHandlerRepository;
        public OperationLogger(
            IOrganizationHandlerService organizationHandlerService,
            IOrganizationHandlerRepository organizationHandlerRepository)
        {
            _organizationHandlerRepository = organizationHandlerRepository;
            _organizationHandlerService = organizationHandlerService;
        }

    }
}
