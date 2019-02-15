using Domain.Entities.Relacional;
using Domain.Repositories;

namespace Infrastructure.Repositories.Relational
{
    public class FoccoWebProdutoRepository : Repository<FoccoWebApiProduto>, IFoccoWebProdutoRepository
    {
        public FoccoWebProdutoRepository()
        {
        }
    }
}
