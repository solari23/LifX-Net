using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace LifXNet.Messages
{
    internal static class ResponseFactory
    {
        private static readonly ReadOnlyDictionary<MessageType, Func<Response>> ResponseConstructorMap =
            new ReadOnlyDictionary<MessageType, Func<Response>>(
                new Dictionary<MessageType, Func<Response>>
                {
                    { MessageType.StateService, () => new StateServiceResponse() },
                });

        public static Response ConstructResponseFromBuffer(byte[] buffer)
        {
            Debug.Assert(buffer != null);

            Response response = null;
            MessageType messageType = GetMessageTypeFromBuffer(buffer);

            Func<Response> responseConstructor;
            if (ResponseConstructorMap.TryGetValue(messageType, out responseConstructor))
            {
                response = responseConstructor();
                response.DeserializeFrom(new MemoryStream(buffer));
            }

            return response;
        }

        private static MessageType GetMessageTypeFromBuffer(byte[] buffer)
        {
            const int MessageTypeFieldOffsetInBytes = 32;
            const int MessageTypeSizeInBytes = 2;

            Debug.Assert(buffer != null);

            MessageType messageType = MessageType.NotSet;

            if (buffer.Length - MessageTypeSizeInBytes >= MessageTypeFieldOffsetInBytes)
            {
                byte[] messageTypeBytes = new byte[MessageTypeSizeInBytes];
                Array.Copy(buffer, MessageTypeFieldOffsetInBytes, messageTypeBytes, 0, MessageTypeSizeInBytes);

                // LifX messages are little endian, so we may need to flip the buffer to match the local
                // BitConverter's endianness.
                //
                if (!BitConverter.IsLittleEndian)
                {
                    Array.Reverse(messageTypeBytes);
                }

                UInt16 messageTypeValue = BitConverter.ToUInt16(messageTypeBytes, 0);

                if (Enum.IsDefined(typeof(MessageType), messageTypeValue))
                {
                    messageType = (MessageType)messageTypeValue;
                }
            }

            return messageType;
        }
    }
}
