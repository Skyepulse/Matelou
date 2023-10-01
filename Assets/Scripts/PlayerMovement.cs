using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour {

    public float maxSpeed = 5.0f;
    public float jumpScale = 1.0f;
    public float gravityScale = 1.5f;

	[Header("Shrink parameters")]

	public float shrinkMax = 2;
	public float shrinkMedium = 1;
	public float shrinkMid = 0.1f;

	[Header("Jump parameters")]

	public float jumpFactorMax = 0.2f;
	public float jumpFactorMin = 1.5f;

	private Transform _transform;
	private Rigidbody2D _rb2D;
	private Collider2D _mainCollider;

    private bool _isGrounded = false;
    public bool facingRight = true;
    private float _velX = 0.0f;

    void Start() {
        _transform = transform;
        _rb2D = GetComponent<Rigidbody2D>();
        _mainCollider = GetComponent<Collider2D>();

        _rb2D.freezeRotation = true;
        _rb2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        _rb2D.gravityScale = gravityScale;
    }

    void Update() {
        _velX = Input.GetAxis("Horizontal");

        if(Mathf.Abs(_velX) > 0.1f) {
            if(_velX > 0 && !facingRight) {
                facingRight = true;
                _transform.localScale = new Vector3(Mathf.Abs(_transform.localScale.x), _transform.localScale.y, _transform.localScale.z);
            }
            if(_velX < 0 && facingRight) {
                facingRight = false;
                _transform.localScale = new Vector3(-Mathf.Abs(_transform.localScale.x), _transform.localScale.y, _transform.localScale.z);
            }
        }

        if(_isGrounded && Input.GetKey(KeyCode.Space)) {
            float playerHeight = _mainCollider.bounds.size.y;
            Debug.Log(playerHeight);
            float jumpHeight = Mathf.Sqrt(2 * _rb2D.gravityScale * Mathf.Abs(Physics2D.gravity.y) * jumpScale * playerHeight);

            _rb2D.velocity = new Vector2(_rb2D.velocity.x, jumpHeight);
        }
    }

	private void FixedUpdate() {
        Bounds colliderBounds = _mainCollider.bounds;
        Vector2 pointA = colliderBounds.min;
        Vector2 pointB = pointA + new Vector2(colliderBounds.max.x - colliderBounds.min.x, -0.1f);
        float diffX = (pointB.x - pointA.x) * 0.1f;

        pointA.x += diffX;
        pointB.x -= diffX;

		LayerMask mask = LayerMask.GetMask("Level");

		Collider2D[] colliders = Physics2D.OverlapAreaAll(pointA, pointB, mask);


        _isGrounded = false;

        foreach(Collider2D col in colliders) {
			if (col != _mainCollider) {
				_isGrounded = true;
				//break;
			}
		}

		_rb2D.velocity = new Vector2(_velX * maxSpeed, _rb2D.velocity.y);

        Debug.DrawLine(pointA, pointB, Color.green);
	}
}
