using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Sizing : MonoBehaviour
{
    [SerializeField]
    private Collider2D[] _smallCollision;
    [SerializeField]
    private Collider2D[] _midCollision;
    [SerializeField]
    private Collider2D[] _bigCollision;

    private int _shrinkstatus = 2;

    private bool[] smallblist = new bool[3] { true, false, false };
    private bool[] midblist = new bool[3] { false, true, false };
    private bool[] bigblist = new bool[3] { false, false, true };

    private void Start()
    {
        update_colliders(midblist);
    }

    private void Update()
    {
        if(_shrinkstatus != GameManager.Instance.shrinker.shrinkstatus)
        {
            _shrinkstatus = GameManager.Instance.shrinker.shrinkstatus;
            switch (GameManager.Instance.shrinker.shrinkstatus)
            {
                case 1:
                    update_colliders(smallblist);
                    break;
                case 2:
                    update_colliders(midblist);
                    break;
                case 3:
                    update_colliders(bigblist);
                    break;
            }
        }
    }

    private void update_colliders(bool[] blist)
    {
        foreach (Collider2D col in _smallCollision)
        {
            col.enabled = blist[0];
        }
        foreach (Collider2D col in _midCollision)
        {
            col.enabled = blist[1];
        }
        foreach (Collider2D col in _bigCollision)
        {
            col.enabled = blist[2];
        }
    }
}
