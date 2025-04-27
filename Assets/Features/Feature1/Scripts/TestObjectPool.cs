using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TestObjectPool : MonoBehaviour
{
    [SerializeField] private ItemObjectPool1 instance1;
    [SerializeField] private ItemObjectPool2 instance2;
    [SerializeField] private ItemObjectPool3 instance3;
    
    private IObjectPool<IPooledObject> _pool1;
    private IObjectPool<IPooledObject> _pool2;
    private IObjectPool<IPooledObject> _pool3;

    private IFactory<IPooledObject> _factory;
    private ObjectPools<IPooledObject> _source;

    private void Start()
    {
        _pool1 = new ObjectPool<ItemObjectPool1>(instance1, 1);
        _pool2 = new ObjectPool<ItemObjectPool2>(instance2, 1);
        _pool3 = new ObjectPool<ItemObjectPool3>(instance3, 1);

        List<IObjectPool<IPooledObject>> pools = new List<IObjectPool<IPooledObject>>()
        {
            _pool1,
            _pool2,
            _pool3
        };

        _source = new ObjectPools<IPooledObject>(pools);

        //_factory = new PooledFactory<IPooledObject>(_source);

        //_factory = new FactoryTest<ItemObjectPoolBase>(new List<ItemObjectPoolBase>()
        //{
        //    instance1,
        //    instance2,
        //    instance3,
        //});
    }

    private Queue<IPooledObject> _queue = new();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            _queue.Enqueue(_factory.Get<ItemObjectPool2>(true));
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            _queue.Dequeue().BackToPool();
        }

    }



}
