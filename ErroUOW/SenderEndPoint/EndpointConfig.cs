namespace ErrorUOW.SenderEndPoint
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public EndpointConfig()
        {
            Configure.Serialization.Json();
        }
    }
}