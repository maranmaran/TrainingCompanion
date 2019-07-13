using Backend.API.FunctionalTests.Common;
using Backend.API.FunctionalTests.Common.ClientAPI;
using Backend.Application.Business.Business.Subusers.CreateSubuser;
using Shouldly;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Backend.API.FunctionalTests.ControllerTests.SubusersTests
{
    public class CreateSubuserTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly SubuserClient _client;

        public CreateSubuserTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = new SubuserClient(factory);
        }

        [Fact]
        public async Task Create_Successful()
        {
            var createSubuserCommand = new CreateSubuserRequest()
            {
                FirstName = "Marko",
                LastName = "Urh",
                Email = "urh.marko@gmail.com",
                Username = "maran",
                ParentId = new Guid("62FA647E-AD54-4BCC-A860-E5A2664B019D"),
            };

            var response = await _client.CreateSubuser(createSubuserCommand);

            response.EnsureSuccessStatusCode();
            var vm = await Utilities.GetResponseContent<CreateSubuserRequestResponse>(response);

            Assert.IsAssignableFrom<CreateSubuserRequestResponse>(vm);
            Assert.NotNull(vm);
            vm.FirstName.ShouldBe(createSubuserCommand.FirstName);
            vm.LastName.ShouldBe(createSubuserCommand.LastName);
            vm.Email.ShouldBe(createSubuserCommand.Email);
            vm.Username.ShouldBe(createSubuserCommand.Username);
            vm.ParentId.ShouldBe(createSubuserCommand.ParentId);
            vm.Id.ShouldNotBe(Guid.Empty);
        }


        [Fact]
        public async Task Create_Fails()
        {
            // email validation is wrong
            var createSubuserCommand = new CreateSubuserRequest()
            {
                FirstName = "Marko",
                LastName = "Urh",
                Email = "urh.markogmail.com",
                Username = "maran"
            };

            var response = await _client.CreateSubuser(createSubuserCommand);
            response.AssertFailsWithStatusCode(HttpStatusCode.BadRequest);
        }
    }
}
