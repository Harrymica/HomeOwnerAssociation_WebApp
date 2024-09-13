using HomeOwnerAssociation_WebApp.Data;
using HomeOwnerAssociation_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeOwnerAssociation_WebApp.Services.BudgetingRepository
{
    public class BudgetingRepositoryService : IBudgetingRepositoryService
    {

        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public BudgetingRepositoryService(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddBudgeting(Budgeting budgeting)
        {
            using var db = await _factory.CreateDbContextAsync();

            db.Budgetings.Add(budgeting);
            await db.SaveChangesAsync();
        }

        public async Task EdithBudgeting(Budgeting budgeting)
        {
            using var db = _factory.CreateDbContextAsync();
            var member = await db.Result.Budgetings.FirstOrDefaultAsync(s => s.Id == budgeting.Id);
            if (member != null)
            {
                member.Cost = budgeting.Cost;
                member.Name = budgeting.Name;
                member.Description = budgeting.Description;
                member.typeOfBudget = budgeting.typeOfBudget;
                member.ExpensesType = budgeting.ExpensesType;
                member.DateOfExpenses = budgeting.DateOfExpenses;

                db.Result.Update(member);
                await db.Result.SaveChangesAsync();
            }
        }

        public async Task<List<Budgeting>> GetAllBudgetingAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            var result = db.Budgetings.ToListAsync();

            return await result;
        }

        public async Task<Budgeting> GetBudgetingById(int Id)
        {
            using var db = await _factory.CreateDbContextAsync();

            var result = await db.Budgetings.FirstOrDefaultAsync(u => u.Id == Id);

            return result;
        }
        public async Task DeleteBudgetingAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var budgeting = await db.Result.Budgetings.FirstOrDefaultAsync(s => s.Id == id);
            if (budgeting != null)
            {
                db.Result.Remove(budgeting);
                await db.Result.SaveChangesAsync();
            }
        }
    }
}
