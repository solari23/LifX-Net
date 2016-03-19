using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LifXNet.Messages
{
    internal static class ResponseFactory
    {
        private static readonly ReadOnlyDictionary<MessageType, Func<Response>> ResponseConstructorMap =
            new ReadOnlyDictionary<MessageType, Func<Response>>(
                new Dictionary<MessageType, Func<Response>>
                {
                    { MessageType.StateService, () => new StateServiceResponse() },
                });

        public static Response ConstructResponseFromBuffer(byte[] buffer)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
