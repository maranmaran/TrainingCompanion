using Backend.API.FunctionalTests.Common;
using Backend.API.FunctionalTests.Common.ClientAPI;
using Backend.Domain.Entities;
using Shouldly;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Backend.API.FunctionalTests.ControllerTests.UserTests
{
    public class GetUserTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly UserClient _client;

        public GetUserTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = new UserClient(factory);
        }

        [Fact]
        public async Task ReturnsUser()
        {
            var id = Guid.Parse("62FA647C-AD54-4BCC-A860-E5A2664B019D");
            var response = await _client.GetUser(id);

            response.EnsureSuccessStatusCode();
            var vm = await Utilities.GetResponseContent<ApplicationUser>(response);

            Assert.IsAssignableFrom<ApplicationUser>(vm);
            Assert.NotNull(vm);
            vm.Id.ShouldBeOfType(typeof(Guid));
            vm.Id.ShouldBe(id);
        }


        [Fact]
        public async Task Fails_NotFound()
        {
            var id = Guid.Parse("23FA647C-AD54-4BCC-A860-E5A2664B019D");
            var response = await _client.GetUser(id);

            response.AssertFailsWithStatusCode(HttpStatusCode.NotFound);
        }
    }
}
