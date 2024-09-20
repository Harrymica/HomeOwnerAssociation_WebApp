using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeOwnerAssociation_WebApp.Models
{
    public class MaintenanceHistory
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
      
        public List<Property>? property { get;  set; }
        public int propertyId { get; set; }
        public DateTime Schedules { get; set; }
        public decimal ReserveFunds { get; set; }


    }

    public class DeedRestriction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateRestricted { get; set; }
        public string Restriction_Status { get; set; }
        public Property Property { get; set; }
        public int PropertyId { get; set; }
       

    }


    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactInformation { get; set; }

        public Property Propertys { get; set; }

        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        
    }
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
       
    }

    public class WorkOrder
    {
        public int Id { get; set; }
        public string Description { get; set; }
        
    }

    public class BankAccount
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankHolderName { get; set; }
        public PropertyOwners PropertyOwners { get; set; }
        public int PropertyOwnersId { get; set; }
    }



}
