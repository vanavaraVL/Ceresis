using Ceresis.Repository.Implementation.Repositories;
using Ceresis.Repository.Infrastructure;
using Ceresis.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ceresis.Repository.Implementation
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IDatabaseContext _database;

        public RepositoryFactory(IDatabaseContext database)
        {
            _database = database;
        }

        public IRepository<User> Users => new BaseRepository<User>(_database);

        public IRepository<WorkExample> WorkExamples => new BaseRepository<WorkExample>(_database);

        public IRepository<WindowPlastic> WindowPlastics => new BaseRepository<WindowPlastic>(_database);

        public IRepository<SplitHouse> SplitHouses => new BaseRepository<SplitHouse>(_database);

        public IRepository<LogoType> LogoTypes => new BaseRepository<LogoType>(_database);

        public IRepository<WorkPrice> WorkPrices => new BaseRepository<WorkPrice>(_database);

        public async Task<int> SaveChangesAsync()
        {
            return await _database.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _database.SaveChanges();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
