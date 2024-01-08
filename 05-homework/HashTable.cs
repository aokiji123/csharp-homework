class HashTable<TKey, TValue>
{
    private const int Capacity = 100;

    private List<KeyValuePair<TKey, TValue>>[] buckets;

    public HashTable()
    {
        buckets = new List<KeyValuePair<TKey, TValue>>[Capacity];
    }

    private int GetHash(TKey key)
    {
        int hashCode = key.GetHashCode();
        int index = Math.Abs(hashCode % Capacity);
        return index;
    }

    public void Add(TKey key, TValue value)
    {
        int index = GetHash(key);

        if (buckets[index] == null)
        {
            buckets[index] = new List<KeyValuePair<TKey, TValue>>();
        }

        foreach (var bucket in buckets[index])
        {
            if (bucket.Key.Equals(key))
            {
                throw new InvalidOperationException("Key already exists");
            }
        }

        buckets[index].Add(new KeyValuePair<TKey, TValue>(key, value));
    }

    public TValue Get(TKey key)
    {
        int index = GetHash(key);

        if (buckets[index] != null)
        {
            foreach (var bucket in buckets[index])
            {
                if (bucket.Key.Equals(key))
                {
                    return bucket.Value;
                }
            }
        }

        throw new KeyNotFoundException("Key was not found in table");
    }

    public void Remove(TKey key)
    {
        int index = GetHash(key);

        if (buckets[index] != null)
        {
            for (int i = 0; i < buckets[index].Count; i++)
            {
                if (buckets[index][i].Key.Equals(key))
                {
                    buckets[index].RemoveAt(i);
                    return;
                }
            }
        }

        throw new KeyNotFoundException("Key was not found in table");
    }
}