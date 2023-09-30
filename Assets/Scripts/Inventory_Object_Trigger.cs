using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Object_Trigger : MonoBehaviour
{
    private GameObject _current_collision_object = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.layer == 6)
        {
            _current_collision_object = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            if(_current_collision_object == collision.gameObject)
            {
                _current_collision_object = null;
            }
        }
    }

    public Inventory_Object GetInventory_Object()
    {
        if( _current_collision_object == null)
        {
            return null;
        }
        return _current_collision_object.GetComponent<Inventory_Object>();
    }
}
