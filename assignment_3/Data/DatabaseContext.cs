using assignment_3.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment_3.Data
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }
        
        public DbSet<Guestbook> Posts { get; set; }
        

    }
}