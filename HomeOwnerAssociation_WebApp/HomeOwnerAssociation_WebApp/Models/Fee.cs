using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeOwnerAssociation_WebApp.Models
{
    public class Fee
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string BankAccount { get; set; }
        public string BankTransactionId { get; set; }
        public string Frequency { get; set; } // e.g., monthly, annually
        public Property Property { get; set; }

        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
        //public PropertyOwners PropertyOwners { get; set; }

        //[ForeignKey(nameof(PropertyOwners))]
        //public int PropertyOwnersId { get; set; }
        public DateTime DateForMonthlyPayment { get; set; }
        public string Status { get; set; } = "Not Paid";

        //public decimal? Assessment { get; set; }
        public decimal? RemainingDept { get; set; }
    }

}
