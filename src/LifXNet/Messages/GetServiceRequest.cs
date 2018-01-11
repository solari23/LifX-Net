using System;
using System.Diagnostics;
using System.IO;

namespace LifXNet.Messages
{
    public sealed class GetServiceRequest : Request
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
            Debug.Assert(buffer != null);

            // No payload for this request.
        }
    }
}
