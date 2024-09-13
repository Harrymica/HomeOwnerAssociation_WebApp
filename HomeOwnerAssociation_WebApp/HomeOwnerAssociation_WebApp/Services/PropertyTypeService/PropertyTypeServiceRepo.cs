using HomeOwnerAssociation_WebApp.Data;
using HomeOwnerAssociation_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeOwnerAssociation_WebApp.Services.PropertyTypeService
{
    public class PropertyTypeServiceRepo : IPropertyTypeServiceRepo
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public PropertyTypeServiceRepo(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public async Task AddPropertiesType(PropertyType propertytype)
        {
            using var db = await _factory.CreateDbContextAsync();

            db.PropertyTypes.Add(propertytype);
            await db.SaveChangesAsync();
        }

        public async Task EdithPropertiesType(PropertyType propertytype)
        {
            using var db = _factory.CreateDbContextAsync();
            var Newproperty = await db.Result.PropertyTypes.FirstOrDefaultAsync(s => s.Id == propertytype.Id);
            if (Newproperty != null)
            {
                Newproperty.MonthlyFee = propertytype.MonthlyFee;
                Newproperty.UnitType = propertytype.UnitType;


                db.Result.Update(Newproperty);
                await db.Result.SaveChangesAsync();
            }
        }

        public async Task<List<PropertyType>> GetAllPropertiresTypeAsync()
        {
            using var db = await _factory.CreateDbContextAsync();
            var result = db.PropertyTypes.ToListAsync();

            return await result;
        }

        public async Task<PropertyType> GetPropertyTypeById(int Id)
        {
            using var db = await _factory.CreateDbContextAsync();

            var result = await db.PropertyTypes.FirstOrDefaultAsync(u => u.Id == Id);

            return result;
        }

        public async Task DeletePropertyTypeAsync(int id)
        {
            using var db = _factory.CreateDbContextAsync();
            var propertieType = await db.Result.PropertyTypes.FirstOrDefaultAsync(s => s.Id == id);
            if (propertieType != null)
            {
                db.Result.Remove(propertieType);
                await db.Result.SaveChangesAsync();
            }
        }
    }
}
