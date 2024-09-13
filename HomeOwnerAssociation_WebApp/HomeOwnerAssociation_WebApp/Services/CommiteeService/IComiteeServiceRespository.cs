using HomeOwnerAssociation_WebApp.Models;

namespace HomeOwnerAssociation_WebApp.Services.CommiteeService
{
    public interface IComiteeServiceRespository
    {
        Task AddCommitees(Commitee Commitees);
        Task DeleteCommiteeAsync(int id);
        Task<Commitee> GetCommiteeById(int Id);
        Task EdithCommitees(Commitee commitee);
        Task<List<Commitee>> GetAllCommiteesAsync();
    }
}