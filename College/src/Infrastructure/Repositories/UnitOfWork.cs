using Domain.Core;
using Infrastructure.Context;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public Task Commit()
        {
            var dbContext = DataContextFactory.GetDataContext();
            return Task.Run(() => dbContext.SaveChanges());
        }

        public Task Rollback()
        {
            var dbContext = DataContextFactory.GetDataContext();
            return dbContext.UndoChanges();
        }
    }
}
