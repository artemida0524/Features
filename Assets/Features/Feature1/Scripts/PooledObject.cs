using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public IObjectPool<PooledObject> Pool { get; protected set; }

    public virtual void Init(IObjectPool<PooledObject> pool)
    {
       Pool = pool;
    }

    public virtual void BackToPool()
    {
        Pool.ReturnToPool(this);
    }
}