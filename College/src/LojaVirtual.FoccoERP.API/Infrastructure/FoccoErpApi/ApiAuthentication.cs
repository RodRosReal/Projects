using Domain.ValueObjects;
using Infrastructure.ObjectStorage;
using System;

namespace Infrastructure.FoccoErpApi
{

    public class ApiAuthentication : ApiClient
    {

        public Authentication _authToken;

        public ApiAuthentication(Settings settings) : base(settings)
        {
            this.GetToken();
        }

        public void GetToken(bool force = false)
        {
            _authToken = ObjectStorageContainer<Authentication>.Get();
            if (force || _authToken == null || string.IsNullOrEmpty(_authToken.Token))
            {
                ObjectStorageContainer<Authentication>.Store(base.ExecutePost<Authentication>("api/authentication/requestaccess", base._settings.RequestAccess));
                _authToken = ObjectStorageContainer<Authentication>.Get();
            }
        }

    }
}
