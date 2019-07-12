using Backend.API.FunctionalTests.Common;
using Backend.Domain.Entities;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.API.FunctionalTests.Common.ClientAPI;
using Xunit;

namespace Backend.API.FunctionalTests.ControllerTests.UserTests
{
    public class GetAllUsersTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly UserClient _client;

        public GetAllUsersTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = new UserClient(factory);
        }


        [Fact]
        public async Task ReturnsAllUsers()
        {
            var response = await _client.GetAllUsers();
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<List<ApplicationUser>>(response);

            Assert.IsAssignableFrom<List<ApplicationUser>>(vm);
            Assert.NotEmpty(vm);
            vm.Count.ShouldBe(9);
        }
    }
}
