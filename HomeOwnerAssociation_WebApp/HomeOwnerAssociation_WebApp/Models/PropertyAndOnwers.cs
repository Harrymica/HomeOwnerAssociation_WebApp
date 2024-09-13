using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeOwnerAssociation_WebApp.Models
{
    public class PropertyAndOnwers
    {
        [Key]
        public int Id { get; set; }

        public ICollection<PropertyOwners> HouseOwners { get; set; }
        [ForeignKey(nameof(PropertyOwners))]
        public int HouseOwnersId { get; set; }

       
        public ICollection<Property> Properties { get; set; }
        [ForeignKey(nameof(Property))]
        public int PropertiesId { get; set; }
    }
}
