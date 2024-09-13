using System.ComponentModel.DataAnnotations;

namespace HomeOwnerAssociation_WebApp.Models
{
    
    public class BoardMember
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
       
       
    }

}
