using System;

namespace Backend.Service.Authorization.Interfaces
{
    public interface IJwtTokenGenerator
    {
        /// <summary>
        /// Generates jwt token for user
        /// </summary>
        /// <returns></returns>
        string GenerateToken(Guid userId);
    }
}
