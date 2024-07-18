using Microsoft.EntityFrameworkCore;
using TirelireWebApp.Data;
using Microsoft.AspNetCore.Identity;
using TirelireWebApp.Models;
using Microsoft.AspNetCore.Identity.UI.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//SQLServer
builder.Services.AddDbContext<TirelireContext>(Options =>
	Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStringDataTirelire")));


//Ajout le rôle et identityUser lors d'ajout Identity 
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<TirelireContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

//Ajouter les pages Razor Login/register
builder.Services.AddRazorPages();
builder.Services.AddScoped<IEmailSender, EmailSender>();
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
app.UseAuthentication(); //auth avant autorisation 
app.UseAuthorization();
app.MapRazorPages(); //mapper les pages Razor

app.MapControllerRoute(
	name: "default",
    
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
