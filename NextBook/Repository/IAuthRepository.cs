﻿using NextBook.Models;
using System.Threading.Tasks;

namespace NextBook.Repository
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(User user, string password);

        Task<User> LoginAsync(string username, string password);

        Task<bool> UserExistsAsync(string username);
    }
}