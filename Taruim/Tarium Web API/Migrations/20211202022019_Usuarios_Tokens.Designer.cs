﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tarium_Web_API.Contexts.TariumMainDB;

namespace Tarium_Web_API.Migrations
{
    [DbContext(typeof(TariumMainDB_Context))]
    [Migration("20211202022019_Usuarios_Tokens")]
    partial class Usuarios_Tokens
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

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

                    b.HasKey("Id")
                        .HasName("PK_Usuarios");

                    b.HasIndex("Correo")
                        .IsUnique()
                        .HasDatabaseName("UNQ_Usuarios_Correo");

                    b.HasIndex("Nombre")
                        .HasDatabaseName("IND_Usuarios_Nombre");

                    b.ToTable("Usuarios");
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
#pragma warning restore 612, 618
        }
    }
}
