using System;
using System.Net.Http;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Subusers.CreateSubuser;

namespace Backend.API.FunctionalTests.Common.ClientAPI
{
    public class SubuserClient : Client
    {
        public SubuserClient(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        public async Task<HttpResponseMessage> CreateSubuser(CreateSubuserRequest request)
        {
            var content = Utilities.GetRequestContent(request);
            return await _client.PostAsync($"api/subusers/create", content);
        }

        public async Task<HttpResponseMessage> GetAllSubusers()
        {
            return await _client.GetAsync("/api/subusers/getall");
        }


        public async Task<HttpResponseMessage> DeleteSubuser(Guid id)
        {
            return await _client.GetAsync($"/api/subusers/delete/{id}");
        }


    }
}
