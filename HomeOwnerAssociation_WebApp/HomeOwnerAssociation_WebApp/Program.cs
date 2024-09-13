using Blazored.Toast;
using HomeOwnerAssociation_WebApp.Client.Pages;
using HomeOwnerAssociation_WebApp.Components;
using HomeOwnerAssociation_WebApp.Components.Account;
using HomeOwnerAssociation_WebApp.Data;
using HomeOwnerAssociation_WebApp.Services.Bank_AccountRepo;
using HomeOwnerAssociation_WebApp.Services.BoardRepistory;
using HomeOwnerAssociation_WebApp.Services.BudgetingRepository;
using HomeOwnerAssociation_WebApp.Services.CommiteeService;
using HomeOwnerAssociation_WebApp.Services.DeedsRepo;
using HomeOwnerAssociation_WebApp.Services.ExceptionalBudgetingRepositry;
using HomeOwnerAssociation_WebApp.Services.FeesRepo;
using HomeOwnerAssociation_WebApp.Services.HOA_Service;
using HomeOwnerAssociation_WebApp.Services.MaintenanceRepo;
using HomeOwnerAssociation_WebApp.Services.PropertyOwnersRepo;
using HomeOwnerAssociation_WebApp.Services.PropertyService;
using HomeOwnerAssociation_WebApp.Services.PropertyTypeService;
using HomeOwnerAssociation_WebApp.Services.VendorRepo;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HomeOwnerAssociation_WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //Register all Service Repository
            builder.Services.AddScoped<IComiteeServiceRespository, ComiteeServiceRespository>();
            builder.Services.AddScoped<IBoardMemberRepositoryService, BoardMemberRepositoryService>();
            builder.Services.AddScoped<IBudgetingRepositoryService, BudgetingRepositoryService>();
            builder.Services.AddScoped<IExceptionalBudgetingService, ExceptionalBudgetingService>();
            builder.Services.AddScoped<IHOA_Repository, HOA_Repository>();
            builder.Services.AddScoped<IPropertyServiceRepo, PropertyServiceRepo>();
            builder.Services.AddScoped<IPropertyTypeServiceRepo, PropertyTypeServiceRepo>();
            builder.Services.AddScoped<IPropertyOwnerService, PropertyOwnerService>();
            builder.Services.AddScoped<IFeesService, FeesService>();
            builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();
            builder.Services.AddScoped<IVendorService, VendorService>();
            builder.Services.AddScoped<IBank_AccountService, Bank_AccountService>();
            builder.Services.AddScoped<IDeedsService, DeedsService>();


            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddBlazoredToast();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddIdentityCookies();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
            builder.Services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("Role", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
            });

            //Hash password
            //UserManager<ApplicationUser> userManager;

            //var adminUser = userManager.FindByIdAsync("1").Result;
            //if (adminUser != null)
            //{
            //    var passwordHasher = new PasswordHasher<ApplicationUser>();
            //    adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin@007");
            //    userManager.UpdateAsync(adminUser).Wait();
            //}

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();

            app.Run();
        }

        
    }
}
