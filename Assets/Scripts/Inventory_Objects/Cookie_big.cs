using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie_big : Inventory_Object
{
    public override void use()
    {
        if (GameManager.Instance.shrinker.shrinkFactor < 2)
        {
            GameManager.Instance.shrinker.shrinkFactor *= 2;
            GameManager.Instance.shrinker.shrinkstatus +=1;
            Destroy(this.gameObject);
        } else
        {
            Debug.Log("<color=blue>Cannot be used right now</color>");
        }
    }
}
