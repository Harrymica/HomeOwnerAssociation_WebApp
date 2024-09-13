using HomeOwnerAssociation_WebApp.Data;
using HomeOwnerAssociation_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeOwnerAssociation_WebApp.Services.PropertyService
{
    public class PropertyServiceRepo : IPropertyServiceRepo
    {

        private readonly IDbContextFactory<ApplicationDbContext> _factory;
        

        public PropertyServiceRepo(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
           
        }

        public async Task AddProperties(Property property)
        {
            using var db = await _factory.CreateDbContextAsync();

            db.Add(property);
            await db.SaveChangesAsync();
        }

        public async Task EdithProperties(Property property)
        {
            using var db = _factory.CreateDbContextAsync();
            var Newproperty = await db.Result.Properties.FirstOrDefaultAsync(s => s.Id == property.Id);
            if (Newproperty != null)
            {
                Newproperty.Name = property.Name;
                Newproperty.Address = property.Address;
                Newproperty.Location = property.Location;
                Newproperty.Units = property.Units;
                Newproperty.Logo = property.Logo;
                Newproperty.PropertyTypeId = property.PropertyTypeId;

                db.Result.Update(Newproperty);
                await db.Result.SaveChangesAsync();
            }
        }

        public async Task<List<Property>> GetAllPropertiresAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            var result = db.Properties.ToListAsync();

            return await result;
        }
        public async Task<Property> GetPropertyById(int Id)
        {
            using var db = await _factory.CreateDbContextAsync();

            var result = await db.Properties.FirstOrDefaultAsync(u => u.Id == Id);

            return result;
        }

        public async Task DeletePropertyAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var propertied = await db.Result.Properties.FirstOrDefaultAsync(s => s.Id == id);
            if (propertied != null)
            {
                db.Result.Remove(propertied);
                await db.Result.SaveChangesAsync();
            }
        }
    }
}
