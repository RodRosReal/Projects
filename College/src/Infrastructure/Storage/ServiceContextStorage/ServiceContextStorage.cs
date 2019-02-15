using System.Collections;

namespace Infrastructure.Context.ServiceStorage
{
    public static class ServiceContextStorage<T> where T : class
    {
        private static Hashtable _storedContexts = new Hashtable();

        public static T GetServiceContext()
        {
            T context = null;

            if (_storedContexts.Contains(typeof(T).ToString()))
            {
                context = (T)_storedContexts[typeof(T).ToString()]; 
            }
            return context;
        }

        public static void Clear()
        {
            if (_storedContexts.Contains(typeof(T).ToString()))
            {
                _storedContexts[typeof(T).ToString()] = null;
            }
        }

        public static T Store(T objectContext)
        {
            if (_storedContexts.Contains(typeof(T).ToString()))
            {
                _storedContexts[typeof(T).ToString()] = objectContext;
            }
            else
            {
                _storedContexts.Add(typeof(T).ToString(), objectContext);
            }

            return objectContext;
        }
    }
}
