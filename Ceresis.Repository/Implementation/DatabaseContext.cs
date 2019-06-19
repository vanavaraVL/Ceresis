using Ceresis.Repository.Infrastructure;
using Ceresis.Repository.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ceresis.Repository.Implementation
{
    public class DatabaseContext :
        IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IDatabaseContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WorkExample> WorkExamples { get; set; }

        public DbSet<WindowPlastic> WindowPlastics { get; set; }

        public DbSet<SplitHouse> SplitHouse { get; set; }

        public DbSet<LogoType> LogoTypes { get; set; }

        public DbSet<WorkPrice> WorkPrices { get; set; }

        public DbSet<T> GetDbSet<T>() where T : class
        {
            return Set<T>();
        }

        public ChangeTracker GetChangeTracker()
        {
            return ChangeTracker;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder().UseNpgsql(connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SystemSetup(builder);
            SeedSetup(builder);
        }

        public static void SeedSetup(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString("D")
                });

            #region Works

            builder.Entity<WorkPrice>().HasData(
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -1,
                    ExactPrice = false,
                    Name = "Монтаж настенной сплит-системы (модель 07, 09) до 2.8КВт",
                    Price = 4000,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -2,
                    ExactPrice = false,
                    Name = "Монтаж настенной сплит-системы (модель 12) до 3.5КВт",
                    Price = 4500,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -3,
                    ExactPrice = false,
                    Name = "Монтаж настенной сплит-системы (модель 18) до 5.5КВт",
                    Price = 5500,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -4,
                    ExactPrice = false,
                    Name = "Монтаж настенной сплит-системы (модель 24) до 7.0КВт",
                    Price = 6000,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -5,
                    ExactPrice = false,
                    Name = "Монтаж настенной сплит-системы (модель 36) свыше 7.0КВт",
                    Price = 7000,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -6,
                    ExactPrice = false,
                    Name = "Монтаж мульти-сплит-системы с двумя внутреннеми блоками",
                    Price = 8000,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -7,
                    ExactPrice = false,
                    Name = "Монтаж мульти-сплит-системы с тремя внутреннеми блоками",
                    Price = 12000,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = true,
                    Id = -8,
                    ExactPrice = false,
                    Name = "Монтаж кассетных, канальных, напольно-потолочных, колонных и др. сплит-систем",
                    Price = null,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -9,
                    ExactPrice = false,
                    Name = "Техническое обслуживание оконного кондиционера",
                    Price = 1500,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -10,
                    ExactPrice = true,
                    Name = "Техническое обслуживание настенной сплит-системы (модель 07, 09) до 2.8КВт",
                    Price = 1200,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -11,
                    ExactPrice = true,
                    Name = "Техническое обслуживание настенной сплит-системы (модель 12) до 3.5КВт",
                    Price = 1500,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -12,
                    ExactPrice = true,
                    Name = "Техническое обслуживание настенной сплит-системы (модель 18) до 5.5КВт",
                    Price = 2000,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -13,
                    ExactPrice = true,
                    Name = "Техническое обслуживание настенной сплит-системы (модель 24) до 7.0КВт",
                    Price = 2500,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -14,
                    ExactPrice = false,
                    Name = "Техническое обслуживание настенной сплит-системы (модель 07, 09) свыше 7.0КВт",
                    Price = 3000,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = true,
                    Id = -15,
                    ExactPrice = false,
                    Name = "Техническое обслуживание кассетных, канальных, напольно-потолочных, колонных и др. сплит-систем",
                    Price = null,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -16,
                    ExactPrice = false,
                    Name = "Демонтаж оконного кондиционера",
                    Price = 1000,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -17,
                    ExactPrice = false,
                    Name = "Демонтаж настенной сплит-системы (модель 07, 09) до 2.8КВт",
                    Price = 1200,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -18,
                    ExactPrice = false,
                    Name = "Демонтаж настенной сплит-системы (модель 12) до 3.5КВт",
                    Price = 1500,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -19,
                    ExactPrice = false,
                    Name = "Демонтаж настенной сплит-системы (модель 18) до 5.5КВт",
                    Price = 2000,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -20,
                    ExactPrice = false,
                    Name = "Демонтаж настенной сплит-системы (модель 24) до 7.0КВт",
                    Price = 2500,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -21,
                    ExactPrice = false,
                    Name = "Демонтаж настенной сплит-системы (модель 36) свыше 7.0КВт",
                    Price = 3000,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -22,
                    ExactPrice = false,
                    Name = "Диагностика неисправности сплит-системы",
                    Price = 700,
                    Unity = "шт"
                },
                new WorkPrice
                {
                    ContactPrice = false,
                    Id = -23,
                    ExactPrice = true,
                    Name = "Дополнительная межблочная коммуникация (для систем 07 и 09)",
                    Price = 500,
                    Unity = "м"
                });
            #endregion
        }

        private static void SystemSetup(ModelBuilder builder)
        {
            builder.HasDefaultSchema("public");

            builder.Entity<User>().ToTable("users").HasKey(x => x.Id);
            builder.Entity<User>().HasMany(x => x.Roles).WithOne(x => x.User).HasForeignKey(x => x.UserId);

            builder.Entity<Role>().ToTable("roles").HasKey(x => x.Id);
            builder.Entity<Role>().HasMany(x => x.Users).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);

            builder.Entity<RoleClaim>().ToTable("role_claims").HasKey(x => x.Id);

            builder.Entity<UserClaim>().ToTable("user_claims").HasKey(x => x.Id);

            builder.Entity<UserLogin>().ToTable("user_logins");

            builder.Entity<UserRole>().ToTable("user_roles");

            builder.Entity<UserToken>().ToTable("user_tokens");

            builder.Entity<WorkExample>().ToTable("work_examples").HasKey(x => x.Id);
            builder.Entity<WindowPlastic>().ToTable("window_plastics").HasKey(x => x.Id);
            builder.Entity<SplitHouse>().ToTable("split_houses").HasKey(x => x.Id);
            builder.Entity<LogoType>().ToTable("logo_types").HasKey(x => x.Id);
            builder.Entity<WorkPrice>().ToTable("work_prices").HasKey(x => x.Id);
        }
    }
}
