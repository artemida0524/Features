using System.Collections.Generic;

public class ObjectPools<TSource> where TSource : PooledObject
{
    public List<IObjectPool<TSource>> Source { get; private set; }

    public ObjectPools(List<IObjectPool<TSource>> source)
    {
        Source = source;
    }

    public T Get<T>(bool isActive = false) where T : TSource
    {
        foreach (IObjectPool<TSource> pool in Source)
        {
            if (pool.BaseInstance is T)
            {
                return (T)pool.Get(isActive);
            }
        }
        return null;
    }
}


