using System.Net.Http;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Authorization.SignIn;

namespace Backend.API.FunctionalTests.Common.ClientAPI
{
    public class AuthorizationClient : Client
    {
        public AuthorizationClient(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }
        public async Task<HttpResponseMessage> SignIn(SignInRequest request)
        {
            var content = Utilities.GetRequestContent(request);
            return await _client.PostAsync($"api/authorization/signin", content);
        }
    }
}
