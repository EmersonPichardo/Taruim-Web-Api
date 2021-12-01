using Microsoft.EntityFrameworkCore;
using Tarium_Web_API.Contexts.TariumMainDB.Models;

namespace Tarium_Web_API.Contexts.TariumMainDB
{
    public class TariumMainDB_Context : DbContext
    {
        public DbSet<Sucursal> Sucursales { get; set; }

        public TariumMainDB_Context(DbContextOptions<TariumMainDB_Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<Sucursal>().ToTable("Sucursales");

            // Configure Primary Keys  
            modelBuilder.Entity<Sucursal>().HasKey(ug => ug.Id).HasName("PK_Sucursales");

            // Configure indexes  
            modelBuilder.Entity<Sucursal>().HasIndex(sucursal => sucursal.Nombre).IsUnique().HasDatabaseName("UNQ_Sucursales_Nombre");

            // Configure columns  
            modelBuilder.Entity<Sucursal>().Property(sucursal => sucursal.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Sucursal>().Property(sucursal => sucursal.Nombre).HasColumnType("nvarchar(500)").IsRequired();
            modelBuilder.Entity<Sucursal>().Property(sucursal => sucursal.Tipo).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Sucursal>().Property(sucursal => sucursal.Estado).HasColumnType("nvarchar(50)").IsRequired();

            // Configure relationships  
            //modelBuilder.Entity<User>().HasOne<UserGroup>().WithMany().HasPrincipalKey(ug => ug.Id).HasForeignKey(u => u.UserGroupId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Users_UserGroups");
        }
    }
}
