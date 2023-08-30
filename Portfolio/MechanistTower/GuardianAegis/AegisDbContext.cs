using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.MechanistTower.Configurations;

namespace Portfolio.MechanistTower.GuardianAegis
{
    public class AegisDbContext : IdentityDbContext<IdentityUser>
    {
        private IConfigurationSigils ConfigurationSigils { get; }

        public AegisDbContext(IConfigurationSigils configurationSigils, DbContextOptions<AegisDbContext> options)
            : base(options)
        {
            ConfigurationSigils = configurationSigils;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var user = ConjureWizard();

            modelBuilder.Entity<IdentityUser>().HasData(user);
        }

        private IdentityUser ConjureWizard()
        {
            var adminName = ConfigurationSigils.AdminUserName;
            var adminPass = ConfigurationSigils.AdminPassword;
            var userId = Guid.NewGuid().ToString();

            var hasher = new PasswordHasher<IdentityUser>();

            var user = new IdentityUser()
            {
                Id = userId,
                UserName = adminName,
                NormalizedUserName = adminName.ToUpper(),
                EmailConfirmed = true
            };

            var password = hasher.HashPassword(user, adminPass);
            user.PasswordHash = password;

            return user;
        }
    }
}