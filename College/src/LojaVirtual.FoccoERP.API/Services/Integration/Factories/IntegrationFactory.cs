using Application.Interfaces;
using Application.Services;
using Domain.Core;
using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Relational;

namespace Integration.Factories
{
    public class IntegrationFactory
    {
        private readonly IFoccoWebConfigRepository _configRepository = new FoccoWebConfigRepository();
        public readonly IFoccoErpApiCommands _foccoErpApiCommands;
        public readonly IUnitOfWork _unitOfWork = new UnitOfWork();

        public IntegrationFactory()
        {
            var foccoWebConfig = _configRepository.GetFirst();
            if (foccoWebConfig != null)
            {
                var config = new Settings()
                {
                    BaseUrl = foccoWebConfig.ApiBaseUrl,
                    RequestAccess = new RequestAccess()
                    {
                        ClientID = foccoWebConfig.ApiClientId,
                        User = foccoWebConfig.ApiUser,
                        Password = foccoWebConfig.ApiPassword,
                        KillOtherSessions = foccoWebConfig.ApiKillOtherSessions
                    }
                };

                _foccoErpApiCommands = new FoccoErpApiCommands(config);
            }
        }
    }
}
