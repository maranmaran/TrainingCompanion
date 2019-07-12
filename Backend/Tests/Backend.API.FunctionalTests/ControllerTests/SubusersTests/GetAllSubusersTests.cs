using Backend.API.FunctionalTests.Common;
using Backend.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.API.FunctionalTests.Common.ClientAPI;
using Xunit;

namespace Backend.API.FunctionalTests.ControllerTests.SubusersTests
{
    public class GetAllSubusersTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly SubuserClient _client;

        public GetAllSubusersTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = new SubuserClient(factory);
        }

        [Fact]
        public async Task ReturnsAllSubusers()
        {
            var response = await _client.GetAllSubusers();

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<List<ApplicationUser>>(response);

            Assert.IsAssignableFrom<List<ApplicationUser>>(vm);
            Assert.NotEmpty(vm);
        }
    }
}
