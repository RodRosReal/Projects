using CollegeBusiness.Util.DataContextStorage;
using System.Web;

namespace CollegeBusiness.DataContextStorage
{
  public static class cDataContextStorageFactory<T> where T : class
  {
    private static cIDataContextStorageContainer<T> _dataContextStorageContainer;

    public static cIDataContextStorageContainer<T> CreateStorageContainer()
    {
      if (_dataContextStorageContainer == null)
      {
        if (HttpContext.Current == null)
        {
          _dataContextStorageContainer = new cThreadDataContextStorageContainer<T>();
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
