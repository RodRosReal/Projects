using Domain.Entities.Relacional;
using Domain.Repositories.Relacional;

namespace Infrastructure.Repositories.Relational
{
    public class AcademyRepository : RelationalRepository<Academia>, IAcademyRepository
    {
        public AcademyRepository()
        {
        }
    }
}
