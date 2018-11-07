using Newtonsoft.Json;
using NextBook.Models;
using System.Collections.Generic;

namespace NextBook.Data
{
    public class Seed
    {
        private readonly NetPlusContext dataContext;

        public Seed(NetPlusContext context)
        {
            dataContext = context;
        }

        public void SeedUsers()
        {
            var userData = System.IO.File.ReadAllText("Data/userSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.UserName = user.UserName.ToLower();
                dataContext.Users.Add(user);
            }
            dataContext.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}