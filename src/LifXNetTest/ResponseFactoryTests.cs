using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

using LifXNet;
using LifXNet.Messages;

namespace LifXNetTest
{
    [TestClass]
    public class ResponseFactoryTests
    {
        #region Helpers

        private static byte[] GetResponseBufferFromHexString(string s)
        {
            return Enumerable.Range(0, s.Length / 2)
                .Select(index => Convert.ToByte(s.Substring(index * 2, 2), 16))
                .ToArray();
        }

        #endregion

        [TestMethod]
        public void Test_StateService_ResponseGeneration()
        {
            const string TestResponseString = "2900005404ae7306d073d512006c00004c4946585632000098ccad3a23613d1403000000017cdd0000";

            byte[] testMessage = GetResponseBufferFromHexString(TestResponseString);

            Response response = ResponseFactory.ConstructResponseFromBuffer(testMessage);
            Assert.IsNotNull(response, "ResponseFactory unexpectedly failed to deserialize the StateService message!");

            StateServiceResponse stateServiceResponse = response as StateServiceResponse;
            Assert.IsNotNull(response, "ResponseFactory did not produce a StateServiceResponse object!");

            // Check the internals of the response
            //
            MacAddress expectedMacAddress = new MacAddress(new byte[] { 0xd0, 0x73, 0xd5, 0x12, 0x00, 0x6c });
            Assert.AreEqual<MacAddress>(expectedMacAddress, stateServiceResponse.Target);
            Assert.AreEqual<UInt32>(108244484, stateServiceResponse.Source);
            Assert.AreEqual<byte>(0, stateServiceResponse.SequenceNumber);
            Assert.AreEqual<byte>(1, stateServiceResponse.Service);
            Assert.AreEqual<UInt32>(56700, stateServiceResponse.PortNumber);
        }
    }
}
