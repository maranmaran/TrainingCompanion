using Backend.API.FunctionalTests.Common;
using Backend.API.FunctionalTests.Common.ClientAPI;
using System.Net;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Authorization.Commands.SignIn;
using Xunit;

namespace Backend.API.FunctionalTests.ControllerTests.AuthorizationTests
{
    public class SignInTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly AuthorizationClient _client;

        public SignInTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = new AuthorizationClient(factory);
        }


        [Fact]
        public async Task SignIn_Successful()
        {
            var signInCommand = new SignInRequest()
            {
                Username = "adamcogan",
                Password = "12345",
                RememberMe = false
            };

            var response = await _client.SignIn(signInCommand);

            response.EnsureSuccessStatusCode();
            var vm = await Utilities.GetResponseContent<SignInRequestResponse>(response);

            Assert.IsAssignableFrom<SignInRequestResponse>(vm);
            Assert.NotNull(vm);
        }


        [Fact]
        public async Task SignIn_Fails()
        {
            // password validation is wrong
            var signInCommand = new SignInRequest()
            {
                Username = "maran",
                Password = "1235",
                RememberMe = false
            };

            var response = await _client.SignIn(signInCommand);
            response.AssertFailsWithStatusCode(HttpStatusCode.BadRequest);

        }
    }
}
