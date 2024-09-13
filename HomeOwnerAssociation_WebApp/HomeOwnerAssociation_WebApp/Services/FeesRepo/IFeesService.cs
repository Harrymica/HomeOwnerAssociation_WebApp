using HomeOwnerAssociation_WebApp.Models;

namespace HomeOwnerAssociation_WebApp.Services.FeesRepo
{
    public interface IFeesService
    {
        Task AddFees(Fee fee);
        Task DeleteFeesAsync(int id);
        Task EditFees(Fee fee);
        Task<List<Fee>> GetAllFeesAsync();
        Task<Fee> GetFeesById(int Id);
    }
}