using Infrastructure.Context.DataContextStorage;
using Infrastructure.Diagram;

namespace Infrastructure.Context
{
    public static class DataContextFactory
    {
        public static void Clear()
        {
            var dataContextStorageContainer = DataContextStorageFactory<PrincipalDBContainer>.CreateStorageContainer();
            dataContextStorageContainer.Clear();
        }

        public static PrincipalDBContainer GetDataContext()
        {
            var dataContextStorageContainer = DataContextStorageFactory<PrincipalDBContainer>.CreateStorageContainer();
            var contactManagerContext = dataContextStorageContainer.GetDataContext();
            if (contactManagerContext == null)
            {
                contactManagerContext = new PrincipalDBContainer();
                dataContextStorageContainer.Store(contactManagerContext);
            }
            return contactManagerContext;
        }
    }
}
