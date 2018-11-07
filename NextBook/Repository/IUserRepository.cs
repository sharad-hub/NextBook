using NextBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextBook.Repository
{
    public interface IUserRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<User> GetUserAsync(long id);

        Task<IEnumerable<User>> GetUsersAsync();

        Task<bool> SaveAll();
    }
}