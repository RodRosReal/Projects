using Domain.Core;
using Infrastructure.Repositories;

namespace Application.Factories
{
    public class ApplicationFactory
    {
        public readonly IUnitOfWork _unitOfWork = new UnitOfWork();

        public ApplicationFactory()
        {

        } 
    }
}
