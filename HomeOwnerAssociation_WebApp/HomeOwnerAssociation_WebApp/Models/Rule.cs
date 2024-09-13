namespace HomeOwnerAssociation_WebApp.Models
{
    public class Rule
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } // e.g., property appearance, noise level, pet restriction
    }

}
