using System;
using System.IO;

namespace LifXNet.Messages
{
    internal class StateServiceResponse : Response
    {
        public override MessageType MessageType { get { return MessageType.StateService; } }

        public override int PayloadSizeInBytes
        {
            get
            {
                // TODO
                throw new NotImplementedException();
            }
        }

        protected override void DeserializePayloadFrom(MemoryStream buffer)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
