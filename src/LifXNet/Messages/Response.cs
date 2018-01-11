using System;
using System.Diagnostics;
using System.IO;

namespace LifXNet.Messages
{
    /// <summary>
    /// Abstract representation of a response to a Request, received by the client from a device.
    /// </summary>
    public abstract class Response : Message
    {
        private UInt16 _messageSizeRead = 0;
        private UInt16 _protocolVersionRead = 0;

        /// <summary>
        /// Deserializes the Response from the given buffer.
        /// </summary>
        /// <param name="buffer">The buffer to deserialize the Response object from.</param>
        public virtual void DeserializeFrom(MemoryStream buffer)
        {
            Debug.Assert(buffer != null);

            ReadFrame(buffer);
            ReadFrameAddress(buffer);
            ReadProtocolHeader(buffer);
            DeserializePayloadFrom(buffer);
        }

        /// <summary>
        /// Deserializes the payload of the Response from the given buffer.
        /// </summary>
        /// <param name="buffer">The buffer to deserialize the Response payload from.</param>
        protected abstract void DeserializePayloadFrom(MemoryStream buffer);

        /// <summary>
        /// Reads the Frame portion of the message header.
        /// See http://lan.developer.lifx.com/docs/header-description for more details.
        /// </summary>
        /// <param name="buffer">The buffer to read from.</param>
        private void ReadFrame(MemoryStream buffer)
        {
            Debug.Assert(buffer != null);

            // Read the message size (2B) and verify it matches the expected size.
            //
            _messageSizeRead = buffer.LittleEndianReadUInt16();

            if (_messageSizeRead != MessageSizeInBytes)
            {
                throw new LifXNetException(
                    "Size of received message does not match expected size! Expect {0}B for messages of type {1}, but received {2}",
                    MessageSizeInBytes,
                    MessageType,
                    _messageSizeRead);
            }

            // The next 2 bytes contain some flags we don't care about, and the protocol number
            // (the last 12 bits.) We need to verify the protocol number matches what we expect.
            //
            const UInt16 ProtocolMask = 0xFFF;

            UInt16 temp = buffer.LittleEndianReadUInt16();
            _protocolVersionRead = (UInt16)(temp & ProtocolMask);

            if (_protocolVersionRead != Constants.LifXProtocolNumber)
            {
                throw new LifXNetException(
                    "Received message using unsupported protocol version '{0}'",
                    _protocolVersionRead);
            }

            // The last 4 bytes of the Frame are the message Source.
            //
            Source = buffer.LittleEndianReadUInt32();
        }

        /// <summary>
        /// Reads the Frame Address portion of the message header.
        /// See http://lan.developer.lifx.com/docs/header-description for more details.
        /// </summary>
        /// <param name="buffer">The buffer to read from.</param>
        private void ReadFrameAddress(MemoryStream buffer)
        {
            Debug.Assert(buffer != null);

            // The first 8 bytes contain the 6-byte Target MAC Address, right padded with zeros.
            //
            byte[] target = buffer.ReadBytes(8);
            Target = new MacAddress(target);

            // The next 6 bytes are unused and marked "Reserved".
            //
            byte[] oblivion = buffer.ReadBytes(6);

            // The next byte contains bitflags about the message where byte:
            //  [0]: res_required
            //  [1]: ack_required
            //
            byte flags = buffer.LittleEndianReadByte();
            ResponseRequired = (flags & (1 << 0)) != 0;
            AckRequired = (flags & (1 << 1)) != 0;

            // The last byte is the Message's sequence number.
            //
            SequenceNumber = buffer.LittleEndianReadByte();
        }

        /// <summary>
        /// Reads the Protocol Header portion of the message header.
        /// See http://lan.developer.lifx.com/docs/header-description for more details.
        /// </summary>
        /// <param name="buffer">The buffer to read from.</param>
        private void ReadProtocolHeader(MemoryStream buffer)
        {
            Debug.Assert(buffer != null);

            // The first 8 bytes are unused and marked "Reserved".
            //
            byte[] oblivion = buffer.ReadBytes(8);

            // The next 2 bytes are the MessageType. Verify that the type in the buffer
            // matches this type. This is the expected case, since a mismatch here would
            // indicate a bug in the library (possibly in the ResponseFactory.)
            //
            UInt16 messageTypeRead = buffer.LittleEndianReadUInt16();

            if (messageTypeRead != (UInt16)MessageType)
            {
                throw new LifXNetException(
                    "Type of the message being deserialized does not match what was expected. This is likely a bug in the library!");
            }

            // The last 2 bytes are also unused and marked "Reserved".
            //
            oblivion = buffer.ReadBytes(2);
        }
    }
}
