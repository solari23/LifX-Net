using System.Net.Sockets;

using LifXNet;

namespace ConsoleClient
{
    /// <summary>
    /// A wrapper around System.Net.Sockets Socket class providing the functionality necessary
    /// for network communication over UDP. These wrappers are required by the LifXNet library.
    /// </summary>
    public class UdpSocketWrapper : IUdpSocket
    {
        private Socket _socket;
    }
}
