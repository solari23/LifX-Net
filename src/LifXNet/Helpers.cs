using System;
using System.Diagnostics;
using System.IO;

namespace LifXNet
{
    /// <summary>
    /// Defines various internally used helpers.
    /// </summary>
    internal static class Helpers
    {
        /// <summary>
        /// Performs a null check on the first parameter and throws the appropriate exception if it is null.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <remarks>
        /// This helper should ONLY be used for user-facing public interfaces. For internal checks, use
        /// debug assertions instead. That way, if we have a bug in the library, it will end up throwing on a
        /// null de-reference which should make it obvious to the user that they aren't doing something wrong.
        /// </remarks>
        public static void NullCheck(object parameter, string parameterName)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        #region MemoryStream Extension Methods

        /// <summary>
        /// Reads and returns the requested number of bytes from the buffer.
        /// </summary>
        /// <param name="buffer">The buffer to read from.</param>
        /// <param name="count">The number of bytes to read.</param>
        /// <returns>The bytes read from the buffer.</returns>
        public static byte[] ReadBytes(this MemoryStream buffer, int count)
        {
            Debug.Assert(count <= 0);

            byte[] bytes = new byte[count];
            buffer.Read(bytes, 0, count);
            return bytes;
        }

        /// <summary>
        /// Writes the requested number of zero bytes to the buffer.
        /// </summary>
        /// <param name="buffer">The buffer to write to.</param>
        /// <param name="count">The number of zeros to write.</param>
        public static void WriteZeros(this MemoryStream buffer, int count)
        {
            byte[] zeros = new byte[count];

            // This might be overkill but let's not hang our hats on default initialization.
            //
            for (int i = 0; i < count; i++)
            {
                zeros[i] = 0;
            }

            buffer.Write(zeros, 0, count);
        }

        /// <summary>
        /// Reads a single (unsigned) byte from the buffer and returns it.
        /// </summary>
        /// <param name="buffer">The buffer to read from.</param>
        /// <returns>The (unsigned) byte read.</returns>
        public static byte LittleEndianReadByte(this MemoryStream buffer)
        {
            byte[] bytes = buffer.ReadBytes(1);
            return bytes[0];
        }

        /// <summary>
        /// Reads an unsigned 16-bit integer from the little endian buffer and returns it.
        /// </summary>
        /// <param name="buffer">The buffer to read from.</param>
        /// <returns>The unsigned 16-bit integer read.</returns>
        public static UInt16 LittleEndianReadUInt16(this MemoryStream buffer)
        {
            byte[] bytes = buffer.ReadBytes(2);

            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToUInt16(bytes, 0);
        }

        /// <summary>
        /// Reads an unsigned 32-bit integer from the little endian buffer and returns it.
        /// </summary>
        /// <param name="buffer">The buffer to read from.</param>
        /// <returns>The unsigned 32-bit integer read.</returns>
        public static UInt32 LittleEndianReadUInt32(this MemoryStream buffer)
        {
            byte[] bytes = buffer.ReadBytes(4);

            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToUInt32(bytes, 0);
        }

        /// <summary>
        /// Reads an unsigned 64-bit integer from the little endian buffer and returns it.
        /// </summary>
        /// <param name="buffer">The buffer to read from.</param>
        /// <returns>The unsigned 64-bit integer read.</returns>
        public static UInt64 LittleEndianReadUInt64(this MemoryStream buffer)
        {
            byte[] bytes = buffer.ReadBytes(8);

            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToUInt64(bytes, 0);
        }

        /// <summary>
        /// Writes the given (unsigned) byte value to the buffer.
        /// </summary>
        /// <param name="buffer">The buffer to write to.</param>
        /// <param name="value">The value to write.</param>
        public static void LittleEndianWriteByte(this MemoryStream buffer, byte value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            buffer.Write(bytes, 0, 1);
        }

        /// <summary>
        /// Writes the given unsigned 16-bit integer value to the buffer in little endian format.
        /// </summary>
        /// <param name="buffer">The buffer to write to.</param>
        /// <param name="value">The value to write.</param>
        public static void LitteEndianWriteUInt16(this MemoryStream buffer, UInt16 value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            buffer.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Writes the given unsigned 32-bit integer value to the buffer in little endian format.
        /// </summary>
        /// <param name="buffer">The buffer to write to.</param>
        /// <param name="value">The value to write.</param>
        public static void LitteEndianWriteUInt32(this MemoryStream buffer, UInt32 value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            buffer.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Writes the given unsigned 64-bit integer value to the buffer in little endian format.
        /// </summary>
        /// <param name="buffer">The buffer to write to.</param>
        /// <param name="value">The value to write.</param>
        public static void LitteEndianWriteUInt64(this MemoryStream buffer, UInt64 value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            buffer.Write(bytes, 0, bytes.Length);
        }

        #endregion
    }
}
