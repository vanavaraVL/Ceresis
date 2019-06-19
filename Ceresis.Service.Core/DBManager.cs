using Ceresis.Data.Core.Model;
using Ceresis.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Ceresis.Repository.Models;
using Ceresis.Repository.Infrastructure;
using Ceresis.Data.Core.Model.Paging;
using Ceresis.Data.Core.Model.Sorting;

namespace Ceresis.Service.Core
{
    public class DBManager
    {
        private readonly IRepositoryFactory repository;

        public DBManager(IRepositoryFactory repository)
        {
            this.repository = repository;
        }

        public IQueryable<WorkExample> GetWorksamples()
        {
            return repository.WorkExamples.DbSet.AsQueryable();
        }

        public IQueryable<LogoType> GetLogos()
        {
            return repository.LogoTypes.DbSet.AsQueryable();
        }

        public IQueryable<WindowPlastic> GetWindowPlastics()
        {
            return repository.WindowPlastics.DbSet.AsQueryable();
        }

        public IQueryable<SplitHouse> GetSplitHouses()
        {
            return repository.SplitHouses.DbSet.AsQueryable();
        }

        public IQueryable<WorkPrice> GetWorkprices()
        {
            return repository.WorkPrices.DbSet.AsQueryable();
        }

        public void AddNewWorksample(WorkExample item)
        {
            repository.WorkExamples.DbSet.Add(item);
            repository.SaveChanges();
        }

        public void AddLogo(LogoType item)
        {
            repository.LogoTypes.DbSet.Add(item);
            repository.SaveChanges();
        }

        public void AddNewSplitHouse(SplitHouse item)
        {
            repository.SplitHouses.DbSet.Add(item);
            repository.SaveChanges();
        }

        public void AddWorkprice(WorkPrice item)
        {
            repository.WorkPrices.DbSet.Add(item);
            repository.SaveChanges();
        }

        public void RemoveWorkSample(int id)
        {
            var dbItem = repository.WorkExamples.DbSet.Find(id);

            if (dbItem != null)
            {
                repository.WorkExamples.DbSet.Remove(dbItem);
                repository.SaveChanges();
            }
        }

        public void RemoveLogo(int id)
        {
            var dbItem = repository.LogoTypes.DbSet.Find(id);

            if (dbItem != null)
            {
                repository.LogoTypes.DbSet.Remove(dbItem);
                repository.SaveChanges();
            }
        }

        public void RemoveWindowPlastic(int id)
        {
            var dbItem = repository.WindowPlastics.DbSet.Find(id);

            if (dbItem != null)
            {
                repository.WindowPlastics.DbSet.Remove(dbItem);
                repository.SaveChanges();
            }
        }

        public void RemoveSplitHouse(int id)
        {
            var dbItem = repository.SplitHouses.DbSet.Find(id);

            if (dbItem != null)
            {
                repository.SplitHouses.DbSet.Remove(dbItem);
                repository.SaveChanges();
            }
        }

        public void RemoveWorkprice(int id)
        {
            var dbItem = repository.WorkPrices.DbSet.Find(id);

            if (dbItem != null)
            {
                repository.WorkPrices.DbSet.Remove(dbItem);
                repository.SaveChanges();
            }
        }

        public void AddNewWindowPlastics(WindowPlastic item)
        {
            repository.WindowPlastics.DbSet.Add(item);
            repository.SaveChanges();
        }

        public void UpdateWindowPlastic(WindowPlastic item)
        {
            repository.WindowPlastics.DbSet.Update(item);
            repository.SaveChanges();
        }

        public void UpdateSplitHouse(SplitHouse item)
        {
            repository.SplitHouses.DbSet.Update(item);
            repository.SaveChanges();
        }

        public void UpdateWorkprice(WorkPrice item)
        {
            repository.WorkPrices.DbSet.Update(item);
            repository.SaveChanges();
        }

        public WindowPlastic GetById(int id)
        {
            return repository.WindowPlastics.DbSet.FirstOrDefault(d => d.Id == id);
        }

        public SplitHouse GetSplitHouseById(int id)
        {
            return repository.SplitHouses.DbSet.FirstOrDefault(d => d.Id == id);
        }

        public WorkPrice GetWorkpriceById(int id)
        {
            return repository.WorkPrices.DbSet.FirstOrDefault(d => d.Id == id);
        }
    }
}
