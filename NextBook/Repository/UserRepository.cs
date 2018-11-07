using Microsoft.EntityFrameworkCore;
using NextBook.Data;
using NextBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextBook.Repository
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(NetPlusContext context)
        {
            _context = context;
        }

        private NetPlusContext _context { get; }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUserAsync(long id)
        {
            return await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.Include(p => p.Photos).ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}