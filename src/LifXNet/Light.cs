namespace LifXNet
{
    /// <summary>
    /// Represents a LifX light.
    /// </summary>
    public sealed class Light : Device
    {
        internal Light(NetworkManager networkManager)
            : base(networkManager)
        {
            Helpers.NullCheck(networkManager, nameof(networkManager));
        }
    }
}
