using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

using LifXNet;
using LifXNet.Messages;
using System.IO;

namespace LifXNetTest
{
    [TestClass]
    public class MessageSerializationTests
    {
        #region Helpers

        private static string GetHexByteStringFromBuffer(MemoryStream buffer)
        {
            // This is monumentally inefficient but it's pretty and this is test code so we'll keep it.
            //
            return buffer.GetBuffer()
                .Select(b => string.Format("{0:X2}", b))
                .Aggregate((left, right) => left + right)
                .ToLower();
        }

        #endregion

        [TestMethod]
        public void Test_GetService_MessageSerialization()
        {
            const string ExpectedMessageByteString = "2400003412efcdab00000000000000000000000000000042000000000000000002000000";

            GetServiceRequest getServiceRequest = new GetServiceRequest();
            getServiceRequest.AckRequired = false;
            getServiceRequest.ResponseRequired = false;
            getServiceRequest.SequenceNumber = 0x42;
            getServiceRequest.Source = 0xabcdef12;

            MemoryStream buffer = new MemoryStream(getServiceRequest.MessageSizeInBytes);
            getServiceRequest.SerializeTo(buffer);

            string serializedString = GetHexByteStringFromBuffer(buffer);

            Assert.AreEqual(ExpectedMessageByteString, serializedString);
        }
    }
}
