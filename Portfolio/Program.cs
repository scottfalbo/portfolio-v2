using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.MechanistTower.Configurations;
using Portfolio.MechanistTower.GuardianAegis;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var configurationSigils = ConfigurationRitual.Invoke(configuration);
builder.Services.AddSingleton(configurationSigils);

builder.Services.AddTransient<IGuardianSentinel, GuardianSentinel>();

// TODO: Remove AddRazorRuntimeCompilation() after development
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<AegisDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<WizardOverlord>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AegisDbContext>();

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