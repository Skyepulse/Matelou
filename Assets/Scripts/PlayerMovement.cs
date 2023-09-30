using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour {

    public float maxSpeed = 5.0f;
    public float jumpHeight = 10.0f;
    public float gravityScale = 1.5f;

    private Transform t;
	private Rigidbody2D rb2D;
	private Collider2D mainCollider;

    private bool isGrounded = false;
    private bool facingRight = true;
    private float velX = 0.0f;


    void Start() {
        t = transform;
        rb2D = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<Collider2D>();
    }

    void Update() {
        velX = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.Space)) {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
        }
    }

	private void FixedUpdate() {
        rb2D.velocity = new Vector2(velX * maxSpeed, rb2D.velocity.y);
	}
}
