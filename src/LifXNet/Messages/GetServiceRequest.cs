using System;
using System.IO;

namespace LifXNet.Messages
{
    internal class GetServiceRequest : Request
    {
        public override MessageType MessageType { get { return MessageType.GetService; } }

        public override int PayloadSizeInBytes
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
