using Backend.API.FunctionalTests.Common;
using Backend.API.FunctionalTests.Common.ClientAPI;
using Shouldly;
using System;
using System.Net;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Users.CreateUser;
using Xunit;

namespace Backend.API.FunctionalTests.ControllerTests.UserTests
{
    public class CreateUserTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly UserClient _client;

        public CreateUserTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = new UserClient(factory);
        }

        [Fact]
        public async Task Create_Successful()
        {
            var createUserCommand = new CreateUserRequest()
            {
                FirstName = "Marko",
                LastName = "Urh",
                Password = "12345",
                ConfirmPassword = "12345",
                Email = "urh.marko@gmail.com",
                Username = "maran"
            };

            var response = await _client.CreateUser(createUserCommand);
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<CreateUserRequestResponse>(response);
            Assert.IsAssignableFrom<CreateUserRequestResponse>(vm);
            Assert.NotNull(vm);
            vm.FirstName.ShouldBe(createUserCommand.FirstName);
            vm.LastName.ShouldBe(createUserCommand.LastName);
            vm.Username.ShouldBe(createUserCommand.Username);
            vm.Email.ShouldBe(createUserCommand.Email);
            vm.CreatedOn.Date.ShouldBe(DateTime.UtcNow.Date);
        }


        [Fact]
        public async Task Create_Fails()
        {
            // password validation is wrong
            var createUserCommand = new CreateUserRequest()
            {
                FirstName = "Marko",
                LastName = "Urh",
                Password = "1235",
                ConfirmPassword = "1234",
                Email = "urh.marko@gmail.com",
                Username = "maran"
            };

            var response = await _client.CreateUser(createUserCommand);
            response.AssertFailsWithStatusCode(HttpStatusCode.BadRequest);
        }
    }
}
