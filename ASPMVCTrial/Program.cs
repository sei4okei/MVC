using ASPMVCTrial.Data.Interfaces;
using ASPMVCTrial.Data;
using ASPMVCTrial.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ASPMVCTrial.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using ASPMVCTrial.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDealService, DealService>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.Configure<CloudinarySettings>(builder.Configuration
    .GetSection("CloudinarySettings"));

builder.Services.AddDbContext<ApplicationContext>(options =>
        options.UseMySql(builder.Configuration
        .GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 11))
    ));

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Deal}/{action=Index}/{id?}");

app.Run();
