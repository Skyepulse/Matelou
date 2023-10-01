using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie_big : Inventory_Object
{
    public override void use()
    {
        
        Shrinker shrinker = GameManager.Instance.shrinker;
        if (shrinker.shrinkFactor !=  Shrinker.bigshrink)
        {
            if (shrinker.shrinkFactor == Shrinker.smallshrink) shrinker.shrinkFactor = Shrinker.midshrink;
            else shrinker.shrinkFactor = Shrinker.bigshrink;
            Destroy(this.gameObject);
        } else
        {
            Debug.Log("<color=blue>Cannot be used right now</color>");
        }
    }
}
