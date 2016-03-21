using System;

using LifXNet;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DeviceManager deviceManager = new DeviceManager(UdpSocketWrapper.Generator);
            Console.WriteLine("Hello World!");
        }
    }
}
