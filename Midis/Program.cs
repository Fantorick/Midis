using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Midis.Abstract;
using Midis.Data;
using Midis.DataAccessLayer;
using Midis.Domains;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Builder;
using Midis.BlazorServices;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Midis.Blazor;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddIdentity<UserMidis, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
        }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI().AddDefaultTokenProviders();

        builder.Services.AddTransient<IRepository<Item>, SqlRepository<Item>>();
        builder.Services.AddTransient<IRepository<NumberGroup>, SqlRepository<NumberGroup>>();
        builder.Services.AddTransient<IRepository<UserGroup>, UserGroupSqlRepository>(); //ScheduleSqlRepository
        builder.Services.AddTransient<IRepository<Schedule>, ScheduleSqlRepository>();
        builder.Services.AddTransient<IRepository<UserMidis>, TeacherSqlRepository>();
        builder.Services.AddTransient<ContentService>();
        builder.Services.AddTransient<UserContentService>();
        builder.Services.AddControllersWithViews();
        builder.Services.AddServerSideBlazor();
        var app = builder.Build();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.MapBlazorHub();
        app.UseAuthorization();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();
        using (var scope = app.Services.CreateAsyncScope())
        {
            var dataSeeder = new DataSeeder();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserMidis>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await dataSeeder.Seed(userManager, roleManager);
        }
        app.Run();
    }
}