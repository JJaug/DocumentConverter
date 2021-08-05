using DocumentConverter.Contracts.Interfaces.Converter;
using DocumentConverter.Models.Models;
using System.IO;
using System.Runtime.Serialization.Json;

namespace DocumentConverter.BusinessLogic.Classes.Converter
{
    public class ConvertToJson : IConverter
    {
        public Order Convert(Stream stream)
        {
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Order));
            Order order = (Order)deserializer.ReadObject(stream);
            return order;
        }
    }
}
