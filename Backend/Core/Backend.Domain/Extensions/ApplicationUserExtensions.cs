using System;
using System.Collections.Generic;
using System.Text;
using Backend.Domain.Entities;

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
