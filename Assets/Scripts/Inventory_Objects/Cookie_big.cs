using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie_big : Inventory_Object
{
    public override void use()
    {
        GameManager.Instance.shrinker.shrinkFactor *= 2;
        Destroy(this.gameObject);
    }
}
