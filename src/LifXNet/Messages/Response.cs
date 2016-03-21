using System;
using System.IO;

namespace LifXNet.Messages
{
    /// <summary>
    /// Abstract representation of a response to a Request, received by the client from a device.
    /// </summary>
    internal abstract class Response : Message
    {
        public virtual void DeserializeFrom(MemoryStream buffer)
        {
            // TODO
        }

        protected abstract void DeserializePayloadFrom(MemoryStream buffer);
    }
}
