using HomeOwnerAssociation_WebApp.Data;
using HomeOwnerAssociation_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeOwnerAssociation_WebApp.Services.MaintenanceRepo
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public MaintenanceService(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;

        }

        public async Task AddMaintenances(MaintenanceHistory maintenance)
        {
            using var db = await _factory.CreateDbContextAsync();

            db.Add(maintenance);
            await db.SaveChangesAsync();
        }

        public async Task EditMaintenance(MaintenanceHistory maintenance)
        {
            using var db = _factory.CreateDbContextAsync();
            var NewMaintenance = await db.Result.Maintenances.FirstOrDefaultAsync(s => s.Id == maintenance.Id);
            if (NewMaintenance != null)
            {
                NewMaintenance.Name = maintenance.Name;
                NewMaintenance.Description = maintenance.Description;
                NewMaintenance.ReserveFunds = maintenance.ReserveFunds;
                NewMaintenance.Schedules = maintenance.Schedules;


                db.Result.Update(NewMaintenance);
                await db.Result.SaveChangesAsync();
            }
        }

        public async Task<List<MaintenanceHistory>> GetAllMaintenanceAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            var result = db.Maintenances.ToListAsync();

            return await result;
        }
        public async Task<MaintenanceHistory> GetMaintenanceById(int Id)
        {
            using var db = await _factory.CreateDbContextAsync();

            var result = await db.Maintenances.FirstOrDefaultAsync(u => u.Id == Id);

            return result;
        }

        public async Task DeleteMaintenanceAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var maintenance = await db.Result.Maintenances.FirstOrDefaultAsync(s => s.Id == id);
            if (maintenance != null)
            {
                db.Result.Remove(maintenance);
                await db.Result.SaveChangesAsync();
            }
        }
    }
}
