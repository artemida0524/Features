using UnityEngine;

public abstract class ItemObjectPoolBase : MonoBehaviour
{

    protected PooledObject _pooledObject;

    public virtual PooledObject PooledObject
    {
        get
        {
            if (_pooledObject == null)
            {
                _pooledObject = GetComponent<PooledObject>();
            }

            return _pooledObject;
        }
    }


    public abstract void Disable();
}
