using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiole : Inventory_Object
{
    private void Start()
    {
        offset = new Vector2(0, 0.15f);
    }
    public override void use()
    {
        Shrinker shrinker = GameManager.Instance.shrinker;
        if (shrinker.shrinkFactor !=  shrinker.smallshrink)
        {
            if (shrinker.shrinkFactor == shrinker.bigshrink) shrinker.shrinkFactor = shrinker.midshrink;
            else shrinker.shrinkFactor = shrinker.smallshrink;
            GameManager.Instance.shrinker.shrinkstatus -=1;
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("<color=blue>Cannot be used right now</color>");
        }
    }
}

