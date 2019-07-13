using System;
using System.Net.Http;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Authorization.ChangePassword;
using Backend.Application.Business.Business.Users.CreateUser;
using Backend.Application.Business.Business.Users.UpdateUser;

namespace Backend.API.FunctionalTests.Common.ClientAPI
{
    public class UserClient : Client
    {
        public UserClient(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        public async Task<HttpResponseMessage> CreateUser(CreateUserRequest request)
        {
            var content = Utilities.GetRequestContent(request);
            return await _client.PostAsync($"api/users/create", content);
        }

        public async Task<HttpResponseMessage> GetAllUsers()
        {
            return await _client.GetAsync("/api/users/getall");
        }

        public async Task<HttpResponseMessage> GetUser(Guid id)
        {
            return await _client.GetAsync($"/api/users/get/{id}");
        }

        public async Task<HttpResponseMessage> UpdateUser(UpdateUserRequest request)
        {
            var content = Utilities.GetRequestContent(request);
            return await _client.PostAsync($"api/users/update", content);
        }

        public async Task<HttpResponseMessage> DeleteUser(Guid id)
        {
            return await _client.GetAsync($"/api/users/delete/{id}");
        }

        public async Task<HttpResponseMessage> ChangePassword(ChangePasswordRequest request)
        {
            var content = Utilities.GetRequestContent(request);
            return await _client.PostAsync($"api/users/changepassword", content);
        }
    }
}
