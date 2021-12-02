using Microsoft.EntityFrameworkCore;
using Tarium_Web_API.Contexts.TariumMainDB.Models;

namespace Tarium_Web_API.Contexts.TariumMainDB
{
    public class TariumMainDB_Context : DbContext
    {
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }

        public TariumMainDB_Context(DbContextOptions<TariumMainDB_Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure

            // Map entities to tables
            modelBuilder.Entity<Sucursal>().ToTable("Sucursales");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Token>().ToTable("Tokens");
            modelBuilder.Entity<Proveedor>().ToTable("Proveedores");
            modelBuilder.Entity<Producto>().ToTable("Productos");
            modelBuilder.Entity<Catalogo>().ToTable("Catalogos");
            modelBuilder.Entity<Transaccion>().ToTable("Transacciones");

            // Configure Primary Keys
            modelBuilder.Entity<Sucursal>().HasKey(sucursal => sucursal.Id).HasName("PK_Sucursales");
            modelBuilder.Entity<Usuario>().HasKey(usuario => usuario.Id).HasName("PK_Usuarios");
            modelBuilder.Entity<Token>().HasKey(token => token.Hash).HasName("PK_Tokens");
            modelBuilder.Entity<Proveedor>().HasKey(proveedor => proveedor.Id).HasName("PK_Proveedores");
            modelBuilder.Entity<Producto>().HasKey(producto => producto.Id).HasName("PK_Productos");
            modelBuilder.Entity<Catalogo>().HasKey(catalogo => catalogo.Id).HasName("PK_Catalogos");
            modelBuilder.Entity<Transaccion>().HasKey(transaccion => transaccion.Id).HasName("PK_Transacciones");

            // Configure indexes
            modelBuilder.Entity<Sucursal>().HasIndex(sucursal => sucursal.Nombre).IsUnique().HasDatabaseName("UNQ_Sucursales_Nombre");
            modelBuilder.Entity<Usuario>().HasIndex(usuario => usuario.Nombre).HasDatabaseName("IND_Usuarios_Nombre");
            modelBuilder.Entity<Usuario>().HasIndex(usuario => usuario.Correo).IsUnique().HasDatabaseName("UNQ_Usuarios_Correo");
            modelBuilder.Entity<Producto>().HasIndex(producto => producto.SKU).IsUnique().HasDatabaseName("UNQ_Productos_SKU");
            modelBuilder.Entity<Producto>().HasIndex(producto => producto.CodigoBarra).HasDatabaseName("IND_Productos_CodigoBarra");

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

            modelBuilder.Entity<Proveedor>().Property(proveedor => proveedor.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Proveedor>().Property(proveedor => proveedor.Nombre).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Proveedor>().Property(proveedor => proveedor.Contacto).HasColumnType("nvarchar(200)");
            modelBuilder.Entity<Proveedor>().Property(proveedor => proveedor.Estado).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Proveedor>().Property(proveedor => proveedor.Comentario).HasColumnType("nvarchar(1000)");

            modelBuilder.Entity<Producto>().Property(producto => producto.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Producto>().Property(producto => producto.SKU).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Producto>().Property(producto => producto.CodigoBarra).HasColumnType("nvarchar(100)");
            modelBuilder.Entity<Producto>().Property(producto => producto.Nombre).HasColumnType("nvarchar(200)").IsRequired();
            modelBuilder.Entity<Producto>().Property(producto => producto.FechaVencimiento).HasColumnType("datetime");
            modelBuilder.Entity<Producto>().Property(producto => producto.Id_Proveedor).HasColumnType("int");
            modelBuilder.Entity<Producto>().Property(producto => producto.Comentario).HasColumnType("nvarchar(1000)");
            modelBuilder.Entity<Producto>().Property(producto => producto.Estado).HasColumnType("nvarchar(50)").IsRequired();

            modelBuilder.Entity<Catalogo>().Property(catalogo => catalogo.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Catalogo>().Property(catalogo => catalogo.Id_Sucursal).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Catalogo>().Property(catalogo => catalogo.Id_Producto).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Catalogo>().Property(catalogo => catalogo.Cantidad).HasColumnType("int").IsRequired();

            modelBuilder.Entity<Transaccion>().Property(transaccion => transaccion.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Transaccion>().Property(transaccion => transaccion.Tipo).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Transaccion>().Property(transaccion => transaccion.Id_Producto).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Transaccion>().Property(transaccion => transaccion.Cantidad).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Transaccion>().Property(transaccion => transaccion.Costo).HasColumnType("decimal").IsRequired();

            // Configure relationships  
            modelBuilder.Entity<Token>().HasOne<Usuario>().WithMany().HasPrincipalKey(usuario => usuario.Id).HasForeignKey(token => token.Id_Usuario).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Tokens_Usuarios");
            modelBuilder.Entity<Producto>().HasOne(producto => producto.Proveedor).WithMany().HasPrincipalKey(proveedor => proveedor.Id).HasForeignKey(producto => producto.Id_Proveedor).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Productos_Proveedores");
            modelBuilder.Entity<Catalogo>().HasOne(catalogo => catalogo.Producto).WithMany().HasPrincipalKey(producto => producto.Id).HasForeignKey(catalogo => catalogo.Id_Producto).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Catalogos_Productos");
            modelBuilder.Entity<Sucursal>().HasMany(sucursal => sucursal.Catalogos).WithOne().HasPrincipalKey(sucursal => sucursal.Id).HasForeignKey(catalogo => catalogo.Id_Sucursal).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Catalogos_Sucursales");
            modelBuilder.Entity<Transaccion>().HasOne(transaccion => transaccion.Sucursal).WithMany().HasPrincipalKey(sucursal => sucursal.Id).HasForeignKey(transaccion => transaccion.Id_Sucursal).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Transacciones_Sucursal");
            modelBuilder.Entity<Transaccion>().HasOne(transaccion => transaccion.Producto).WithMany().HasPrincipalKey(producto => producto.Id).HasForeignKey(transaccion => transaccion.Id_Producto).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Transacciones_Productos");
        }
    }
}
