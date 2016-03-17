using System;

using LifXNet;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DeviceManager deviceManager = new DeviceManager(() => new UdpSocketWrapper());
            Console.WriteLine("Hello World!");
        }
    }
}
