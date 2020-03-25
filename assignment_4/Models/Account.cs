using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace assignment_4.Models
{
    public class Account : IdentityUser
    {
        public Account() { }

        public Account(string firstName, string lastName, string nickname)
        {
            FirstName = firstName;
            LastName = lastName;
            Nickname = nickname;
        }
        
        [Display(Name = "First Name")] 
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Nickname")]
        public string Nickname { get; set; }
        
        public List<Post> Posts { get; set; }
    }
}