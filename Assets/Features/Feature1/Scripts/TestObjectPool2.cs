using UnityEngine;



public class TestObjectPool2 : MonoBehaviour
{
    [SerializeField] private ItemObjectPool1 instance1;
    [SerializeField] private ItemObjectPool2 instance2;
    [SerializeField] private ItemObjectPool3 instance3;
    IObjectPool<ItemObjectPoolBase> pool;

    private void Start()
    {

        pool = new ObjectPool<ItemObjectPoolBase>(instance2, 10);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            pool.Get(true);
        }
    }



}