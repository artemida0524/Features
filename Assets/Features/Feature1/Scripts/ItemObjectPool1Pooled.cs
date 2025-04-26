using UnityEngine;

public class ItemObjectPool1Pooled : PooledObject
{
    public override void Init(IObjectPool<PooledObject> pool)
    {
        base.Init(pool);
        Debug.Log("Init");        
        // some
    }

    public override void BackToPool()
    {
        base.BackToPool();

        // some

    }

}