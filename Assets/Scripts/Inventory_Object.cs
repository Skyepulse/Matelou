using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Object : MonoBehaviour
{
    [HideInInspector]
    private Sprite object_sprite;

    public Sprite get_sprite()
    {
        return object_sprite;
    }

    public string get_name()
    {
        return this.name;
    }

    public void getPicked()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void restore(Vector2 pos)
    {
        transform.position = pos;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
