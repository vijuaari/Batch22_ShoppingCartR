using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartR.Models
{
    public class ApplicationUser:IdentityUser//AppUser is implimenting from Identity User ,so this table is an extension
    {
         [Required]
        public string? Name { get; set; }

        public string? StreetAddress { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }
        public string? PostalCode { get; set; } 
        


    }
}
