
using Domain.Core;

namespace Infrastructure.Repositories.Relational
{
    public class RelationalRepository<TEntity> : RelationalRepository<TEntity, int>
        where TEntity : BaseEntity
    {
        public RelationalRepository()
            : base()
        {
        }
    }
}
