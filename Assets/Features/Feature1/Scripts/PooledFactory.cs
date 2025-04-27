using System;
using System.Runtime.Serialization;
using TMPro.EditorUtilities;
using UnityEngine;

public class PooledFactory<TSource> : IFactory<TSource> where TSource : IPooledObject
{
    private ObjectPools<TSource> _pool;

    public PooledFactory(ObjectPools<TSource> source)
    {
        _pool = source;
    }

    public T Get<T>(bool isActive = false) where T : TSource
    {
         return _pool.Get<T>(isActive);
    }
}
