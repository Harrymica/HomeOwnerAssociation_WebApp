using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeOwnerAssociation_WebApp.Models
{
    public class ExeptionalBudgeting
    {
        [Key]
        public int Id { get; set; }
        public Property Property { get; set; }
        [ForeignKey(nameof(Property))]

        public int PropertyId { get; set; }
        public TypeOfBudget typeOfBudget { get; set; }
        public TypeOfExpenses typeOfExpences { get; set; }
        public decimal ExpensesValue { get; set; }
    }

}
