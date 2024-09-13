using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeOwnerAssociation_WebApp.Models
{
    public class PropertyOwners
    {
        public int Id { get; set; } 
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        // One-to-many relationship with Properties
        public List<Property>? Properties { get; set; }

        //public List<Fee>? Fees { get; set; }
        //[ForeignKey(nameof(Fee))]
        //public int FeesId { get; set; }

        

        


    }
}

