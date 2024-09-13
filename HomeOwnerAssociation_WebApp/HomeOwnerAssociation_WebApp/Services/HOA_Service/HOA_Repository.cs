using HomeOwnerAssociation_WebApp.Data;
using HomeOwnerAssociation_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeOwnerAssociation_WebApp.Services.HOA_Service
{
    public class HOA_Repository : IHOA_Repository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public HOA_Repository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddHOA(HOA hoa)
        {
            using var db = await _factory.CreateDbContextAsync();

            db.HOA.Add(hoa);
            await db.SaveChangesAsync();
        }

        public async Task EdithHOA(HOA hoa)
        {
            using var db = _factory.CreateDbContextAsync();
            var Newhoa = await db.Result.HOA.FirstOrDefaultAsync(s => s.Id == hoa.Id);
            if (Newhoa != null)
            {
                Newhoa.Name = hoa.Name;
                Newhoa.Description = hoa.Description;

                //E_Budgeting.FullName = commitees.FullName;
                //commitees.Phone = commitees.Phone;
                //commitees.BankAccount = commitees.BankAccount;
                //commitees.Position = commitees.Position;



                db.Result.Update(Newhoa);
                await db.Result.SaveChangesAsync();
            }
        }

        public async Task<List<HOA>> GetAllHOAAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            var result = db.HOA.ToListAsync();

            return await result;
        }

        public async Task<HOA> GetHOAById(int Id)
        {
            using var db = await _factory.CreateDbContextAsync();

            var result = await db.HOA.FirstOrDefaultAsync(u => u.Id == Id);

            return result;
        }

        public async Task DeleteHOAAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var hoa = await db.Result.HOA.FirstOrDefaultAsync(s => s.Id == id);
            if (hoa != null)
            {
                db.Result.Remove(hoa);
                await db.Result.SaveChangesAsync();
            }
        }
    }
}
