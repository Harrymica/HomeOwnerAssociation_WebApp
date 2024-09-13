using HomeOwnerAssociation_WebApp.Models;

namespace HomeOwnerAssociation_WebApp.Services.PropertyTypeService
{
    public interface IPropertyTypeServiceRepo
    {
        Task AddPropertiesType(PropertyType propertytype);
        Task DeletePropertyTypeAsync(int id);
        Task EdithPropertiesType(PropertyType propertytype);
        Task<List<PropertyType>> GetAllPropertiresTypeAsync();
        Task<PropertyType> GetPropertyTypeById(int Id);
    }
}