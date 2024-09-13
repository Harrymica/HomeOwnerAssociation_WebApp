using HomeOwnerAssociation_WebApp.Data;
using HomeOwnerAssociation_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeOwnerAssociation_WebApp.Services.ExceptionalBudgetingRepositry
{
    public class ExceptionalBudgetingService : IExceptionalBudgetingService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public ExceptionalBudgetingService(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddE_Budgeting(ExeptionalBudgeting exeptionalBudgeting)
        {
            using var db = await _factory.CreateDbContextAsync();

            db.ExeptionalBudgetings.Add(exeptionalBudgeting);
            await db.SaveChangesAsync();
        }

        public async Task EdithE_Budgeting(ExeptionalBudgeting exeptionalBudgeting)
        {
            using var db = _factory.CreateDbContextAsync();
            var E_Budgeting = await db.Result.ExeptionalBudgetings.FirstOrDefaultAsync(s => s.Id == exeptionalBudgeting.Id);
            if (E_Budgeting != null)
            {
                E_Budgeting.ExpensesValue = exeptionalBudgeting.ExpensesValue;

                //E_Budgeting.FullName = commitees.FullName;
                //commitees.Phone = commitees.Phone;
                //commitees.BankAccount = commitees.BankAccount;
                //commitees.Position = commitees.Position;



                db.Result.Update(E_Budgeting);
                await db.Result.SaveChangesAsync();
            }
        }

        public async Task<List<ExeptionalBudgeting>> GetAllE_BudgetingAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            var result = db.ExeptionalBudgetings.ToListAsync();

            return await result;
        }
        public async Task<ExeptionalBudgeting> GetExeptionalBudgetingById(int Id)
        {
            using var db = await _factory.CreateDbContextAsync();

            var result = await db.ExeptionalBudgetings.FirstOrDefaultAsync(u => u.Id == Id);

            return result;
        }

        public async Task DeleteE_BudgetingAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var E_Budgeting = await db.Result.ExeptionalBudgetings.FirstOrDefaultAsync(s => s.Id == id);
            if (E_Budgeting != null)
            {
                db.Result.Remove(E_Budgeting);
                await db.Result.SaveChangesAsync();
            }
        }
    }
}
