using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Inventory : MonoBehaviour
{
    [HideInInspector]
    private Inventory_Object _inventory_object = null;

    [SerializeField]
    private Inventory_Object_Trigger _trigger;
    [SerializeField]
    private GameObject drop_point;
    [SerializeField]
    private Image _image;


    private Sprite _default_gui_sprite;

    

    private void Start()
    {
        _default_gui_sprite = _image.sprite;
    }

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
        update_gui();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_trigger.GetInventory_Object() != null && GameManager.Instance.shrinker.canPickUpObjects)
            {
                Inventory_Object to_drop_object = null;
                //Verify if alice can pick the object
                if (_trigger.GetInventory_Object().getPickupOptions()[GameManager.Instance.shrinker.shrinkstatus - 1]) to_drop_object = add_to_inventory(_trigger.GetInventory_Object());
                if (to_drop_object != null)
                {
                    drop(to_drop_object);
                }
            }

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

        if (Input.GetKeyDown(KeyCode.D))
        {
            if(_inventory_object != null)
            {
                drop(_inventory_object);
                _inventory_object = null;
            }
        }
    }

    private void objectUse()
    {
        if(_inventory_object != null)
        {
            _inventory_object.use();
        }
    }

    private void update_gui()
    {
        if(_inventory_object != null)
        {
            _image.sprite = _inventory_object.get_sprite();
        } else
        {
            _image.sprite = _default_gui_sprite;
        }
    }

    private void drop(Inventory_Object drop_object)
    {
        drop_object.restore(new Vector2(drop_point.transform.position.x, drop_point.transform.position.y));
    }
}
