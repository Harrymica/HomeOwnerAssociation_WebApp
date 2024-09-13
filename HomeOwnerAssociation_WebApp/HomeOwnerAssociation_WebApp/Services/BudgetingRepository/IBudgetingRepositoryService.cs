using HomeOwnerAssociation_WebApp.Models;

namespace HomeOwnerAssociation_WebApp.Services.BudgetingRepository
{
    public interface IBudgetingRepositoryService
    {
        Task AddBudgeting(Budgeting budgeting);
        Task DeleteBudgetingAsync(int id);
        Task EdithBudgeting(Budgeting budgeting);
        Task<List<Budgeting>> GetAllBudgetingAsync();
        Task<Budgeting> GetBudgetingById(int Id);
    }
}