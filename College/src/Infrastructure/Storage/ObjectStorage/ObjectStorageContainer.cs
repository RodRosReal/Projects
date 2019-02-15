using System.Collections;

namespace Infrastructure.ObjectStorage
{
    public static class ObjectStorageContainer<T> where T : class
    {
        private static T _storedContext;

        public static T Get()
        {
            T context = null;

            if (_storedContext != null)
            {
                context = (T)_storedContext;
            }
            return context;
        }

        public static void Clear()
        {
            if (_storedContext != null)
            {
                _storedContext = null;
            }
        }

        public static void Store(T objectContext)
        {
            _storedContext = objectContext;
        }
    }
}
