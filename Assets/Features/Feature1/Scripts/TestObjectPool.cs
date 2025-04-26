using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjectPool : MonoBehaviour
{
    [SerializeField] private ItemObjectPool1 instance1;
    [SerializeField] private ItemObjectPool2 instance2;
    [SerializeField] private ItemObjectPool3 instance3;

    private IObjectPool<PooledObject> _pool1;
    private IObjectPool<PooledObject> _pool2;
    private IObjectPool<PooledObject> _pool3;

    private IFactory<PooledObject> _factory;
    private ObjectPools<PooledObject> _source;

    private void Start()
    {
        _pool1 = new ObjectPool<PooledObject>(instance1.PooledObject, 1);
        _pool2 = new ObjectPool<PooledObject>(instance2.PooledObject, 1);
        _pool3 = new ObjectPool<PooledObject>(instance3.PooledObject, 1);

        List<IObjectPool<PooledObject>> pools = new List<IObjectPool<PooledObject>>()
        {
            _pool1,
            _pool2,
            _pool3
        };

        _source = new ObjectPools<PooledObject>(pools);

        _factory = new PooledFactory<PooledObject>(_source);
    }

    private Queue<PooledObject> _queue = new();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            _queue.Enqueue(_factory.Get<ItemObjectPool1Pooled>(true));
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            _queue.Dequeue().BackToPool();
        }

    }



}
