using HomeOwnerAssociation_WebApp.Models;

namespace HomeOwnerAssociation_WebApp.Services.PropertyOwnersRepo
{
    public interface IPropertyOwnerService
    {
        Task AddPropOwner(PropertyOwners owners);
        Task DeleteOwnerAsync(int id);
        Task EditOwner(PropertyOwners owners);
        Task<List<PropertyOwners>> GetAllOwnersAsync();
        Task<PropertyOwners> GetOwnerById(int Id);
    }
}