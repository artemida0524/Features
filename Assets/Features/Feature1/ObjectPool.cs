using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool<TSource> : IObjectPool<TSource> where TSource : MonoBehaviour
{
    public TSource BaseInstance { get; private set; }
    private List<TSource> _list;

    public ObjectPool(TSource instance)
    {
        BaseInstance = instance;
        _list = new List<TSource>();
    }

    public ObjectPool(TSource instance, int count) : this(instance)
    {
        _list = new List<TSource>(count);

        InitList(count);

    }

    private TSource Add(bool isActive = false)
    {
        TSource newInstance = Object.Instantiate(BaseInstance);
        _list.Add(newInstance);

        newInstance.gameObject.SetActive(isActive);


        return newInstance;
    }

    public TSource Get(bool isActive = false)
    {
        foreach (var item in _list)
        {
            if (!item.gameObject.activeSelf)
            {
                TSource getObject = item;
                item.gameObject.SetActive(isActive);
                return getObject;
            }
        }
        return Add(isActive);
    }

    private void InitList(int count)
    {
        if (_list == null)
        {
            _list = new List<TSource>();
        }

        for (int i = 0; i < count; i++)
        {
            Add();
        }

    }

    public IEnumerator<TSource> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _list.GetEnumerator();
    }
}
