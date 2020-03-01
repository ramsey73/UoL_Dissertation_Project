using Microsoft.AspNetCore.Identity;
using System;

namespace StellarClothing.AdminApp.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeAddress { get; set; }
        public int? ZipCode { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
