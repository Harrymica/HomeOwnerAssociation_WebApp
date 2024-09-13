using HomeOwnerAssociation_WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HomeOwnerAssociation_WebApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // var context = serviceProvider.GetService<ApplicationDbContext>();
            // var user = new ApplicationUser();
            var Hash = new PasswordHasher<ApplicationUser>();//.HashPassword(user , "Admin@007");
            var adminUser = new ApplicationUser()
            {
                Id = "1",
                FullName = "Emmanuel Chinonso",
                Country = "Unknown",
                City = "Unknown",
                Address = "Unknown",
                PhoneNumber = "Unknown",
                UserName = "Admin007@gmail.com",
                NormalizedUserName = "ADMIN007@GMAIL.COM",
                Email = "Admin007@gmail.com",
                NormalizedEmail = "ADMIN007@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = Hash.HashPassword(null, "Admin@007"),

                //PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(new ApplicationUser(), "Admin@007")

            };

  
            //var passwordHasher = new PasswordHasher<ApplicationUser>();
            //adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin@007");



            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            modelBuilder.Entity<IdentityRole>().HasData(
                   new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                   new IdentityRole { Id = "2", Name = "HouseOwners", NormalizedName = "HOUSEOWNERS" }
                  
               );
            modelBuilder.Entity<PropertyType>().HasData(
                new PropertyType { Id = 1, UnitType = "Small Appartment", MonthlyFee=100.00m},
                new PropertyType { Id = 2, UnitType = "Big Appartment", MonthlyFee=540.00m},
                new PropertyType { Id = 3, UnitType = "Garage", MonthlyFee=1600.00m}
                
                );
            
            // Seed user roles
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = "1" }

            );

            modelBuilder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
            });

            modelBuilder.Entity<IdentityUserRole<string>>(b =>
            {
                b.HasKey(r => new { r.UserId, r.RoleId });
            });

            modelBuilder.Entity<IdentityUserToken<string>>(b =>
            {
                b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
            });

            modelBuilder.Entity<Property>()
            .HasOne(p => p.propertyOwner)
            .WithMany(po => po.Properties)
            .HasForeignKey(p => p.propertyOwnerId)
            .OnDelete(DeleteBehavior.Cascade);


        }

        public DbSet<BoardMember> BoardMembers { get; set; }
        public DbSet<Budgeting> Budgetings { get; set; }
        public DbSet<Commitee> Commitees { get; set; }
        public DbSet<ExeptionalBudgeting> ExeptionalBudgetings { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<HOA> HOA { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyOwners> PropertyOwners { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Rule> Rule { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<WorkOrder> WorkOrder { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<MaintenanceHistory> Maintenances { get; set; }
        public DbSet<DeedRestriction> DeedRestrictions { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

    }
}
