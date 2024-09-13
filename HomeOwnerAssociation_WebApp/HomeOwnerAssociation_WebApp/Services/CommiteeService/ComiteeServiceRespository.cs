using HomeOwnerAssociation_WebApp.Data;
using HomeOwnerAssociation_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeOwnerAssociation_WebApp.Services.CommiteeService
{
    public class ComiteeServiceRespository : IComiteeServiceRespository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public ComiteeServiceRespository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddCommitees(Commitee Commitees)
        {
            using var db = await _factory.CreateDbContextAsync();

            db.Commitees.Add(Commitees);
            await db.SaveChangesAsync();
        }

        public async Task EdithCommitees(Commitee commitee)
        {
            using var db = _factory.CreateDbContextAsync();
            var Newcommitees = await db.Result.Commitees.FirstOrDefaultAsync(s => s.Id == commitee.Id);
            if (Newcommitees != null)
            {
                Newcommitees.Email = commitee.Email;
                Newcommitees.UsedCurrency = commitee.UsedCurrency;
                Newcommitees.FullName = commitee.FullName;
                Newcommitees.Phone = commitee.Phone;
                Newcommitees.BankAccount = commitee.BankAccount;
                Newcommitees.Position = commitee.Position;



                db.Result.Update(Newcommitees);
                await db.Result.SaveChangesAsync();
            }
            
        }

        public async Task<List<Commitee>> GetAllCommiteesAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            var result = db.Commitees.ToListAsync();

            return await result;
        }

        public async Task<Commitee> GetCommiteeById(int Id)
        {
            using var db = await _factory.CreateDbContextAsync();

            var result = await db.Commitees.FirstOrDefaultAsync(u => u.Id == Id);

            return result;
        }
        public async Task DeleteCommiteeAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var commitee = await db.Result.Commitees.FirstOrDefaultAsync(s => s.Id == id);
            if (commitee != null)
            {
                db.Result.Remove(commitee);
                await db.Result.SaveChangesAsync();
            }
           
        }
    }
}
