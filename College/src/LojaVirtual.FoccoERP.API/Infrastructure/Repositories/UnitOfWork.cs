using Domain.Core;
using Infrastructure.Context;
using System;
using System.Data.Entity;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public void Commit()
        {
            var dbContext = DataContextFactory.GetDataContext();
            dbContext.SaveChanges();
        }

        public void Rollback()
        {
            var dbContext = DataContextFactory.GetDataContext();
            dbContext.UndoChanges();
        }
    }
}
