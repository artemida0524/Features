using System.Collections.Generic;
using UnityEngine;

public class FactoryTest<TSource> : IFactory<TSource> where TSource: MonoBehaviour
{
    private List<TSource> _instances;

    public FactoryTest(List<TSource> instances)
    {
        _instances = instances;
    }

    public T Get<T>(bool isActive) where T : TSource
    {
        foreach (var item in _instances)
        {
            Debug.Log(item);

            if (item is T)
            {
                T newInstance = UnityEngine.Object.Instantiate((T)item);
                newInstance.gameObject.SetActive(isActive); 
                return newInstance;
            }
        }

        Debug.LogWarning("NULL");
        return null;
    }

}