using Domain.Core;
using MongoDB.Driver;
using System.Configuration;

namespace Infrastructure.Repositories.Document
{
    public class DocumentRepository<TEntity> : DocumentRepository<TEntity, int>
        where TEntity : BaseEntity
    {
        public DocumentRepository()
            : base(ConfigurationManager.ConnectionStrings["PrincipalDocumentConnection"].ConnectionString)
        {
        }
    }
}
