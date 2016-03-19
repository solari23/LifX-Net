namespace LifXNet.Messages
{
    internal enum MessageType : System.UInt16
    {
        //
        // Device Messages
        //
        GetService = 2,
        StateService = 3,
        GetHostInfo = 12,
        StateHostinfo = 13,
        GetHostFirmware = 14,
        StateHostFirmware = 15,
        GetWifiInfo = 16,
        StateWifiInfo = 17,
        GetWifiFirmware = 18,
        StateWifiFirmware = 19,
        GetPower = 20,
        SetPower = 21,
        StatePower = 22,
        GetLabel = 23,
        SetLabel = 24,
        StateLabel = 25,
        GetVersion = 32,
        StateVersion = 33,
        GetInfo = 34,
        StateInfo = 35,
        Acknowledgement = 45,
        GetLocation = 48,
        StateLocation = 50,
        GetGroup = 51,
        StateGroup = 53,
        EchoRequest = 58,
        EchoResponse = 59,

        //
        // Light Messages
        //
        LightGet = 101,
        LightSetColor = 102,
        LightState = 107,
        LightGetPower = 116,
        LightSetPower = 117,
        LightStatePower = 118,
    }
}
