    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using ProjectSupplyManagement.Models.Domain;

    namespace ProjectSupplyManagement.Data
    {
        public class MVCDemoDbContext : IdentityDbContext<IdentityUser>
        {
            public MVCDemoDbContext(DbContextOptions<MVCDemoDbContext> options) : base(options)
            {
            }

            public DbSet<Employee> Employees { get; set; }
		    public DbSet<Vendor> Vendors { get; set; }
            public DbSet<IdentityRole> IdentityRoles { get; set; }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

                // Configure the IdentityRole entity
                builder.Entity<IdentityRole>().HasData(
                    new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Name = "Vendor", NormalizedName = "VENDOR" }
                );
            }

        }
    }
