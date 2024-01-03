using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectSupplyManagement.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MVCDemoDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcDemoConnectionString")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<MVCDemoDbContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    if (!await roleManager.RoleExistsAsync("Vendor"))
    {
        await roleManager.CreateAsync(new IdentityRole("Vendor"));
    }

    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }
}

// Configure Identity middleware
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipelineF
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "adminLogin",
        pattern: "Admin/Login",
        defaults: new { controller = "Admin", action = "Login" });

    // Add this route for Admin/ApproveOrReject
    endpoints.MapControllerRoute(
        name: "approveOrReject",
        pattern: "Admin/ApproveOrReject/{id?}/{isApproved?}",
        defaults: new { controller = "Admin", action = "ApproveOrReject" });
});

app.Run();
