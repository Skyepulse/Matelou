using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiole : Inventory_Object
{
    public override void use()
    {
        if (GameManager.Instance.shrinker.shrinkFactor > 0.5f)
        {
            GameManager.Instance.shrinker.shrinkFactor /= 2;
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("<color=blue>Cannot be used right now</color>");
        }
    }
}

