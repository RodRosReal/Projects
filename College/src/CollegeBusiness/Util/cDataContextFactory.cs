
using CollegeBusiness.DataContextStorage;
using CollegeData;
namespace CollegeBusiness.Util
{
    public static class cDataContextFactory
    {
        public static void Clear()
        {
            var dataContextStorageContainer = cDataContextStorageFactory<CollegeEntities>.CreateStorageContainer();
            dataContextStorageContainer.Clear();
        }

        public static CollegeEntities GetDataContext()
        {
            var dataContextStorageContainer = cDataContextStorageFactory<CollegeEntities>.CreateStorageContainer();
            var contactManagerContext = dataContextStorageContainer.GetDataContext();
            if (contactManagerContext == null)
            {
                contactManagerContext = new CollegeEntities();
                dataContextStorageContainer.Store(contactManagerContext);
            }
            return contactManagerContext;
        }
    }
}
