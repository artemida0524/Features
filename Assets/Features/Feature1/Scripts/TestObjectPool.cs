using System.Collections.Generic;
using UnityEngine;

public class TestObjectPool : MonoBehaviour
{
    [SerializeField] private ItemObjectPool1 instance1;
    [SerializeField] private ItemObjectPool2 instance2;
    [SerializeField] private ItemObjectPool3 instance3;

    private IObjectPool<ItemObjectPool1> _pool1;
    private IObjectPool<ItemObjectPool2> _pool2;
    private IObjectPool<ItemObjectPool3> _pool3;

    private IFactory<ItemObjectPoolBase> _factory;
    private ObjectPools<ItemObjectPoolBase> _source;

    private void Start()
    {
        _pool1 = new ObjectPool<ItemObjectPool1>(instance1, 1);
        _pool2 = new ObjectPool<ItemObjectPool2>(instance2, 1);
        _pool3 = new ObjectPool<ItemObjectPool3>(instance3, 1);

        List<IObjectPool<ItemObjectPoolBase>> pools = new List<IObjectPool<ItemObjectPoolBase>>()
        {
            _pool1,
            _pool2,
            _pool3
        };

        _source = new ObjectPools<ItemObjectPoolBase>(pools);

        _factory = new PooledFactory<ItemObjectPoolBase>(_source);
        //_factory = new FactoryTest<ItemObjectPoolBase>(new List<ItemObjectPoolBase>()
        //{
        //    instance1,
        //    instance2,
        //    instance3
        //});
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ItemObjectPoolBase item = _factory.Get<ItemObjectPool3>(true);
            Debug.Log(item.GetType());

            item.Disable();

        }
    }



}
