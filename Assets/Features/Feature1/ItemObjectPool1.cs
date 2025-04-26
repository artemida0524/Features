using System.Collections;
using UnityEngine;

public class ItemObjectPool1 : ItemObjectPoolBase
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
