using LoginAuthMicroServices.DataAccess.Concrate;
using LoginAuthMicroServices.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LoginAuthMicroServices.DataAccess.EntityFaremework
{
    public class PgDbContext : DbContext
    {
        protected IConfiguration Configuration { get; }

        public PgDbContext(DbContextOptions<PgDbContext> options, IConfiguration configuration)
           : base(options)
        {
            Configuration = configuration;
        }
        protected PgDbContext(DbContextOptions options, IConfiguration configuration)
        : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging());

        }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
    }
}
