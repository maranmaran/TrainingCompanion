using Backend.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Backend.Domain;
using Backend.Service.Authorization;
using Backend.Service.Authorization.Interfaces;
using Backend.Service.Authorization.Utils;
using Xunit;

namespace Backend.Core.Service.Tests
{
    public class AuthorizationServiceTests
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly JwtSettings _testSettings;
        private readonly ApplicationUser _testUser;

        //fixture
        public AuthorizationServiceTests()
        {
            _testUser = new ApplicationUser()
            {
                FirstName = "Test",
                LastName = "Test",
                CreatedOn = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
                Email = "test@test.com",
                Id = Guid.NewGuid(),
                PasswordHash =
                    "9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08" // matches "test" in pain text,
            };

            _testSettings = new JwtSettings()
            {
                JwtSecret = "MyExtraLongTestSecretLol"
            };

            _passwordHasher = new PasswordHasher();
            _tokenGenerator = new JwtTokenGenerator(_testSettings);
        }

        [Fact]
        public void GetJwt_GetsValidJwt()
        {

            var token = _tokenGenerator.GenerateToken(_testUser.Id);

            // validate token
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_testSettings.JwtSecret)),
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = false,
                ValidateActor = false,
            };

            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out _);
            }
            catch (Exception e)
            {
                Assert.True(false, e.Message);
            }

            Assert.True(true);
        }

        [Fact]
        public void HashPassword_Hashes()
        {
            var password = "myUltraSecretPassword";
            string testHash = GetTestHash(password);

            var hash = _passwordHasher.GetPasswordHash(password);

            Assert.Equal(testHash, hash);
        }

        private string GetTestHash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Get the hashed string.  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
