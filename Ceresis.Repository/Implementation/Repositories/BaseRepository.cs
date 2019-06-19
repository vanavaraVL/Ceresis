using Ceresis.Repository.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Repository.Implementation.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public BaseRepository(DbSet<T> dataSet)
        {
            DbSet = dataSet ?? throw new ArgumentNullException(nameof(dataSet));
        }

        public BaseRepository(IDatabaseContext databaseContext)
        {
            DbSet = databaseContext.GetDbSet<T>();
        }

        public DbSet<T> DbSet { get; set; }
    }
}
