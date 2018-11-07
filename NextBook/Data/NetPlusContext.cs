using Microsoft.EntityFrameworkCore;
using NextBook.Models;

namespace NextBook.Data
{
    public class NetPlusContext : DbContext
    {
        public NetPlusContext(DbContextOptions<NetPlusContext> opts)
        : base(opts) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}