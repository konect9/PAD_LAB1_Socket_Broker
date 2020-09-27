using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Broker
{
    public class PayloadHandler
    {
        public static void Handle(byte[] payloadBytes, ConnectionInfo connectionInfo)
        {
            var payloadString = Encoding.UTF8.GetString(payloadBytes);

            if (payloadString.StartsWith("subscribe#"))
            {
                connectionInfo.Topic = payloadString.Split("subscribe#").LastOrDefault();
                ConnectionsStorage.Add(connectionInfo);
                
            }
            else
            {
                Payload payload = JsonConvert.DeserializeObject<Payload>(payloadString);
                //add to storage
                PayloadStorage.Add(payload);
            }
            
        }
    }
}
