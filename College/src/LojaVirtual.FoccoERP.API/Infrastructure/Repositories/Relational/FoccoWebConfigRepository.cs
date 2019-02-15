using Domain.Entities.Relacional;
using Domain.Repositories;

namespace Infrastructure.Repositories.Relational
{
    public class FoccoWebConfigRepository : Repository<FoccoWebApiConfiguracao>, IFoccoWebConfigRepository
    {
        public FoccoWebConfigRepository()
        {
        }
    }
}
