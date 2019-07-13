using Backend.API.FunctionalTests.Common;
using Backend.API.FunctionalTests.Common.ClientAPI;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using System;
using System.Net;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Users.UpdateUser;
using Xunit;

namespace Backend.API.FunctionalTests.ControllerTests.UserTests
{
    public class UpdateUserTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly UserClient _client;

        public UpdateUserTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = new UserClient(factory);
        }

        [Fact]
        public async Task Update_Successful()
        {
            // arrange
            var updateUserCommand = new UpdateUserRequest()
            {
                Id = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D"),
                FirstName = "Marko",
                LastName = "Urh",
                Email = "urh.marko@gmail.com",
                Username = "maran",
                AccountStatus = AccountStatus.Active,
            };

            // act
            var response = await _client.UpdateUser(updateUserCommand);

            // assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

            // fetch user and assert again
            var updatedUserResponse = await _client.GetUser(updateUserCommand.Id);
            var updatedUserResponseModel = await Utilities.GetResponseContent<ApplicationUser>(updatedUserResponse);
            Assert.Equal(updatedUserResponseModel.FirstName, updateUserCommand.FirstName);
            Assert.Equal(updatedUserResponseModel.AccountStatus, updateUserCommand.AccountStatus);
        }


        [Fact]
        public async Task Update_Fails()
        {
            // email validation is wrong
            var updateUserCommand = new UpdateUserRequest()
            {
                Id = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D"),
                FirstName = "Marko",
                LastName = "Urh",
                Email = "urh.markogmail.com",
                Username = "maran"
            };

            var response = await _client.UpdateUser(updateUserCommand);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
