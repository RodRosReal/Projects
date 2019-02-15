using Domain.Entities.Document;
using Domain.Repositories.Document;

namespace Infrastructure.Repositories.Document
{
    public class ProductRepository : DocumentRepository<Product>, IProductRepository
    {
        public ProductRepository()
            : base()
        {
        }
    }
}
