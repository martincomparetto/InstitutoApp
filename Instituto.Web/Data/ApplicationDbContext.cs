using Instituto.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Instituto.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<Empresa>()
        //        .HasIndex(x => x.CUIT)
        //        .IsUnique();

        //    builder
        //        .Entity<Menu>()
        //        .HasMany(x => x.AccessRoles)
        //        .WithOne();
        //}

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Empresa> Empresas { get; set; }




        public DbSet<Formato> Formatos { get; set; }
        public DbSet<Vinilo> Vinilos { get; set; }
        public DbSet<CompactDisk> CDs { get; set; }
        public DbSet<Cassete> Cassetes { get; set; }
    }
}
