using Backend.API.LibraryConfigurations.Sieve.Mappings;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace Backend.API.LibraryConfigurations.Sieve
{
    public class ApplicationSieveProcessor : SieveProcessor
    {
        public ApplicationSieveProcessor(
            IOptions<SieveOptions> options)
            : base(options)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.MapApplicationUser();

            return mapper;
        }
    }
}
