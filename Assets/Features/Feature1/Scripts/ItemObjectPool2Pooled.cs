public class ItemObjectPool2Pooled : PooledObject
{
    public override void Init(IObjectPool<PooledObject> pool)
    {
        base.Init(pool);
        // some
    }

    public override void BackToPool()
    {
        base.BackToPool();

        // some

    }

}
