using HomeOwnerAssociation_WebApp.Models;

namespace HomeOwnerAssociation_WebApp.Services.HOA_Service
{
    public interface IHOA_Repository
    {
        Task AddHOA(HOA hoa);
        Task DeleteHOAAsync(int id);
        Task EdithHOA(HOA hoa);
        Task<List<HOA>> GetAllHOAAsync();
        Task<HOA> GetHOAById(int Id);
    }
}