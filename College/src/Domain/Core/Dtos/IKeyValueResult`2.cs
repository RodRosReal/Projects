namespace Domain.Core
{
    public interface IKeyValueResult<out TKey, out TValue> : IDto
    {
        TKey Key { get; }

        TValue Value { get; }
    }
}
