using HomeOwnerAssociation_WebApp.Models;

namespace HomeOwnerAssociation_WebApp.Services.PropertyService
{
    public interface IPropertyServiceRepo
    {
        Task AddProperties(Property property);
        Task DeletePropertyAsync(int id);
        Task EdithProperties(Property property);
        Task<List<Property>> GetAllPropertiresAsync();
        Task<Property> GetPropertyById(int Id);
    }
}