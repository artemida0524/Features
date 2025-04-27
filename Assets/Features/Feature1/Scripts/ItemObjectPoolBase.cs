using UnityEngine;

public abstract class ItemObjectPoolBase : MonoBehaviour, IPooledObject
{

    public IObjectPool<IPooledObject> Pool { get; protected set; }

    public virtual void Init(IObjectPool<IPooledObject> pool)
    {
        Pool = pool;
    }

    public virtual void BackToPool()
    {
        Pool.ReturnToPool(this);
    }
}
