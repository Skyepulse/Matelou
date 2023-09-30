using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    [HideInInspector]
    private Inventory_Object _inventory_object = null;

    [SerializeField]
    private Inventory_Object_Trigger _trigger;

    //Add a new object to inventory and send a reference to the previous object in inventory
    public Inventory_Object add_to_inventory(Inventory_Object o)
    {
        o.getPicked();
        if (_inventory_object == null)
        {
            _inventory_object = o;
            return null;
        }

        Inventory_Object last_object = _inventory_object;
        _inventory_object = o;
        return last_object;

    }

    public Inventory_Object get_inventory_object()
    {
        return _inventory_object;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_trigger.GetInventory_Object() != null) add_to_inventory(_trigger.GetInventory_Object());
            else Debug.Log("There is no object here");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (_inventory_object != null) Debug.Log("Current object: " + _inventory_object.get_name());
            else Debug.Log("No object in inventory");
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            objectUse();
        }
    }

    private void objectUse()
    {
        if(_inventory_object != null)
        {
            _inventory_object.use();
        }
    }
}
