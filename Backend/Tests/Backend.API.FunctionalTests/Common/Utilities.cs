using Backend.Domain.Entities;
using Backend.Persistance;
using Backend.Service.Authorization;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Authorization.Utils;

namespace Backend.API.FunctionalTests.Common
{
    public class Utilities
    {
        public static StringContent GetRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }

        public static void InitializeDbForTests(ApplicationDbContext context)
        {
            Initialize(context);
        }

        private static void Initialize(ApplicationDbContext context)
        {
            var passwordHasher = new PasswordHasher();
            context.Database.EnsureCreated();
            var users = new ApplicationUser[]
            {
                // users
                new ApplicationUser()
                {
                    Id = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D"),
                    Username = "adamcogan",
                    Email = "adam.cogan@gmail.com",
                    FirstName = "Adam",
                    LastName = "Cogan",
                    PasswordHash = passwordHasher.GetPasswordHash("12345"),
                },
                new ApplicationUser()
                {
                    Id = new Guid("72FA647C-AD54-4BCC-A860-E5A2664B019D"),
                    Username = "jasontaylor",
                    Email = "jason.taylor@gmail.com",
                    FirstName = "Jason",
                    LastName = "Taylor",
                    PasswordHash = passwordHasher.GetPasswordHash("12345"),
                },
                new ApplicationUser()
                {
                    Id = new Guid("82FA647C-AD54-4BCC-A860-E5A2664B019D"),
                    Username = "brendanrichards",
                    Email = "brendan.richards@gmail.com",
                    FirstName = "Brendan",
                    LastName = "Richards",
                    PasswordHash = passwordHasher.GetPasswordHash("12345"),
                },
                // subusers
                new ApplicationUser()
                {
                    Id = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B039D"),
                    Username = "subuser1",
                    Email = "adam.cogan@gmail.com",
                    FirstName = "Adam",
                    LastName = "Cogan",
                    ParentId =  new Guid("62FA647D-AD54-4BCC-A860-E5A2664B019D"),
                    Parent = new ApplicationUser()
                        {
                            Id = new Guid("62FA647D-AD54-4BCC-A860-E5A2664B019D"),
                            Username = "adamcoganParent",
                            Email = "adam.cogan@gmail.com",
                            FirstName = "Adam",
                            LastName = "Cogan",
                            PasswordHash = passwordHasher.GetPasswordHash("12345"),
                        },
                },
                new ApplicationUser()
                {
                    Id = new Guid("62FA647C-AD54-4BCC-A860-E5A26645019D"),
                    Username = "subuser2",
                    Email = "adam.cogan@gmail.com",
                    FirstName = "Adam",
                    LastName = "Cogan",
                    ParentId =  new Guid("62FA647F-AD54-4BCC-A860-E5A2664B019D"),
                    Parent = new ApplicationUser()
                    {
                        Id = new Guid("62FA647F-AD54-4BCC-A860-E5A2664B019D"),
                        Username = "adamcoganParent2",
                        Email = "adam.cogan@gmail.com",
                        FirstName = "Adam",
                        LastName = "Cogan",
                        PasswordHash = passwordHasher.GetPasswordHash("12345"),
                    },
                },
                new ApplicationUser()
                {
                    Id = new Guid("62FA647C-AD54-4BCC-A860-E5A6664B019D"),
                    Username = "subuser3",
                    Email = "adam.cogan@gmail.com",
                    FirstName = "Adam",
                    LastName = "Cogan",
                    ParentId =  new Guid("62FA647E-AD54-4BCC-A860-E5A2664B019D"),
                    Parent = new ApplicationUser()
                    {
                        Id = new Guid("62FA647E-AD54-4BCC-A860-E5A2664B019D"),
                        Username = "adamcoganParent3",
                        Email = "adam.cogan@gmail.com",
                        FirstName = "Adam",
                        LastName = "Cogan",
                        PasswordHash = passwordHasher.GetPasswordHash("12345"),
                    },
                },
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
