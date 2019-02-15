using Application.Messages;
using Domain.ValueObjects;

namespace Integration.Factories
{
    public class StockFactory : IntegrationFactory
    {
        //private readonly IFoccoWebProdutoRepository _produtoRepository = new FoccoWebProdutoRepository();

        public StockFactory() : base()
        {
        }

        public ListStocks ListStocks(string Item)
        {
            var response = new ListStocks();

            var getStockItemCommandResponse = new GetStockItemCommandResponse();

            var request = new GetStockItemCommandRequest()
            {
                GetStockItemRequest = new GetStockItemRequest()
                {
                    ItemCode = Item,
                    MascaraId = null
                }
            };

            getStockItemCommandResponse = base._foccoErpApiCommands.GetStockItemCommand(request);

            if (!getStockItemCommandResponse.Success)
                return response;

            if (getStockItemCommandResponse.GetStockItemResponse.Rows != null)
            {
                response.Items = getStockItemCommandResponse.GetStockItemResponse.Rows;
            }

            return response;
        }
    }
}
