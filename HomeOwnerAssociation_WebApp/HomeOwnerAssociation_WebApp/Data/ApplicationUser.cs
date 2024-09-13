using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HomeOwnerAssociation_WebApp.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "First Name cannot be empty")]
        [StringLength(100, ErrorMessage = "First Name cannot be less than 10 character")]
        public string? FullName { get; set; }


        [Required(ErrorMessage = "Country field cannot be empty")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "Address field cannot be empty")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "City field cannot be empty")]
        public string? City { get; set; } = null;
    }

}
