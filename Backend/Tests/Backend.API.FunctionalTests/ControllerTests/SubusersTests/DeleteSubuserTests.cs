using System;
using System.Net;
using System.Threading.Tasks;
using Backend.API.FunctionalTests.Common;
using Backend.API.FunctionalTests.Common.ClientAPI;
using Backend.Domain.Entities;
using Xunit;

namespace Backend.API.FunctionalTests.ControllerTests.SubusersTests
{
    public class DeleteAthleteTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly AthleteClient _athleteClient;
        private readonly UserClient _userClient;

        public DeleteAthleteTests(CustomWebApplicationFactory<Startup> factory)
        {
            _athleteClient = new AthleteClient(factory);
            _userClient = new UserClient(factory);
        }

        [Fact]
        public async Task Delete_Successful()
        {
            var parentId = Guid.Parse("62FA647E-AD54-4BCC-A860-E5A2664B019D");
            var athleteId = Guid.Parse("62FA647C-AD54-4BCC-A860-E5A2664B039D");

            var response = await _athleteClient.DeleteAthlete(athleteId);
            response.EnsureSuccessStatusCode();

            var tryGetDeleteSubathlete = await _userClient.GetUser(athleteId);
            tryGetDeleteSubathlete.AssertFailsWithStatusCode(HttpStatusCode.NotFound);

            var parentResponse = await _userClient.GetUser(parentId);
            parentResponse.EnsureSuccessStatusCode();

            var parent = await Utilities.GetResponseContent<ApplicationUser>(parentResponse);
            //Assert.True(parent.Athletes.All(x => x.Id != athleteId));
        }


        [Fact]
        public async Task Delete_Fails_NotFound()
        {
            var id = Guid.Parse("62FA647C-AD54-4BCC-A860-E5A2664BAAAA");
            var response = await _athleteClient.DeleteAthlete(id);
            response.AssertFailsWithStatusCode(HttpStatusCode.NotFound);
        }
    }
}
