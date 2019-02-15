using Domain.Entities.Relacional;
using Domain.Repositories;

namespace Infrastructure.Repositories.Relational
{
    public class FoccoWebPrazoRepository : Repository<FoccoWebApiPrazo>, IFoccoWebPrazoRepository
    {
        public FoccoWebPrazoRepository()
        {
        }
    }
}
