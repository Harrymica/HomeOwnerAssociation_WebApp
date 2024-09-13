using HomeOwnerAssociation_WebApp.Models;

namespace HomeOwnerAssociation_WebApp.Services.MaintenanceRepo
{
    public interface IMaintenanceService
    {
        Task AddMaintenances(MaintenanceHistory maintenance);
        Task DeleteMaintenanceAsync(int id);
        Task EditMaintenance(MaintenanceHistory maintenance);
        Task<List<MaintenanceHistory>> GetAllMaintenanceAsync();
        Task<MaintenanceHistory> GetMaintenanceById(int Id);
    }
}