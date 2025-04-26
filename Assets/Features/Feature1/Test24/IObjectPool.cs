using System.Collections.Generic;

public interface IObjectPool<out TSource> : IEnumerable<TSource>
{
    TSource BaseInstance { get; }
    TSource Get(bool isActive);
}
