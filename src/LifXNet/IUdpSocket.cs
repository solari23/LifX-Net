namespace LifXNet
{
    /// <summary>
    /// Defines a common interface for UDP Sockets. The user of this library must define and provide
    /// a suitable implementation of this interface to the library.
    /// </summary>
    /// <remarks>
    /// The requirement for the library user to define their own IUdpSocket implementation exists
    /// because Portable Class Libraries (PCLs) do not have a unified socket API. LifXNet is implemented
    /// as a PCL.
    /// </remarks>
    public interface IUdpSocket
    {
        // TODO: Define interface for IUdpSocket
    }
}
