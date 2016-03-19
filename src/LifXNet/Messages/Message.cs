using System;

namespace LifXNet.Messages
{
    /// <summary>
    /// Abstract representation of a message sent over the LAN between the client and LifX devices.
    /// </summary>
    internal abstract class Message
    {
        public const int FrameSizeInBytes = 8;
        public const int FrameAddressSizeInBytes = 16;
        public const int ProtocolHeaderSizeInBytes = 12;

        /// <summary>
        /// Gets the size of this message in bytes.
        /// </summary>
        public virtual UInt16 MessageSizeInBytes
        {
            get
            {
                return Convert.ToUInt16(
                    FrameSizeInBytes
                    + FrameAddressSizeInBytes
                    + ProtocolHeaderSizeInBytes
                    + PayloadSizeInBytes);
            }
        }

        /// <summary>
        /// Gets the message's MessageType.
        /// </summary>
        public abstract MessageType MessageType { get; }

        /// <summary>
        /// Gets the size of this message's payload in bytes.
        /// </summary>
        public abstract int PayloadSizeInBytes { get; }
    }
}
