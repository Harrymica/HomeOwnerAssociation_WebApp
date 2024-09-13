using HomeOwnerAssociation_WebApp.Data;
using Microsoft.EntityFrameworkCore;
using HomeOwnerAssociation_WebApp.Models;

namespace HomeOwnerAssociation_WebApp.Services.PropertyOwnersRepo
{
    public class PropertyOwnerService : IPropertyOwnerService
    {

        private readonly IDbContextFactory<ApplicationDbContext> _factory;


        public PropertyOwnerService(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;

        }

        public async Task AddPropOwner(PropertyOwners owners)
        {
            using var db = await _factory.CreateDbContextAsync();

            db.Add(owners);
            await db.SaveChangesAsync();
        }

        public async Task EditOwner(PropertyOwners owners)
        {
            using var db = _factory.CreateDbContextAsync();
            var Newproperty = await db.Result.PropertyOwners.FirstOrDefaultAsync(s => s.Id == owners.Id);
            if (Newproperty != null)
            {
                Newproperty.FullName = owners.FullName;
                Newproperty.Address = owners.Address;
                Newproperty.Email = owners.Email;
                Newproperty.Phone = owners.Phone;
               // Newproperty.PropertyId = owners.PropertyId;



                db.Result.Update(Newproperty);
                await db.Result.SaveChangesAsync();
            }
        }

        public async Task<List<PropertyOwners>> GetAllOwnersAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            var result = db.PropertyOwners.ToListAsync();

            return await result;
        }
        public async Task<PropertyOwners> GetOwnerById(int Id)
        {
            using var db = await _factory.CreateDbContextAsync();

            var result = await db.PropertyOwners.FirstOrDefaultAsync(u => u.Id == Id);

            return result;
        }

        public async Task DeleteOwnerAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var owner = await db.Result.PropertyOwners.FirstOrDefaultAsync(s => s.Id == id);
            if (owner != null)
            {
                db.Result.Remove(owner);
                await db.Result.SaveChangesAsync();
            }
        }
    }
}
