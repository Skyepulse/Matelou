using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory_Object : MonoBehaviour
{
    [SerializeField]
    private Sprite object_sprite;
    protected Vector2 offset;
    [SerializeField]
    protected bool _shouldTellUse;
    [SerializeField]
    protected SpriteRenderer _otherSprite_renderer;

    [Header("Size Pickup Options")]
    [SerializeField]
    private bool SmallPickup;
    [SerializeField]
    private bool MidPickup;
    [SerializeField]
    private bool BigPickup;
    

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
        if (_shouldTellUse)
        {
            GameManager.Instance.maincanvas.transform.GetChild(1).gameObject.SetActive(true);

        } 
    }

    public virtual void restore(Vector2 pos)
    {
        transform.position = pos + offset;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public abstract void use();

    public bool[] getPickupOptions()
    {
        return new bool[3] { SmallPickup, MidPickup, BigPickup};
    }

    public void setE()
    {
        _otherSprite_renderer.enabled = true;
    }

    public void eraseE()
    {
        _otherSprite_renderer.enabled = false;
    }
}
