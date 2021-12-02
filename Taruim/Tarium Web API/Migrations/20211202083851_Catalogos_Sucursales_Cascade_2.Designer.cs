﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tarium_Web_API.Contexts.TariumMainDB;

namespace Tarium_Web_API.Migrations
{
    [DbContext(typeof(TariumMainDB_Context))]
    [Migration("20211202083851_Catalogos_Sucursales_Cascade_2")]
    partial class Catalogos_Sucursales_Cascade_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Tarium_Web_API.Contexts.TariumMainDB.Models.Catalogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("Id_Producto")
                        .HasColumnType("int");

                    b.Property<int>("Id_Sucursal")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Catalogos");

                    b.HasIndex("Id_Producto");

                    b.HasIndex("Id_Sucursal");

                    b.ToTable("Catalogos");
                });

            modelBuilder.Entity("Tarium_Web_API.Contexts.TariumMainDB.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoBarra")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("FechaVencimiento")
                        .HasColumnType("datetime");

                    b.Property<int?>("Id_Proveedor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK_Productos");

                    b.HasIndex("CodigoBarra")
                        .HasDatabaseName("IND_Productos_CodigoBarra");

                    b.HasIndex("Id_Proveedor");

                    b.HasIndex("SKU")
                        .IsUnique()
                        .HasDatabaseName("UNQ_Productos_SKU");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Tarium_Web_API.Contexts.TariumMainDB.Models.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Contacto")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK_Proveedores");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("Tarium_Web_API.Contexts.TariumMainDB.Models.Sucursal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_Sucursales");

                    b.HasIndex("Nombre")
                        .IsUnique()
                        .HasDatabaseName("UNQ_Sucursales_Nombre");

                    b.ToTable("Sucursales");
                });

            modelBuilder.Entity("Tarium_Web_API.Contexts.TariumMainDB.Models.Token", b =>
                {
                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Id_Usuario")
                        .HasColumnType("int");

                    b.HasKey("Hash")
                        .HasName("PK_Tokens");

                    b.HasIndex("Id_Usuario");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("Tarium_Web_API.Contexts.TariumMainDB.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Usuarios");

                    b.HasIndex("Correo")
                        .IsUnique()
                        .HasDatabaseName("UNQ_Usuarios_Correo");

                    b.HasIndex("Nombre")
                        .HasDatabaseName("IND_Usuarios_Nombre");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Tarium_Web_API.Contexts.TariumMainDB.Models.Catalogo", b =>
                {
                    b.HasOne("Tarium_Web_API.Contexts.TariumMainDB.Models.Producto", null)
                        .WithMany()
                        .HasForeignKey("Id_Producto")
                        .HasConstraintName("FK_Catalogos_Productos")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Tarium_Web_API.Contexts.TariumMainDB.Models.Sucursal", null)
                        .WithMany("Catalogos")
                        .HasForeignKey("Id_Sucursal")
                        .HasConstraintName("FK_Catalogos_Sucursales")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tarium_Web_API.Contexts.TariumMainDB.Models.Producto", b =>
                {
                    b.HasOne("Tarium_Web_API.Contexts.TariumMainDB.Models.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("Id_Proveedor")
                        .HasConstraintName("FK_Productos_Proveedores")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Tarium_Web_API.Contexts.TariumMainDB.Models.Token", b =>
                {
                    b.HasOne("Tarium_Web_API.Contexts.TariumMainDB.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("Id_Usuario")
                        .HasConstraintName("FK_Tokens_Usuarios")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Tarium_Web_API.Contexts.TariumMainDB.Models.Sucursal", b =>
                {
                    b.Navigation("Catalogos");
                });
#pragma warning restore 612, 618
        }
    }
}
