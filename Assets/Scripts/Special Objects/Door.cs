using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer open_sprite;
    [SerializeField]
    private SpriteRenderer close_sprite;

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
}
