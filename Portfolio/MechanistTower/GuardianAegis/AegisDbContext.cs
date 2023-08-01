using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.MechanistTower.Configurations;

namespace Portfolio.MechanistTower.GuardianAegis
{
    public class AegisDbContext : IdentityDbContext<WizardOverlord>
    {
        private ConfigurationSigils ConfigurationSigils { get; }

        public AegisDbContext(ConfigurationSigils configurationSigils, DbContextOptions<AegisDbContext> options)
            : base(options)
        {
            ConfigurationSigils = configurationSigils;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var adminName = ConfigurationSigils.AdminName;
            var adminPass = ConfigurationSigils.AdminPass;
            var adminEmail = ConfigurationSigils.AdminEmail;
            var userId = Guid.NewGuid().ToString();

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = userId,
                    UserName = adminName,
                    NormalizedUserName = adminName.ToUpper(),
                    Email = adminEmail,
                    NormalizedEmail = adminEmail,
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, adminPass),
                    SecurityStamp = string.Empty
                });
        }
    }
}