using System;

namespace LifXNet.Messages
{
    /// <summary>
    /// Abstract representation of a message sent over the LAN between the client and LifX devices.
    /// </summary>
    internal abstract class Message
    {
        public const UInt16 FrameSizeInBytes = 8;
        public const UInt16 FrameAddressSizeInBytes = 16;
        public const UInt16 ProtocolHeaderSizeInBytes = 12;

        /// <summary>
        /// Gets or sets whether the Message requires an acknowledgement.
        /// </summary>
        public bool AckRequired { get; set; }

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
        public abstract UInt16 PayloadSizeInBytes { get; }

        /// <summary>
        /// Gets or sets whether the Message requires a response.
        /// </summary>
        public bool ResponseRequired { get; set; }

        /// <summary>
        /// Gets or sets the Message's sequence number.
        /// </summary>
        public byte SequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the Message's source, a value which can be set by clients that
        /// is echoed in the response from devices.
        /// </summary>
        public UInt32 Source { get; set; }

        /// <summary>
        /// The MAC Address of the device targetted by this message.
        /// </summary>
        public MacAddress Target { get; set; } = MacAddress.Empty;
    }
}
