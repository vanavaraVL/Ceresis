using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ceresis.Repository.Infrastructure
{
    public interface IDatabaseContext : IDisposable
    {
        DbSet<T> GetDbSet<T>() where T : class;

        ChangeTracker GetChangeTracker();

        Task<int> SaveChangesAsync();

        int SaveChanges();
    }
}
