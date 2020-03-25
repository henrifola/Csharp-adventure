using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using assignment_4.Models;

namespace assignment_4.Data
{
    public class ApplicationDbContext : IdentityDbContext<Account>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
