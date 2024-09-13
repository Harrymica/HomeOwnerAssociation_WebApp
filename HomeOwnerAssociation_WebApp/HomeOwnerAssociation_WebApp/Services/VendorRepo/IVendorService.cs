using HomeOwnerAssociation_WebApp.Models;

namespace HomeOwnerAssociation_WebApp.Services.VendorRepo
{
    public interface IVendorService
    {
        Task AddVendor(Vendor vendor);
        Task DeleteVendorAsync(int id);
        Task EdithVendor(Vendor vendor);
        Task<List<Vendor>> GetAllVendorAsync();
        Task<Vendor> GetVendorById(int Id);
    }
}