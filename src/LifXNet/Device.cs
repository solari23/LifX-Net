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

        internal Device(NetworkManager networkManager)
        {
            Debug.Assert(networkManager != null);

            NetworkManager = networkManager;
        }
    }
}
