using parcial2.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EnterpriseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("EnterpriseContext") ?? throw new InvalidOperationException("Connection string 'EnterpriseContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => 
options.SignIn.RequireConfirmedAccount = true)
.AddEntityFrameworkStores<EnterpriseContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IFootwearService, FootwearService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
