using Domain.Entities.Relacional;
using Domain.Repositories;

namespace Infrastructure.Repositories.Relational
{
    public class FoccoWebFormaPagamentoRepository : Repository<FoccoWebApiFormaPagamento>, IFoccoWebFormaPagamentoRepository
    {
        public FoccoWebFormaPagamentoRepository()
        {
        }
    }
}
