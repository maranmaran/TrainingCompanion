using System;
using System.Net.Http;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Athletes.CreateAthlete;

namespace Backend.API.FunctionalTests.Common.ClientAPI
{
    public class AthleteClient : Client
    {
        public AthleteClient(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        public async Task<HttpResponseMessage> CreateAthlete(CreateAthleteRequest request)
        {
            var content = Utilities.GetRequestContent(request);
            return await _client.PostAsync($"api/athletes/create", content);
        }

        public async Task<HttpResponseMessage> GetAllAthletes()
        {
            return await _client.GetAsync("/api/athletes/getall");
        }


        public async Task<HttpResponseMessage> DeleteAthlete(Guid id)
        {
            return await _client.GetAsync($"/api/athletes/delete/{id}");
        }


    }
}
