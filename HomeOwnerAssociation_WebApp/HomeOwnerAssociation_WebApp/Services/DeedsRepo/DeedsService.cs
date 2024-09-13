using HomeOwnerAssociation_WebApp.Data;
using HomeOwnerAssociation_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeOwnerAssociation_WebApp.Services.DeedsRepo
{
    public class DeedsService : IDeedsService
    {


        private readonly IDbContextFactory<ApplicationDbContext> _factory;


        public DeedsService(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;

        }

        public async Task Add_Deeds(DeedRestriction deeds)
        {
            using var db = await _factory.CreateDbContextAsync();

            db.Add(deeds);
            await db.SaveChangesAsync();
        }

        public async Task Edit_Deeds(DeedRestriction deeds)
        {
            using var db = _factory.CreateDbContextAsync();
            var NewDeeds = await db.Result.DeedRestrictions.FirstOrDefaultAsync(s => s.Id == deeds.Id);
            if (NewDeeds != null)
            {
                NewDeeds.Description = deeds.Description;
                NewDeeds.DateRestricted = deeds.DateRestricted;
                NewDeeds.Restriction_Status = deeds.Restriction_Status;



                db.Result.Update(NewDeeds);
                await db.Result.SaveChangesAsync();
            }
        }

        public async Task<List<DeedRestriction>> GetAll_DeedsAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            var result = db.DeedRestrictions.ToListAsync();

            return await result;
        }
        public async Task<DeedRestriction> Get_DeedsById(int Id)
        {
            using var db = await _factory.CreateDbContextAsync();

            var result = await db.DeedRestrictions.FirstOrDefaultAsync(u => u.Id == Id);

            return result;
        }

        public async Task Delete_DeedsAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var deeds = await db.Result.DeedRestrictions.FirstOrDefaultAsync(s => s.Id == id);
            if (deeds != null)
            {
                db.Result.Remove(deeds);
                await db.Result.SaveChangesAsync();
            }
        }
    }
}
