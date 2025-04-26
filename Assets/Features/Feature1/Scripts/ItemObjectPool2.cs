using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ItemObjectPool2Pooled))]
public class ItemObjectPool2 : ItemObjectPoolBase
{
    private void Start()
    {

    }

    public override void Disable()
    {
        StartCoroutine(enumerator());
    }

    private IEnumerator enumerator()
    {
        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);

    }

}
