using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Entity
{
    public static class DbContextExtensionsx
    {
        private static readonly EntityState[] UndoEntityStateList =
        {
            EntityState.Added,
            EntityState.Modified,
            EntityState.Deleted
        };

        public static void UndoChanges(this DbContext dbContext)
        {
            var changedEntries = GetChangesEntries(dbContext);

            foreach (var item in changedEntries)
            {
                MakeEntryUnchanged(item);
            }
        }

        private static IEnumerable<DbEntityEntry> GetChangesEntries(DbContext dbContext)
        {
            return dbContext.ChangeTracker.Entries().Where(entry => UndoEntityStateList.Contains(entry.State));
        }

        private static void MakeEntryUnchanged(DbEntityEntry entry)
        {
            entry.State = EntityState.Unchanged;
        }
    }
}
