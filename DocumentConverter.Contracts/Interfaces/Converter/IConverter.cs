using DocumentConverter.Models.Models;
using System.IO;

namespace DocumentConverter.Contracts.Interfaces.Converter
{
    public interface IConverter
    {
        public Order Convert(Stream stream);
    }
}
