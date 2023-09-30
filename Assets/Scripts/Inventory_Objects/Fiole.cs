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
        if (shrinker.shrinkFactor !=  Shrinker.smallshrink)
        {
            if (shrinker.shrinkFactor == Shrinker.bigshrink) shrinker.shrinkFactor = Shrinker.midshrink;
            else shrinker.shrinkFactor = Shrinker.smallshrink;
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("<color=blue>Cannot be used right now</color>");
        }
    }
}

