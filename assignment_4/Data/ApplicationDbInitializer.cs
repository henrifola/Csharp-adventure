using System;
using System.Collections.Generic;
using System.Linq;
using assignment_4.Models;
using Microsoft.AspNetCore.Identity;

namespace assignment_4.Data
{
    public class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext db, UserManager<Account> um, RoleManager<IdentityRole> rm)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            
            // Create users
            var user = new Account { Nickname = "Henriette", UserName = "henrif18@uia.no", Email = "henrif18@uia.no", EmailConfirmed = true};
            um.CreateAsync(user, "Passord1.").Wait();
            db.SaveChanges();

            
        

            db.SaveChanges();
        }
    }
}