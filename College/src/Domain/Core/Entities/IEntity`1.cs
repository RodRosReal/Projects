namespace Domain.Core
{
    public interface IEntity<out TKey> : IEntity
    {
        TKey Codigo { get; }
    }
}
