using DocumentConverter.Contracts.Interfaces.InternalFormat;
using DocumentConverter.Models.Models;
using System.IO;
using System.Xml.Serialization;

namespace DocumentConverter.BusinessLogic.Classes.InternalFormat
{
    public class InternalFormatService : IInternalFormatService
    {
        private readonly IInternalFormatRepository _internalFormatRepository;
        public InternalFormatService(IInternalFormatRepository internalFormatRepository)
        {
            _internalFormatRepository = internalFormatRepository;
        }
        public bool CheckIfOrganizationsInFilePathExist(string documentPath)
        {
            var order = new Order();
            XmlSerializer xs = new XmlSerializer(typeof(Order));

            using (FileStream stream = File.Open(documentPath, FileMode.Open))
            {
                order = (Order)xs.Deserialize(stream);
            }
            var senderId = order.Sender.ID;
            var receiverId = order.Receiver.ID;
            if (_internalFormatRepository.FindOrganizationById(senderId) && _internalFormatRepository.FindOrganizationById(receiverId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
