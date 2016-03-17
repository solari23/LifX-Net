using System;

namespace LifXNet
{
    /// <summary>
    /// Handles all networking operations for communicating with LifX devices.
    /// </summary>
    internal class NetworkManager
    {
        /// <summary>
        /// Gets the user-provided function to generate UDP sockets.
        /// </summary>
        public Func<IUdpSocket> SocketGenerator { get; private set; }

        /// <summary>
        /// NetworkManager class constructor.
        /// </summary>
        /// <param name="socketGenerator">A function which creates a new instance of an IUdpSocket.</param>
        public NetworkManager(Func<IUdpSocket> socketGenerator)
        {
            Helpers.NullCheck(socketGenerator, nameof(socketGenerator));

            SocketGenerator = socketGenerator;
        }
    }
}
