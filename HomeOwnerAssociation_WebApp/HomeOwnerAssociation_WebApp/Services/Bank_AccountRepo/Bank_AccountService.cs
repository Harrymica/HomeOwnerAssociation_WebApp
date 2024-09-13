using HomeOwnerAssociation_WebApp.Data;
using HomeOwnerAssociation_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeOwnerAssociation_WebApp.Services.Bank_AccountRepo
{
    public class Bank_AccountService : IBank_AccountService
    {

        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public Bank_AccountService(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;

        }

        public async Task AddBankAccountDetails(BankAccount bank)
        {
            using var db = await _factory.CreateDbContextAsync();

            db.Add(bank);
            await db.SaveChangesAsync();
        }

        public async Task EditMaintenance(BankAccount bank)
        {
            using var db = _factory.CreateDbContextAsync();
            var NewMBnakDetails = await db.Result.BankAccounts.FirstOrDefaultAsync(s => s.Id == bank.Id);
            if (NewMBnakDetails != null)
            {
                NewMBnakDetails.BankName = bank.BankName;
                NewMBnakDetails.AccountNumber = bank.AccountNumber;
                NewMBnakDetails.BankHolderName = bank.BankHolderName;



                db.Result.Update(NewMBnakDetails);
                await db.Result.SaveChangesAsync();
            }
        }

        public async Task<List<BankAccount>> GetAllMaintenanceAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            var result = db.BankAccounts.ToListAsync();

            return await result;
        }
        public async Task<BankAccount> GetMaintenanceById(int Id)
        {
            using var db = await _factory.CreateDbContextAsync();

            var result = await db.BankAccounts.FirstOrDefaultAsync(u => u.Id == Id);

            return result;
        }

        public async Task DeleteMaintenanceAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var bank = await db.Result.BankAccounts.FirstOrDefaultAsync(s => s.Id == id);
            if (bank != null)
            {
                db.Result.Remove(bank);
                await db.Result.SaveChangesAsync();
            }
        }
    }
}
