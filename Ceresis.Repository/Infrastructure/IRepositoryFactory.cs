using Ceresis.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ceresis.Repository.Infrastructure
{
    public interface IRepositoryFactory : IDisposable
    {
        IRepository<User> Users { get; }

        IRepository<WorkExample> WorkExamples { get; }

        IRepository<WindowPlastic> WindowPlastics { get; }

        IRepository<SplitHouse> SplitHouses { get; }

        IRepository<LogoType> LogoTypes { get; }

        IRepository<WorkPrice> WorkPrices { get; }

        Task<int> SaveChangesAsync();

        int SaveChanges();
    }
}
