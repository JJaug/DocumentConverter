using DocumentConverter.EF.Core.Models;
using DocumentConverter.Models.Models;
using System;
using System.Collections.Generic;

namespace DocumentConverter.Tests.TestData
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
        public List<ExportedDocument> GetListOfExportedDocuments()
        {

            var listOfDocuments = new List<ExportedDocument>();
            var document1 = new ExportedDocument { Id = 1, OrganizationId = "123", ExportedDate = DateTime.Now, FileName = "TestFileName1", FormatId = 1 };
            var document2 = new ExportedDocument { Id = 2, OrganizationId = "123", ExportedDate = DateTime.Now, FileName = "TestFileName2", FormatId = 1 };
            listOfDocuments.Add(document1);
            listOfDocuments.Add(document2);
            return listOfDocuments;
        }
    }
}
