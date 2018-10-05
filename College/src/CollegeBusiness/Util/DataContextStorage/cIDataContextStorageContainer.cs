namespace CollegeBusiness.Util.DataContextStorage
{
  public interface cIDataContextStorageContainer<T>
  {
    T GetDataContext();

    void Store(T objectContext);

    void Clear();
  }
}
