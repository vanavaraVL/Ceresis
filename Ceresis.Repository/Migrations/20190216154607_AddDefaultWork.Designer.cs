﻿// <auto-generated />
using System;
using Ceresis.Repository.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Ceresis.Repository.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190216154607_AddDefaultWork")]
    partial class AddDefaultWork
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.0.0-preview.18572.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Ceresis.Repository.Models.LogoType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("logo_types");
                });

            modelBuilder.Entity("Ceresis.Repository.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "1f189579-4ace-45e4-a305-7ee82a2426e2",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Ceresis.Repository.Models.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("role_claims");
                });

            modelBuilder.Entity("Ceresis.Repository.Models.SplitHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EnergoEfficienty");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Model");

                    b.Property<double>("Noise");

                    b.Property<string>("Power");

                    b.Property<string>("PowerRealty");

                    b.Property<double>("Price");

                    b.Property<string>("SizeExternal");

                    b.Property<string>("SizeInternal");

                    b.HasKey("Id");

                    b.ToTable("split_houses");
                });

            modelBuilder.Entity("Ceresis.Repository.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Ceresis.Repository.Models.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_claims");
                });

            modelBuilder.Entity("Ceresis.Repository.Models.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("user_logins");
                });

            modelBuilder.Entity("Ceresis.Repository.Models.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("user_roles");
                });

            modelBuilder.Entity("Ceresis.Repository.Models.UserToken", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("user_tokens");
                });

            modelBuilder.Entity("Ceresis.Repository.Models.WindowPlastic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Feature");

                    b.Property<bool>("HasSetup");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<string>("Size");

                    b.Property<double>("Total");

                    b.HasKey("Id");

                    b.ToTable("window_plastics");
                });

            modelBuilder.Entity("Ceresis.Repository.Models.WorkExample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ImageName");

                    b.Property<string>("ImagePath");

                    b.HasKey("Id");

                    b.ToTable("work_examples");
                });

            modelBuilder.Entity("Ceresis.Repository.Models.WorkPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ContactPrice");

                    b.Property<bool>("ExactPrice");

                    b.Property<string>("Name");

                    b.Property<double?>("Price");

                    b.Property<string>("Unity");

                    b.HasKey("Id");

                    b.ToTable("work_prices");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Монтаж настенной сплит-системы (модель 07, 09) до 2.8КВт",
                            Price = 4000.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -2,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Монтаж настенной сплит-системы (модель 12) до 3.5КВт",
                            Price = 4500.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -3,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Монтаж настенной сплит-системы (модель 18) до 5.5КВт",
                            Price = 5500.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -4,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Монтаж настенной сплит-системы (модель 24) до 7.0КВт",
                            Price = 6000.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -5,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Монтаж настенной сплит-системы (модель 36) свыше 7.0КВт",
                            Price = 7000.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -6,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Монтаж мульти-сплит-системы с двумя внутреннеми блоками",
                            Price = 8000.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -7,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Монтаж мульти-сплит-системы с тремя внутреннеми блоками",
                            Price = 12000.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -8,
                            ContactPrice = true,
                            ExactPrice = false,
                            Name = "Монтаж кассетных, канальных, напольно-потолочных, колонных и др. сплит-систем",
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -9,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Техническое обслуживание оконного кондиционера",
                            Price = 1500.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -10,
                            ContactPrice = false,
                            ExactPrice = true,
                            Name = "Техническое обслуживание настенной сплит-системы (модель 07, 09) до 2.8КВт",
                            Price = 1200.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -11,
                            ContactPrice = false,
                            ExactPrice = true,
                            Name = "Техническое обслуживание настенной сплит-системы (модель 12) до 3.5КВт",
                            Price = 1500.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -12,
                            ContactPrice = false,
                            ExactPrice = true,
                            Name = "Техническое обслуживание настенной сплит-системы (модель 18) до 5.5КВт",
                            Price = 2000.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -13,
                            ContactPrice = false,
                            ExactPrice = true,
                            Name = "Техническое обслуживание настенной сплит-системы (модель 24) до 7.0КВт",
                            Price = 2500.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -14,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Техническое обслуживание настенной сплит-системы (модель 07, 09) свыше 7.0КВт",
                            Price = 3000.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -15,
                            ContactPrice = true,
                            ExactPrice = false,
                            Name = "Техническое обслуживание кассетных, канальных, напольно-потолочных, колонных и др. сплит-систем",
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -16,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Демонтаж оконного кондиционера",
                            Price = 1000.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -17,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Демонтаж настенной сплит-системы (модель 07, 09) до 2.8КВт",
                            Price = 1200.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -18,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Демонтаж настенной сплит-системы (модель 12) до 3.5КВт",
                            Price = 1500.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -19,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Демонтаж настенной сплит-системы (модель 18) до 5.5КВт",
                            Price = 2000.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -20,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Демонтаж настенной сплит-системы (модель 24) до 7.0КВт",
                            Price = 2500.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -21,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Демонтаж настенной сплит-системы (модель 36) свыше 7.0КВт",
                            Price = 3000.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -22,
                            ContactPrice = false,
                            ExactPrice = false,
                            Name = "Диагностика неисправности сплит-системы",
                            Price = 700.0,
                            Unity = "шт"
                        },
                        new
                        {
                            Id = -23,
                            ContactPrice = false,
                            ExactPrice = true,
                            Name = "Дополнительная межблочная коммуникация (для систем 07 и 09)",
                            Price = 500.0,
                            Unity = "м"
                        });
                });

            modelBuilder.Entity("Ceresis.Repository.Models.RoleClaim", b =>
                {
                    b.HasOne("Ceresis.Repository.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ceresis.Repository.Models.UserClaim", b =>
                {
                    b.HasOne("Ceresis.Repository.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ceresis.Repository.Models.UserLogin", b =>
                {
                    b.HasOne("Ceresis.Repository.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ceresis.Repository.Models.UserRole", b =>
                {
                    b.HasOne("Ceresis.Repository.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ceresis.Repository.Models.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ceresis.Repository.Models.UserToken", b =>
                {
                    b.HasOne("Ceresis.Repository.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
