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
        #region Test Messages

        private const string StateServiceResponseTestString = "2900005404ae7306d073d512006c00004c4946585632000098ccad3a23613d1403000000017cdd0000";

        #endregion

        #region Helpers

        private static byte[] GetResponseBufferFromString(string s)
        {
            return Enumerable.Range(0, s.Length / 2)
                .Select(index => Convert.ToByte(s.Substring(index * 2, 2), 16))
                .ToArray();
        }

        #endregion

        [TestMethod]
        public void TestStateServiceResponseGeneration()
        {
            byte[] testMessage = GetResponseBufferFromString(StateServiceResponseTestString);

            Response response = ResponseFactory.ConstructResponseFromBuffer(testMessage);
            Assert.IsNotNull(response, "ResponseFactory unexpectedly failed to deserialize the StateService message!");

            StateServiceResponse stateServiceResponse = response as StateServiceResponse;
            Assert.IsNotNull(response, "ResponseFactory did not produce a StateServiceResponse object!");

            // TODO: Check the internals of the response
        }
    }
}
