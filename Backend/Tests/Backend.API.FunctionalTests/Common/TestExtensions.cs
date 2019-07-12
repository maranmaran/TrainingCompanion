using System.Net;
using System.Net.Http;
using Xunit;

namespace Backend.API.FunctionalTests.Common
{
    public static class TestExtensions
    {
        public static void AssertFailsWithStatusCode(this HttpResponseMessage response, HttpStatusCode code)
        {
            Assert.Equal(code, response.StatusCode);
        }
    }
}
