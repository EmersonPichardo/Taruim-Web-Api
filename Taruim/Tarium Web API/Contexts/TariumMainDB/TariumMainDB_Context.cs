using Microsoft.EntityFrameworkCore;
using Tarium_Web_API.Contexts.TariumMainDB.Models;

namespace Tarium_Web_API.Contexts.TariumMainDB
{
    public class TariumMainDB_Context : DbContext
    {
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public TariumMainDB_Context(DbContextOptions<TariumMainDB_Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure

            // Map entities to tables
            modelBuilder.Entity<Sucursal>().ToTable("Sucursales");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Token>().ToTable("Tokens");

            // Configure Primary Keys
            modelBuilder.Entity<Sucursal>().HasKey(sucursal => sucursal.Id).HasName("PK_Sucursales");
            modelBuilder.Entity<Usuario>().HasKey(usuario => usuario.Id).HasName("PK_Usuarios");
            modelBuilder.Entity<Token>().HasKey(token => token.Hash).HasName("PK_Tokens");

            // Configure indexes
            modelBuilder.Entity<Sucursal>().HasIndex(sucursal => sucursal.Nombre).IsUnique().HasDatabaseName("UNQ_Sucursales_Nombre");
            modelBuilder.Entity<Usuario>().HasIndex(usuario => usuario.Nombre).HasDatabaseName("IND_Usuarios_Nombre");
            modelBuilder.Entity<Usuario>().HasIndex(usuario => usuario.Correo).IsUnique().HasDatabaseName("UNQ_Usuarios_Correo");

            // Configure columns
            modelBuilder.Entity<Sucursal>().Property(sucursal => sucursal.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Sucursal>().Property(sucursal => sucursal.Nombre).HasColumnType("nvarchar(500)").IsRequired();
            modelBuilder.Entity<Sucursal>().Property(sucursal => sucursal.Tipo).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Sucursal>().Property(sucursal => sucursal.Estado).HasColumnType("nvarchar(50)").IsRequired();

            modelBuilder.Entity<Usuario>().Property(usuario => usuario.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Usuario>().Property(usuario => usuario.Nombre).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(usuario => usuario.Correo).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(usuario => usuario.Clave).HasColumnType("nvarchar(500)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(usuario => usuario.Rol).HasColumnType("int").IsRequired();

            modelBuilder.Entity<Token>().Property(token => token.Hash).HasColumnType("nvarchar(500)").IsRequired();
            modelBuilder.Entity<Token>().Property(token => token.Id_Usuario).HasColumnType("int").IsRequired();

            // Configure relationships  
            modelBuilder.Entity<Token>().HasOne<Usuario>().WithMany().HasPrincipalKey(usuario => usuario.Id).HasForeignKey(token => token.Id_Usuario).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Tokens_Usuarios");
        }
    }
}
