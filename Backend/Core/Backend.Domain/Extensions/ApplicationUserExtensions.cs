using Backend.Domain.Entities.User;

namespace Backend.Domain.Extensions
{
    public static class ApplicationUserExtensions
    {
        public static string GetFullName(this ApplicationUser user)
        {
            return $"{user.FirstName} {user.LastName}";
        }
    }
}