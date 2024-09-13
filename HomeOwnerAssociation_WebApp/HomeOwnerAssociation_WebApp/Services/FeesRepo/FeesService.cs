using HomeOwnerAssociation_WebApp.Data;
using HomeOwnerAssociation_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeOwnerAssociation_WebApp.Services.FeesRepo
{
    public class FeesService : IFeesService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public FeesService(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddFees(Fee fee)
        {
            using var db = await _factory.CreateDbContextAsync();

            db.Fees.Add(fee);
            await db.SaveChangesAsync();
        }

        public async Task EditFees(Fee fee)
        {
            using var db = _factory.CreateDbContextAsync();
            var _fee = await db.Result.Fees.FirstOrDefaultAsync(s => s.Id == fee.Id);
            if (_fee != null)
            {
                _fee.BankAccount = fee.BankAccount;
                _fee.DateForMonthlyPayment = fee.DateForMonthlyPayment;
                _fee.Frequency = fee.Frequency;
                
                _fee.BankTransactionId = fee.BankTransactionId;
                _fee.Amount = fee.Amount;
                _fee.PropertyId = fee.PropertyId;


                db.Result.Update(_fee);
                await db.Result.SaveChangesAsync();
            }
        }

        public async Task<List<Fee>> GetAllFeesAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            var result = db.Fees.ToListAsync();

            return await result;
        }

        public async Task<Fee> GetFeesById(int Id)
        {
            using var db = await _factory.CreateDbContextAsync();

            var result = await db.Fees.FirstOrDefaultAsync(u => u.Id == Id);

            return result;
        }
        public async Task DeleteFeesAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var budgeting = await db.Result.Fees.FirstOrDefaultAsync(s => s.Id == id);
            if (budgeting != null)
            {
                db.Result.Remove(budgeting);
                await db.Result.SaveChangesAsync();
            }
        }
    }
}
