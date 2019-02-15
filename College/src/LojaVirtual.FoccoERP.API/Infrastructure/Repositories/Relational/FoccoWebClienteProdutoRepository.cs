using Domain.Entities.Relacional;
using Domain.Repositories;

namespace Infrastructure.Repositories.Relational
{
    public class FoccoWebClienteProdutoRepository : Repository<FoccoWebApiClienteProduto>, IFoccoWebClienteProdutoRepository
    {
        public FoccoWebClienteProdutoRepository()
        {
        }
    }
}
