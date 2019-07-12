using Backend.API.FunctionalTests.Common;
using Backend.API.FunctionalTests.Common.ClientAPI;
using Backend.Domain.Entities;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Backend.API.FunctionalTests.ControllerTests.SubusersTests
{
    public class DeleteSubuserTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly SubuserClient _subuserClient;
        private readonly UserClient _userClient;

        public DeleteSubuserTests(CustomWebApplicationFactory<Startup> factory)
        {
            _subuserClient = new SubuserClient(factory);
            _userClient = new UserClient(factory);
        }

        [Fact]
        public async Task Delete_Successful()
        {
            var parentId = Guid.Parse("62FA647E-AD54-4BCC-A860-E5A2664B019D");
            var subuserId = Guid.Parse("62FA647C-AD54-4BCC-A860-E5A2664B039D");

            var response = await _subuserClient.DeleteSubuser(subuserId);
            response.EnsureSuccessStatusCode();

            var tryGetDeleteSubsubuser = await _userClient.GetUser(subuserId);
            tryGetDeleteSubsubuser.AssertFailsWithStatusCode(HttpStatusCode.NotFound);

            var parentResponse = await _userClient.GetUser(parentId);
            parentResponse.EnsureSuccessStatusCode();

            var parent = await Utilities.GetResponseContent<ApplicationUser>(parentResponse);
            Assert.True(parent.Subusers.All(x => x.Id != subuserId));
        }


        [Fact]
        public async Task Delete_Fails_NotFound()
        {
            var id = Guid.Parse("62FA647C-AD54-4BCC-A860-E5A2664BAAAA");
            var response = await _subuserClient.DeleteSubuser(id);
            response.AssertFailsWithStatusCode(HttpStatusCode.NotFound);
        }
    }
}
