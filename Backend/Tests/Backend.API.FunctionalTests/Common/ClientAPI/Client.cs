using System.Net.Http;

namespace Backend.API.FunctionalTests.Common.ClientAPI
{
    public abstract class Client
    {
        public readonly HttpClient _client;

        protected Client(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }
    }
}
