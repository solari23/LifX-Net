using System;
using System.IO;

namespace LifXNet.Messages
{
    internal sealed class GetServiceRequest : Request
    {
        public override MessageType MessageType { get { return MessageType.GetService; } }

        public override UInt16 PayloadSizeInBytes
        {
            get
            {
                // TODO
                throw new NotImplementedException();
            }
        }

        protected override void SerializePayloadTo(MemoryStream buffer)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
