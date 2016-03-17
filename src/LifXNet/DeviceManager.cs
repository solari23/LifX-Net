using System;

namespace LifXNet
{
    /// <summary>
    /// Provides an interface to discover and interact with LifX devices.
    /// </summary>
    public class DeviceManager
    {
        /// <summary>
        /// A reference to the NetworkManager that handles network communications devices managed by this object.
        /// </summary>
        private NetworkManager NetworkManager { get; set; }

        /// <summary>
        /// DeviceManager class constructor.
        /// </summary>
        /// <param name="socketGenerator">A function which creates a new instance of an IUdpSocket.</param>
        public DeviceManager(Func<IUdpSocket> socketGenerator)
        {
            Helpers.NullCheck(socketGenerator, nameof(socketGenerator));

            NetworkManager = new NetworkManager(socketGenerator);
        }
    }
}
