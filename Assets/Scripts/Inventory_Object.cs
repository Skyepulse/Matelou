using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory_Object : MonoBehaviour
{
    [SerializeField]
    private Sprite object_sprite;
    protected Vector2 offset;

    public virtual Sprite get_sprite()
    {
        return object_sprite;
    }

    public virtual string get_name()
    {
        return this.name;
    }

    public virtual void getPicked()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public virtual void restore(Vector2 pos)
    {
        transform.position = pos + offset;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public abstract void use();
}
