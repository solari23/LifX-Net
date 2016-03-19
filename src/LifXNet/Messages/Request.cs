using System;
using System.IO;

namespace LifXNet.Messages
{
    /// <summary>
    /// Abstract representation of a Message that will be sent from the client to a device.
    /// </summary>
    internal abstract class Request : Message
    {
        public virtual void SerializeTo(MemoryStream buffer)
        {
            // TODO
            throw new NotImplementedException();
        }

        protected abstract void SerializePayloadTo(MemoryStream buffer);
    }
}
