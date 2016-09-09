using System.Diagnostics;

namespace LifXNet
{
    /// <summary>
    /// Represents a LifX light.
    /// </summary>
    public sealed class Light : Device
    {
        /// <summary>
        /// Constructs a Light. Note that construction of devices is library-internal. The library
        /// user is expected to use the DeviceManager to interact with devices.
        /// </summary>
        /// <param name="networkManager">The NetworkManager that provides an interface to network communications.</param>
        internal Light(NetworkManager networkManager)
            : base(networkManager)
        {
            Debug.Assert(networkManager != null);
        }
    }
}
