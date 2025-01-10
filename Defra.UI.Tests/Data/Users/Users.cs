using Defra.UI.Tests.Configuration;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System.Reflection;

namespace Defra.UI.Tests.Data.Users
{
    public class User
    {
        public string UserName { get; set; }
        public string Credential { get; set; }
        public string LoginInfo { get; set; }
        public string Environment { get; set; }
        public bool HomePage { get; set; }
    }
    
    public interface IUserObject
    {
        public User GetUser(string application);
    }

    internal class UserObject : IUserObject
    {
        private readonly object _lock = new object();

        public User GetUser(string application)
        {
            User? user;

            lock (_lock)
            {
                var environment = ConfigSetup.BaseConfiguration.TestConfiguration.Environment;

                var jsonPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var filePath = Path.Combine(jsonPath, "Data", "Users", application.ToUpper(), environment.ToUpper(), "Users.json");

                var builder = new ConfigurationBuilder();
                builder.AddJsonFile(filePath, false, true);
                var settings = builder.Build();
                var usersList = settings.GetSection("Users").Get<List<User>>();

                var rng = new Random();
                user = usersList?[rng.Next(usersList.Count)];
            }

            return user ?? new User { };
        }
    }
}