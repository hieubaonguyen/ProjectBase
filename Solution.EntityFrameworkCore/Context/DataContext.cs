using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Solution.Core.Authentication;
using Solution.Core.Authorization;
using Solution.Core.Shared.Kernel;
using Solution.EntityFrameworkCore.Authentication;
using Solution.EntityFrameworkCore.Authorization;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Solution.EntityFrameworkCore.Context
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Identity Config
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims").HasKey(a => a.Id);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims").HasKey(a => a.Id);
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(a => a.UserId);
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasKey(a => new { a.UserId, a.RoleId });
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(a => a.UserId);

            //Fluent API
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new ApplicationRoleConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            foreach (var item in modified)
            {
                var changeOrUpdateItem = item.Entity as IDateEntity;
                if (changeOrUpdateItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changeOrUpdateItem.DateCreated = DateTime.Now;
                    }
                    changeOrUpdateItem.DateModified = DateTime.Now;
                }
            }
            return base.SaveChangesAsync();
        }
    }
}
