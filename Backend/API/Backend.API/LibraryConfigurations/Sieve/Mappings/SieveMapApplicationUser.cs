using Backend.Domain.Entities;
using Backend.Domain.Entities.User;
using Sieve.Services;

namespace Backend.API.LibraryConfigurations.Sieve.Mappings
{
    public static class SieveMapApplicationUser
    {
        public static void MapApplicationUser(this SievePropertyMapper mapper)
        {
            mapper.Property<ApplicationUser>(p => p.FirstName)
                .CanFilter()
                .CanSort()
                .HasName("user_firstname");

            mapper.Property<ApplicationUser>(p => p.LastName)
                .CanFilter()
                .CanSort()
                .HasName("user_lastname");

            mapper.Property<ApplicationUser>(p => p.Email)
                .CanFilter()
                .CanSort()
                .HasName("user_email");

            mapper.Property<ApplicationUser>(p => p.Username)
                .CanFilter()
                .CanSort()
                .HasName("user_username");

            mapper.Property<ApplicationUser>(p => p.CreatedOn)
                .CanFilter()
                .CanSort()
                .HasName("user_createdon");

            mapper.Property<ApplicationUser>(p => p.LastModified)
                .CanFilter()
                .CanSort()
                .HasName("user_lastmodified");
        }
    }
}
