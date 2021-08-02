using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentConverter.Contracts.Interfaces
{
    public interface IOperationsCli
    {
        public void ExecuteProgram(int input);
        public void CliInformation();

    }
}
