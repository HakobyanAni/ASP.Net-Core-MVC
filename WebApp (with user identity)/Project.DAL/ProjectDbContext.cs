using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;

namespace Project.DAL
{
    public class ProjectDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)   { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole<int>>().ToTable("Roles");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");

            //builder.Entity<UserEntity>().ToTable("Users")
            //  .HasOne(u => u.Client)
            //  .WithMany(c => c.Users)
            //  .HasForeignKey(x => x.ClientId);
        }

        public virtual DbSet<ClientEntity> Clients { get; set; }

    }
}
