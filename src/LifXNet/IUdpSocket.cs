using System.Net;

namespace LifXNet
{
    /// <summary>
    /// Defines a common interface for UDP Sockets. The user of this library must define and provide
    /// a suitable implementation of this interface to the library.
    /// 
    /// The implementation's behaviour must match that of the System.Net.Sockets.Socket, including
    /// with regards to throwing errors in the form of System.Net.Sockets.SocketException with SocketError
    /// set appropriately.
    /// 
    /// See https://msdn.microsoft.com/en-us/library/system.net.sockets.socket.aspx for more info.
    /// </summary>
    /// <remarks>
    /// The requirement for the library user to define their own IUdpSocket implementation exists
    /// because Portable Class Libraries (PCLs) do not have a unified socket API.
    /// </remarks>
    public interface IUdpSocket
    {
        int ReceiveTimeout { get; set; }

        void Bind(IPEndPoint endPoint);

        void SendTo(byte[] buffer, EndPoint remoteEndPoint);

        int ReceiveFrom(byte[] buffer, ref EndPoint remoteEndPoint);
    }
}
