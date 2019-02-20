using AutoMapper;
using Domain.Dto;
using Domain.Entities.Relacional;

namespace Infrastructure.Repositories.Relational.Mappers
{
    public static class InitializeMappers
    {
        public static void Configure()
        {

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AcademyDto, Academia>();

                cfg.CreateMap<Academia, AcademyDto>();
                });
        }
    }
}
