using System.ComponentModel.DataAnnotations.Schema;

namespace HomeOwnerAssociation_WebApp.Models
{
    public class Assessment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public Property Property { get; set; }

        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }
    }
}
