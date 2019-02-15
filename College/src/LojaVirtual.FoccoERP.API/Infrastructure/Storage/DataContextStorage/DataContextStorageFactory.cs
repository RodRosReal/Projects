using System.Web;

namespace Infrastructure.Context.DataContextStorage
{
  public static class DataContextStorageFactory<T> where T : class
  {
    private static IDataContextStorageContainer<T> _dataContextStorageContainer;

    public static IDataContextStorageContainer<T> CreateStorageContainer()
    {
      if (_dataContextStorageContainer == null)
      {
        if (HttpContext.Current == null)
        {
          _dataContextStorageContainer = new ThreadDataContextStorageContainer<T>();
        }
        else
        {
          _dataContextStorageContainer = new HttpDataContextStorageContainer<T>();
        }
      }
      return _dataContextStorageContainer;
    }
  }
}
