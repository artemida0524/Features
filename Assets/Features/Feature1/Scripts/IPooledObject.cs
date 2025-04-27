public interface IPooledObject
{
    IObjectPool<IPooledObject> Pool { get; }

    void Init(IObjectPool<IPooledObject> pool);

    void BackToPool();
}
