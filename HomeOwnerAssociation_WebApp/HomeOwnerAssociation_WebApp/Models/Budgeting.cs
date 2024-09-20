using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeOwnerAssociation_WebApp.Models
{
    public class Budgeting
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateOfExpenses { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}
        public decimal Cost { get; set; }

        public string ExpensesType { get; set; }
        
        public TypeOfBudget typeOfBudget { get; set; }
       // public TypeOfExpenses typeOfExpences { get; set; }

        public Property Propertys { get; set; }


        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
    }

    public enum TypeOfBudget
    {
        Income,
        Expences

    }

    public enum TypeOfExpenses
    {
        Electricity,
        Water
    }
    
}
