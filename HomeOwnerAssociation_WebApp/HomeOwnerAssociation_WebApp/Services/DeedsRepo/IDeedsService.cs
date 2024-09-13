using HomeOwnerAssociation_WebApp.Models;

namespace HomeOwnerAssociation_WebApp.Services.DeedsRepo
{
    public interface IDeedsService
    {
        Task Add_Deeds(DeedRestriction deeds);
        Task Delete_DeedsAsync(int id);
        Task Edit_Deeds(DeedRestriction deeds);
        Task<List<DeedRestriction>> GetAll_DeedsAsync();
        Task<DeedRestriction> Get_DeedsById(int Id);
    }
}