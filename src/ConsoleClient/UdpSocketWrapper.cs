using System;
using System.Net;
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
        public static Func<IUdpSocket> Generator
        {
            get
            {
                return () => new UdpSocketWrapper();
            }
        }

        private Socket _socket;

        public UdpSocketWrapper()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }

        public int ReceiveTimeout
        {
            get
            {
                return _socket.ReceiveTimeout;
            }

            set
            {
                _socket.ReceiveTimeout = value;
            }
        }

        public void Bind(IPEndPoint endPoint)
        {
            _socket.Bind(endPoint);
        }

        public int ReceiveFrom(byte[] buffer, ref EndPoint remoteEndPoint)
        {
            return _socket.ReceiveFrom(buffer, ref remoteEndPoint);
        }

        public void SendTo(byte[] buffer, EndPoint remoteEndPoint)
        {
            _socket.SendTo(buffer, remoteEndPoint);
        }
    }
}
