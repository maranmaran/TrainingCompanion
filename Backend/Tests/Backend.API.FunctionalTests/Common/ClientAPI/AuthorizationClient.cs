using System.Net.Http;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Authorization.Commands.SignIn;

namespace Backend.API.FunctionalTests.Common.ClientAPI
{
    public class AuthorizationClient : Client
    {
        public AuthorizationClient(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }
        public async Task<HttpResponseMessage> SignIn(SignInCommand command)
        {
            var content = Utilities.GetRequestContent(command);
            return await _client.PostAsync($"api/authorization/signin", content);
        }
    }
}
