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
        if (GameManager.Instance.shrinker.shrinkFactor > 0.5f)
        {
            GameManager.Instance.shrinker.shrinkFactor /= 2;
            GameManager.Instance.shrinker.shrinkstatus -= 1; 
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("<color=blue>Cannot be used right now</color>");
        }
    }
}

