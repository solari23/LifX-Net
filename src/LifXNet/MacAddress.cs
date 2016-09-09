using System;

namespace LifXNet
{
    /// <summary>
    /// Utility struct representing a Media Access Control (MAC) Address.
    /// </summary>
    public struct MacAddress
    {
        /// <summary>
        /// The number of bytes in a MAC Address.
        /// </summary>
        public const int BytesInMacAddress = 6;

        /// <summary>
        /// Gets an Empty MAC Address.
        /// </summary>
        public static MacAddress Empty
        {
            get
            {
                return new MacAddress(new byte[]{ 0, 0, 0, 0, 0, 0 });
            }
        }

        private byte[] _bytes;

        /// <summary>
        /// Gets the Address' underlying bytes.
        /// </summary>
        public byte[] Bytes
        {
            get
            {
                if (_bytes == null)
                {
                    _bytes = new byte[] { 0, 0, 0, 0, 0, 0 };
                }

                return _bytes;
            }
        }

        /// <summary>
        /// Constructs a new MAC Address using the first 6 bytes from the given byte array.
        /// </summary>
        /// <param name="bytes">The byte array to construct the MAC Address from.</param>
        public MacAddress(byte[] bytes)
        {
            if (bytes == null || bytes.Length < BytesInMacAddress)
            {
                throw new ArgumentException("Need at least 6 bytes to construct a MAC address!", nameof(bytes));
            }

            _bytes = new byte[BytesInMacAddress];
            Array.Copy(bytes, _bytes, BytesInMacAddress);
        }

        /// <summary>
        /// Gets a string representation of the MAC Address in standard hex format.
        /// </summary>
        /// <returns>A string representation of the MAC Address</returns>
        public override string ToString()
        {
            return Bytes == null || Bytes.Length < BytesInMacAddress
                ? string.Empty 
                : string.Format(
                    "{0:X2}-{1:X2}-{2:X2}-{3:X2}-{4:X2}-{5:X2}",
                    Bytes[0],
                    Bytes[1],
                    Bytes[2],
                    Bytes[3],
                    Bytes[4],
                    Bytes[5]);
        }

        #region Comparison Operators

        public override bool Equals(Object obj)
        {
            return obj is MacAddress && this == (MacAddress)obj;
        }

        public override int GetHashCode()
        {
            return Bytes.GetHashCode();
        }

        public static bool operator ==(MacAddress left, MacAddress right)
        {
            if (left.Bytes.Length != right.Bytes.Length)
            {
                return false;
            }

            for (int i = 0; i < left.Bytes.Length; i++)
            {
                if (left.Bytes[i] != right.Bytes[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(MacAddress left, MacAddress right)
        {
            return !(left == right);
        }

        #endregion
    }
}
