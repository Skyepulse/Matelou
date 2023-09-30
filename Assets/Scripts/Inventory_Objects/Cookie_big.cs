using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie_big : Inventory_Object
{
    public override void use()
    {
        Shrinker shrinker = GameManager.Instance.shrinker;
        if (shrinker.shrinkFactor !=  shrinker.bigshrink)
        {
            if (shrinker.shrinkFactor == shrinker.smallshrink) shrinker.shrinkFactor = shrinker.midshrink;
            else shrinker.shrinkFactor = shrinker.bigshrink;
            GameManager.Instance.shrinker.shrinkstatus +=1;
            Destroy(this.gameObject);
        } else
        {
            Debug.Log("<color=blue>Cannot be used right now</color>");
        }
    }
}
