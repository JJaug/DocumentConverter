using DocumentConverter.Models.Models;
using System.IO;

namespace DocumentConverter.Contracts.Interfaces
{
    public interface IExporter
    {
        Stream Export(Order order);
    }
}
