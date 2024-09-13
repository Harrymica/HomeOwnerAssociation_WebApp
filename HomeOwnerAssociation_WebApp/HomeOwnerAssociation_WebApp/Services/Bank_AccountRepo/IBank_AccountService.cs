using HomeOwnerAssociation_WebApp.Models;

namespace HomeOwnerAssociation_WebApp.Services.Bank_AccountRepo
{
    public interface IBank_AccountService
    {
        Task AddBankAccountDetails(BankAccount bank);
        Task DeleteMaintenanceAsync(int id);
        Task EditMaintenance(BankAccount bank);
        Task<List<BankAccount>> GetAllMaintenanceAsync();
        Task<BankAccount> GetMaintenanceById(int Id);
    }
}