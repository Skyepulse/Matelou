using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Object_Trigger : MonoBehaviour
{
    private GameObject _current_collision_object = null;
    private Door _current_door_in_front = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            _current_collision_object = collision.gameObject;
            collision.GetComponent<Inventory_Object>().setE();
        }

        if(collision.gameObject.layer == 7 && collision.gameObject.GetComponent<Door>() != null)
        {
            _current_door_in_front = collision.gameObject.GetComponent<Door>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            if(_current_collision_object == collision.gameObject)
            {
                _current_collision_object = null;
                collision.GetComponent<Inventory_Object>().eraseE();
            }
        }
        if (collision.gameObject.layer == 7 && collision.gameObject.GetComponent<Door>() != null)
        {
            _current_door_in_front = null;
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

    public Door getDoor()
    {
        if(_current_door_in_front == null)
        {
            return null;
        }
        return _current_door_in_front;
    }
}
