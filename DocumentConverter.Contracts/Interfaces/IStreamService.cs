using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentConverter.Contracts.Interfaces
{
    public interface IStreamService
    {
        public Stream Read(string documentPath);
        public bool Write(Stream stream, string filePath);
    }
}
