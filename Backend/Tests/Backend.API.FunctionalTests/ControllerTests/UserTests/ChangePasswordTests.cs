using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Users.Queries.Get;
using Backend.API.FunctionalTests.Common;
using Backend.API.FunctionalTests.Common.ClientAPI;
using Backend.Application.Business.Business.Authorization.Commands.ChangePassword;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Service.Authorization;
using Backend.Service.Authorization.Interfaces;
using Backend.Service.Authorization.Utils;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;
using Xunit;

namespace Backend.API.FunctionalTests.ControllerTests.UserTests
{
    public class ChangePasswordTests: IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly UserClient _client;
        private readonly IPasswordHasher _passwordHasher;

        public ChangePasswordTests(CustomWebApplicationFactory<Startup> factory)
        {
            _passwordHasher = new PasswordHasher();
            _client = new UserClient(factory);
        }

        [Fact]
        public async Task ChangePassword_Success()
        {
            var command = new ChangePasswordCommand()
            {
                Id = Guid.Parse("62FA647C-AD54-4BCC-A860-E5A2664B019D"),
                Password = "1234567",
                ConfirmPassword = "1234567"
            };
            var passwordHash = _passwordHasher.GetPasswordHash(command.Password);

            var response = await _client.ChangePassword(command);
            response.EnsureSuccessStatusCode();

            // check password
            var getUserResponse = await _client.GetUser(command.Id);
            var user = await Utilities.GetResponseContent<ApplicationUser>(getUserResponse);

            user.PasswordHash.ShouldBe(passwordHash);
            user.AccountStatus.ShouldBe(AccountStatus.Active);
        }

        [Fact]
        public async void ChangePassword_Fails()
        {
            // validation failure
            var command = new ChangePasswordCommand()
            {
                Id = Guid.Parse("62FA647C-AD54-4BCC-A860-E5A2664B019D"),
                Password = "12367",
                ConfirmPassword = "1234567"
            };

            var response = await _client.ChangePassword(command);
            response.AssertFailsWithStatusCode(HttpStatusCode.BadRequest);
        }
    }
}
