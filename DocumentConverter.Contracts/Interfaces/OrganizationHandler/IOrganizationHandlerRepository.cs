using DocumentConverter.EF.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentConverter.Contracts.Interfaces.OrganizationHandler
{
    public interface IOrganizationHandlerRepository
    {
        public void AddToDatabase(Organization organization);
        public int GetFormatId(string formatName);
        public void DeleteFromDatabase(int id, string name);
    }
}
