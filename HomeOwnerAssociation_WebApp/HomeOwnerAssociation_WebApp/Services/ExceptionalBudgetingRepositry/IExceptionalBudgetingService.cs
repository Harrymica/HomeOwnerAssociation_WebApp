using HomeOwnerAssociation_WebApp.Models;

namespace HomeOwnerAssociation_WebApp.Services.ExceptionalBudgetingRepositry
{
    public interface IExceptionalBudgetingService
    {
        Task AddE_Budgeting(ExeptionalBudgeting exeptionalBudgeting);
        Task DeleteE_BudgetingAsync(int id);
        Task EdithE_Budgeting(ExeptionalBudgeting exeptionalBudgeting);
        Task<List<ExeptionalBudgeting>> GetAllE_BudgetingAsync();
        Task<ExeptionalBudgeting> GetExeptionalBudgetingById(int Id);
    }
}