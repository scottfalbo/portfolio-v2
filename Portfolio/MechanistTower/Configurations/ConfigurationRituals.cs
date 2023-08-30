using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Portfolio.MechanistTower.GuardianAegis;
using Portfolio.MechanistTower.Manipulators;
using Portfolio.MechanistTower.Scryers;
using Portfolio.MechanistTower.SpellChanters;
using Portfolio.MechanistTower.Tomes;

namespace Portfolio.MechanistTower.Configurations
{
    public static class ConfigurationRituals
    {
        public static void TuningRune(WebApplicationBuilder builder, IConfiguration configuration)
        {
            var configurationSigils = InvokeConfigurationSigils(builder, configuration);

            ConfigureScryer(builder, configurationSigils);
            SecureAegis(builder);
            AttuneViewingCrystal(builder);
            ConfigureEchoVault(builder, configurationSigils);
            TetherTransients(builder);
        }

        public static void ImbueConstruct(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AegisDbContext>();
                dbContext.Database.Migrate();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
        }

        private static void TetherTransients(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IGuardianSentinel, GuardianSentinel>();
            builder.Services.AddTransient<IFleshRiteChanters, FleshRiteChanters>();
            builder.Services.AddTransient<IFleshRitesTome, FleshRitesTome>();
            builder.Services.AddTransient<IIllustrationChanters, IllustrationChanters>();
            builder.Services.AddTransient<IIllustrationsTome, IllustrationsTome>();
            builder.Services.AddTransient<IEchoKeeperChanter, EchoKeeperChanter>();
            builder.Services.AddTransient<IEchoShaper, EchoShaper>();
        }

        private static void SecureAegis(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AegisDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AegisDbContext>();
        }

        private static ConfigurationSigils InvokeConfigurationSigils(WebApplicationBuilder builder, IConfiguration configuration)
        {
            var keyVaultUri = configuration["KeyVaultUri"];

            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets(builder.Environment.ApplicationName)
                .AddAzureKeyVault(new Uri(keyVaultUri), new DefaultAzureCredential());

            var configurationSigils = new ConfigurationSigils();
            builder.Configuration.Bind(configurationSigils);

            builder.Services.AddSingleton<IConfigurationSigils>(configurationSigils);
            return configurationSigils;
        }

        private static void AttuneViewingCrystal(WebApplicationBuilder builder)
        {
            // TODO: Remove AddRazorRuntimeCompilation() after development
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        private static void ConfigureScryer(WebApplicationBuilder builder, ConfigurationSigils configurationSigils)
        {
            var cosmosEndpoint = configurationSigils.CosmosEndpoint;
            var cosmosKey = configurationSigils.CosmosKey;
            var cosmosClient = new CosmosClient(cosmosEndpoint, cosmosKey);

            builder.Services.AddSingleton<ICosmosTomeScryer>(
                new CosmosTomeScryer(cosmosClient));
        }

        private static void ConfigureEchoVault(WebApplicationBuilder builder, ConfigurationSigils configurationSigils)
        {
            builder.Services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(configurationSigils.BlobConnectionString);
            });
        }
    }
}