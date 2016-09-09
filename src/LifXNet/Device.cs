using System.Diagnostics;

namespace LifXNet
{
    /// <summary>
    /// Abstract class representing a LifX Device. Note that LifX currently only produces lights.
    /// </summary>
    public abstract class Device
    {
        /// <summary>
        /// Gets a reference to the NetworkManager that handles network communications for this device.
        /// </summary>
        internal NetworkManager NetworkManager { get; private set; }

        /// <summary>
        /// Constructs a new Device. Note that construction of devices is library-internal. The library
        /// user is expected to use the DeviceManager to interact with devices.
        /// </summary>
        /// <param name="networkManager">The NetworkManager that provides an interface to network communications.</param>
        internal Device(NetworkManager networkManager)
        {
            Debug.Assert(networkManager != null);

            NetworkManager = networkManager;
        }
    }
}
