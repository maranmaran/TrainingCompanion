using System;
using System.Net;
using System.Threading.Tasks;
using Backend.API.FunctionalTests.Common;
using Backend.API.FunctionalTests.Common.ClientAPI;
using Backend.Application.Business.Business.Athletes.CreateAthlete;
using Shouldly;
using Xunit;

namespace Backend.API.FunctionalTests.ControllerTests.SubusersTests
{
    public class CreateAthleteTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly AthleteClient _client;

        public CreateAthleteTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = new AthleteClient(factory);
        }

        [Fact]
        public async Task Create_Successful()
        {
            var createAthleteCommand = new CreateAthleteRequest()
            {
                FirstName = "Marko",
                LastName = "Urh",
                Email = "urh.marko@gmail.com",
                Username = "maran",
                ParentId = new Guid("62FA647E-AD54-4BCC-A860-E5A2664B019D"),
            };

            var response = await _client.CreateAthlete(createAthleteCommand);

            response.EnsureSuccessStatusCode();
            var vm = await Utilities.GetResponseContent<CreateAthleteRequestResponse>(response);

            Assert.IsAssignableFrom<CreateAthleteRequestResponse>(vm);
            Assert.NotNull(vm);
            vm.FirstName.ShouldBe(createAthleteCommand.FirstName);
            vm.LastName.ShouldBe(createAthleteCommand.LastName);
            vm.Email.ShouldBe(createAthleteCommand.Email);
            vm.Username.ShouldBe(createAthleteCommand.Username);
            vm.ParentId.ShouldBe(createAthleteCommand.ParentId);
            vm.Id.ShouldNotBe(Guid.Empty);
        }


        [Fact]
        public async Task Create_Fails()
        {
            // email validation is wrong
            var createAthleteCommand = new CreateAthleteRequest()
            {
                FirstName = "Marko",
                LastName = "Urh",
                Email = "urh.markogmail.com",
                Username = "maran"
            };

            var response = await _client.CreateAthlete(createAthleteCommand);
            response.AssertFailsWithStatusCode(HttpStatusCode.BadRequest);
        }
    }
}
