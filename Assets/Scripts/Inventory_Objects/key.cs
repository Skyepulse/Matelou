using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : Inventory_Object
{
    [SerializeField]
    private Door _door;
    public override void use()
    {
        Door door = GameManager.Instance.object_trigger.getDoor();
        if (door != null) if (door == _door)
            {
                _door.open();
                Destroy(this.gameObject);
            };

    }
}
