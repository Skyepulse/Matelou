using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiole : Inventory_Object
{
    public override void use()
    {
        GameManager.Instance.shrinker.shrinkFactor /= 2;
        Destroy(this.gameObject);
    }
}

