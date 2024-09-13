using HomeOwnerAssociation_WebApp.Data;
using HomeOwnerAssociation_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HomeOwnerAssociation_WebApp.Services.VendorRepo
{
    public class VendorService : IVendorService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public VendorService(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;

        }

        public async Task AddVendor(Vendor vendor)
        {
            using var db = await _factory.CreateDbContextAsync();

            db.Add(vendor);
            await db.SaveChangesAsync();
        }

        public async Task EdithVendor(Vendor vendor)
        {
            using var db = _factory.CreateDbContextAsync();
            var NewVendor = await db.Result.Vendor.FirstOrDefaultAsync(s => s.Id == vendor.Id);
            if (NewVendor != null)
            {
                NewVendor.Name = vendor.Name;
                NewVendor.ContactInformation = vendor.ContactInformation;


                db.Result.Update(NewVendor);
                await db.Result.SaveChangesAsync();
            }
        }

        public async Task<List<Vendor>> GetAllVendorAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            var result = db.Vendor.ToListAsync();

            return await result;
        }
        public async Task<Vendor> GetVendorById(int Id)
        {
            using var db = await _factory.CreateDbContextAsync();

            var result = await db.Vendor.FirstOrDefaultAsync(u => u.Id == Id);

            return result;
        }

        public async Task DeleteVendorAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var vendor = await db.Result.Vendor.FirstOrDefaultAsync(s => s.Id == id);
            if (vendor != null)
            {
                db.Result.Remove(vendor);
                await db.Result.SaveChangesAsync();
            }
        }
    }
}
