using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Sizing : MonoBehaviour
{
    [SerializeField]
    private Collider2D _smallCollision;
    [SerializeField]
    private Collider2D _midCollision;
    [SerializeField]
    private Collider2D _bigCollider;

    private void Start()
    {
        _smallCollision.enabled = false;
        _midCollision.enabled = true;
        _bigCollider.enabled = false;
    }

    private void Update()
    {
        switch (GameManager.Instance.shrinker.shrinkstatus)
        {
            case 1:
                _smallCollision.enabled = true;
                _midCollision.enabled = false;
                _bigCollider.enabled = false;
                break;
            case 2:
                _smallCollision.enabled = false;
                _midCollision.enabled = true;
                _bigCollider.enabled = false;
                break;
            case 3:
                _smallCollision.enabled = false;
                _midCollision.enabled = false;
                _bigCollider.enabled = true;
                break;
        }
    }
}
