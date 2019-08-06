using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.API.FunctionalTests.Common;
using Backend.API.FunctionalTests.Common.ClientAPI;
using Backend.Domain.Entities;
using Xunit;

namespace Backend.API.FunctionalTests.ControllerTests.SubusersTests
{
    public class GetAllAthletesTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly AthleteClient _client;

        public GetAllAthletesTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = new AthleteClient(factory);
        }

        [Fact]
        public async Task ReturnsAllAthletes()
        {
            var response = await _client.GetAllAthletes();

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<List<ApplicationUser>>(response);

            Assert.IsAssignableFrom<List<ApplicationUser>>(vm);
            Assert.NotEmpty(vm);
        }
    }
}
