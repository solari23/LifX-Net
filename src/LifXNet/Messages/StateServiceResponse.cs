using System;
using System.IO;

namespace LifXNet.Messages
{
    internal sealed class StateServiceResponse : Response
    {
        public override MessageType MessageType { get { return MessageType.StateService; } }

        public override UInt16 PayloadSizeInBytes
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
