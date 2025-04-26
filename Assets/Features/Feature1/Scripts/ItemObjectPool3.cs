using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ItemObjectPool3Pooled))]
public class ItemObjectPool3 : ItemObjectPoolBase
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
