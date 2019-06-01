using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DataAccessLayer.Entities;

namespace DataAccessLayer
{
    public class DBContext : IdentityDbContext<IdentityUser> 
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<UserEntity> UserTable { get; set; }
        public virtual DbSet<ClientEntity> ClientTable { get; set; }
    }
}
