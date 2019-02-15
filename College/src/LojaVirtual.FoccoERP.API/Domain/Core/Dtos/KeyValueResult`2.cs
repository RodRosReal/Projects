using System;

namespace Domain.Core
{
    public sealed class KeyValueResult<TKey, TValue> : IKeyValueResult<TKey, TValue>
    {
        public KeyValueResult(TKey key, TValue value)
        {
            if (key == null)
#pragma warning disable IDE0016 // Use 'throw' expression
                throw new ArgumentNullException(nameof(key));
#pragma warning restore IDE0016 // Use 'throw' expression

            this.Key = key;
            this.Value = value;
        }

        public TKey Key { get; }

        public TValue Value { get; }
    }
}
