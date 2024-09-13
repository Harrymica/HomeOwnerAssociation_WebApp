using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeOwnerAssociation_WebApp.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public PropertyType? PropertyType { get; set; } // e.g., single-family home, condo, townhouse
        public int? PropertyTypeId { get; set; }
        public int Units { get; set; } 
        public PropertyOwners? propertyOwner { get; set; }

        [ForeignKey(nameof(PropertyOwners))]
        public int? propertyOwnerId { get; set; }

        public List<Fee>? Fees { get; set; }
        public int? FeesId { get; set; }

        public List<Budgeting>? Budgeting { get; set; }
        public int BudgetingId { get; set; } 
        public List<Vendor>? Vendor { get; set; }
        public int VendorId { get; set; }
        public List<Assessment> Assessment { get; set; }
        public int AssessmentId { get; set; }
        public List<DeedRestriction>? Restriction { get; set; }
        public int RestrictionId { get; set; }

        public List<FinancialManagement>? FinancialHistory { get; set; }


        public int FinancialHistoryId { get; set; }




    }
}
