using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HamzilahFoods.Data;
using Microsoft.AspNetCore.Identity;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddDbContext<HamzilahFoodsContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("HamzilahFoodsContext") ?? throw new InvalidOperationException("Connection string 'HamzilahFoodsContext' not found.")));

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<HamzilahFoodsContext>()
            .AddRoles<IdentityRole>()
            .AddDefaultTokenProviders();

        IServiceCollection serviceCollection = builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = new PathString("/Account/Login");
            options.AccessDeniedPath = new PathString("/Account/AccessDenied");
            options.LogoutPath = new PathString("/index");
        });


        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminPolicy",
            policy => policy.RequireRole("Admin"));
        });
        builder.Services.AddRazorPages(options =>
        {
            options.Conventions.AuthorizeFolder("/Admin", "AdminPolicy");
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
   
    }
}