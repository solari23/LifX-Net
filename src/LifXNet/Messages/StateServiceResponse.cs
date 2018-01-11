using System;
using System.Diagnostics;
using System.IO;

namespace LifXNet.Messages
{
    public sealed class StateServiceResponse : Response
    {
        /// <summary>
        /// Gets the Device's Service flags from the response. Currently this will only ever be "1" meaning UDP.
        /// </summary>
        public byte Service { get; private set; }

        /// <summary>
        /// Gets the Device's port number from the response.
        /// </summary>
        public UInt32 PortNumber { get; private set; }

        #region Response Implementation & Overrides

        public override MessageType MessageType { get { return MessageType.StateService; } }

        public override UInt16 PayloadSizeInBytes
        {
            get
            {
                return 
                    1       // Service    - byte
                    + 4;    // PortNumber - UInt32
            }
        }

        protected override void DeserializePayloadFrom(MemoryStream buffer)
        {
            Debug.Assert(buffer != null);

            // The first byte contains the Device's Service flags.
            //
            Service = buffer.LittleEndianReadByte();

            // The next 4 bytes contain the Device's port number.
            //
            PortNumber = buffer.LittleEndianReadUInt32();
        }

        #endregion
    }
}
