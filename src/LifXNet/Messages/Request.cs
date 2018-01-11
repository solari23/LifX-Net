using System;
using System.Diagnostics;
using System.IO;

namespace LifXNet.Messages
{
    /// <summary>
    /// Abstract representation of a Message that will be sent from the client to a device.
    /// </summary>
    public abstract class Request : Message
    {
        public virtual void SerializeTo(MemoryStream buffer)
        {
            Debug.Assert(buffer != null);

            WriteFrame(buffer);
            WriteFrameAddress(buffer);
            WriteProtocolHeader(buffer);
            SerializePayloadTo(buffer);
        }

        protected abstract void SerializePayloadTo(MemoryStream buffer);

        /// <summary>
        /// Writes the Frame portion of the message header to the buffer.
        /// See http://lan.developer.lifx.com/docs/header-description for more details.
        /// </summary>
        /// <param name="buffer">The buffer to write to.</param>
        private void WriteFrame(MemoryStream buffer)
        {
            Debug.Assert(buffer != null);

            // Write the message size (2B)
            //
            buffer.LitteEndianWriteUInt16(MessageSizeInBytes);

            // The next 2 bytes contain:
            //   - The Origin field (2 bits, always set to 0)
            //   - The Tagged flag (1 bit - 1 if Target is specific device, 0 if all devices)
            //   - The Addressable flag (1 bit, always set to 1)
            //   - The protocol number (12 bits, always set to 1024)
            //
            const UInt16 TaggedFlag = 0x2000;
            const UInt16 AddressableFlag = 0x1000;

            UInt16 flagsAndProtocol = AddressableFlag | Constants.LifXProtocolNumber;

            if (Target == MacAddress.Empty)
            {
                flagsAndProtocol |= TaggedFlag;
            }

            buffer.LitteEndianWriteUInt16(flagsAndProtocol);

            // The last 4 bytes are the message Source.
            //
            buffer.LitteEndianWriteUInt32(Source);
        }

        /// <summary>
        /// Writes the Frame Address portion of the message header to the buffer.
        /// See http://lan.developer.lifx.com/docs/header-description for more details.
        /// </summary>
        /// <param name="buffer">The buffer to write to.</param>
        private void WriteFrameAddress(MemoryStream buffer)
        {
            Debug.Assert(buffer != null);

            // The first 8 bytes contain the 6-byte Target MAC Address, right padded with 2 zeros.
            //
            byte[] targetAddress = Target.Bytes;
            Debug.Assert(targetAddress.Length == 6);
            buffer.Write(targetAddress, 0, 6);
            buffer.WriteZeros(2);

            // The next 6 bytes are unusued and marked "Reserved".
            //
            buffer.WriteZeros(6);

            // The next byte contains bitflags about the message where byte:
            //  [0]: res_required
            //  [1]: ack_required
            //
            byte flags = 0;

            if (ResponseRequired)
            {
                flags |= (1 << 0);
            }

            if (AckRequired)
            {
                flags |= (1 << 1);
            }

            buffer.LittleEndianWriteByte(flags);

            // The last byte is the Message's sequence number.
            //
            buffer.LittleEndianWriteByte(SequenceNumber);
        }

        /// <summary>
        /// Writes the Protocol Header portion of the message header to the buffer.
        /// See http://lan.developer.lifx.com/docs/header-description for more details.
        /// </summary>
        /// <param name="buffer">The buffer to write to.</param>
        private void WriteProtocolHeader(MemoryStream buffer)
        {
            Debug.Assert(buffer != null);

            // The first 8 bytes are unusued and marked "Reserved".
            //
            buffer.WriteZeros(8);

            // The next 2 bytes are the MessageType.
            //
            buffer.LitteEndianWriteUInt16((UInt16)MessageType);

            // The last 2 bytes are also unusued and marked "Reserved".
            //
            buffer.WriteZeros(2);
        }
    }
}
