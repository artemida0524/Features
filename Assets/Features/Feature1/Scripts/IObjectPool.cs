using System.Collections.Generic;

public interface IObjectPool<out TSource> : IEnumerable<TSource> where TSource : IPooledObject
{
    TSource BaseInstance { get; }
    TSource Get(bool isActive);

    void ReturnToPool(IPooledObject pooledObject);
}
