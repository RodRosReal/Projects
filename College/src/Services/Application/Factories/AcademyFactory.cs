using AutoMapper;
using Domain.Dto;
using Domain.Repositories.Relacional;
using Infrastructure.Repositories.Relational;
using System.Threading.Tasks;

namespace Application.Factories
{
    public class AcademyFactory : ApplicationFactory
    {
        IAcademyRepository _academyRepository = new AcademyRepository();

        public AcademyFactory() : base()
        {
            
        }

        public async Task<AcademyDto> GetAcademy(int id)
        {
            var entity = await _academyRepository.Get(id);
            return Mapper.Map<AcademyDto>(entity);
        }
    }
}
