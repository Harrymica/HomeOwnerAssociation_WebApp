using System.ComponentModel.DataAnnotations;

namespace HomeOwnerAssociation_WebApp.Models
{
    
    public class HOA
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PropertyOwners> HouseOwners { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<Fee> Fees { get; set; }
        public ICollection<Rule> Rules { get; set; }
        public ICollection<BoardMember> BoardMembers { get; set; }
        public ICollection<MaintenanceHistory> MaintenanceHistories { get; set; }
        public ICollection<Budgeting> Budgetings { get; set; }
        public ICollection<DeedRestriction> DeedRestrictions { get; set; }
    }

}
