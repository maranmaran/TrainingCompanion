using System;

namespace Backend.Business.Authorization.Interfaces
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