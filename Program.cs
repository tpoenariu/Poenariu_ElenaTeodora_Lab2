using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Poenariu_ElenaTeodora_Lab2.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options => 
{
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
});

builder.Services.AddDbContext<Poenariu_ElenaTeodora_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Poenariu_ElenaTeodora_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Poenariu_ElenaTeodora_Lab2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Poenariu_ElenaTeodora_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Poenariu_ElenaTeodora_Lab2Context' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
