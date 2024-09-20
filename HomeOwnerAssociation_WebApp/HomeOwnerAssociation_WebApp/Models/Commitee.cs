using System.ComponentModel.DataAnnotations;

namespace HomeOwnerAssociation_WebApp.Models
{
    public class Commitee
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phone {get; set;}
        public string Email { get; set;}
        public string BankAccount { get; set;}
        public string UsedCurrency { get; set; }
        
        public List<Property> Property { get; set; }
        public int PropertyId { get; set; }
       
    }
}
