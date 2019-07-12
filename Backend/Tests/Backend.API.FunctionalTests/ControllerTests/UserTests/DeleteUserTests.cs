using Backend.API.FunctionalTests.Common;
using System;
using System.Net;
using System.Threading.Tasks;
using Backend.API.FunctionalTests.Common.ClientAPI;
using Xunit;

namespace Backend.API.FunctionalTests.ControllerTests.UserTests
{
    public class DeleteUserTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly UserClient _client;

        public DeleteUserTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = new UserClient(factory);
        }

        [Fact]
        public async Task Delete_Successful()
        {
            var id = Guid.Parse("62FA647C-AD54-4BCC-A860-E5A2664B039D");
            var response = await _client.DeleteUser(id);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            var tryGetDeleteUser = await _client.GetUser(id);
            Assert.Equal(HttpStatusCode.NotFound, tryGetDeleteUser.StatusCode);
        }


        [Fact]
        public async Task Delete_Fails_NotFound()
        {
            var id = Guid.Parse("62FA647C-AD54-4BCC-A860-E5A2664BAAAA");
            var response = await _client.DeleteUser(id);

            response.AssertFailsWithStatusCode(HttpStatusCode.NotFound);
        }
    }
}
