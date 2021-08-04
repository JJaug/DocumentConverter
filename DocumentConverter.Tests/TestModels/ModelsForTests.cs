using DocumentConverter.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentConverter.Tests.TestModels
{
    public class ModelsForTests
    {
        public Order GetOrderModelWithReceiverAndSender()
        {
            var senderId = "123456";
            var receiverId = "654321";
            var receiver = new Receiver { ID = receiverId };
            var sender = new Sender { ID = senderId };
            return new Order { Receiver = receiver, Sender = sender };
        }
    }
}
