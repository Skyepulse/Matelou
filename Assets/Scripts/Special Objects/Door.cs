using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer open_sprite;
    [SerializeField]
    private SpriteRenderer close_sprite;
    [SerializeField]
    public bool should_close_on_trigger;

    private void Start()
    {
        close_sprite.enabled = true;
        open_sprite.enabled = false;
    }
    public void open()
    {
        close_sprite.enabled = false;
        open_sprite.enabled = true;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void close()
    {
        close_sprite.enabled = true;
        open_sprite.enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer.ToString());
        if(collision.gameObject.layer == 3 && should_close_on_trigger)
        {
            close();
        }
    }
}
