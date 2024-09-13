using System.ComponentModel.DataAnnotations;

namespace HomeOwnerAssociation_WebApp.Models
{
    public class PropertyType
    {
        [Key]
        public int Id { get; set; }
        public string UnitType { get; set; }
        public decimal MonthlyFee { get; set; }
       
    }

    public enum PropertyUnitType
    {
        Small_Appartment,
        Big_Appartement,
        Garage
    }
}
