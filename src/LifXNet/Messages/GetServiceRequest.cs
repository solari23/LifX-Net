using System;
using System.IO;

namespace LifXNet.Messages
{
    internal sealed class GetServiceRequest : Request
    {
        public override MessageType MessageType { get { return MessageType.GetService; } }

        public GetServiceRequest()
        {
            AckRequired = false;

            // "Get" messages always get a response regardless.
            //
            ResponseRequired = false;
        }

        public override UInt16 PayloadSizeInBytes
        {
            get
            {
                // No payload for this request.
                //
                return 0;
            }
        }

        protected override void SerializePayloadTo(MemoryStream buffer)
        {
            // No payload for this request.
        }
    }
}
