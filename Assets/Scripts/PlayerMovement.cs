using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour {

    public float maxSpeed = 5.0f;
    public float gravityScale = 1.5f;

    [Header("Jump parameters")]

    public float absoluteJumpMin;
	public float absoluteJumpMid;
	public float absoluteJumpMax;

	[Header("Speed parameters")]

    public float minSpeedMult = 3;
	public float maxSpeedMult = 1;

    [Header("Umbrella")]

    public GameObject umbrella;
    public float umbrellaAlpha;
    public bool _hasUmbrella = false;

    public float triggerTreshold = 1;

    private Transform _transform;
	private Rigidbody2D _rb2D;
	private Collider2D _mainCollider;

    private bool _isGrounded = false;
    [HideInInspector] public bool facingRight = true;
    private float _velX = 0.0f;
    private bool can_move = true;


    void Start() {
        _transform = transform;
        _rb2D = GetComponent<Rigidbody2D>();
        _mainCollider = GetComponent<Collider2D>();

        _rb2D.freezeRotation = true;
        _rb2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        _rb2D.gravityScale = gravityScale;
    }

    void Update() {
        if(can_move) _velX = Input.GetAxis("Horizontal");

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

        if(_isGrounded && Input.GetButtonDown("Jump")) {
			float shrink = GameManager.Instance.shrinker.getCurrentShrink();
			float desiredHeight = 0;

            if (shrink < Shrinker.smallshrink) desiredHeight = absoluteJumpMin;
            else if (shrink < Shrinker.midshrink) desiredHeight = _map(shrink, Shrinker.smallshrink, Shrinker.midshrink, absoluteJumpMin, absoluteJumpMid);
            else if (shrink < Shrinker.bigshrink) desiredHeight = _map(shrink, Shrinker.midshrink, Shrinker.bigshrink, absoluteJumpMid, absoluteJumpMax);
            else desiredHeight = absoluteJumpMax;

            float jumpHeight = Mathf.Sqrt(2 * _rb2D.gravityScale * Mathf.Abs(Physics2D.gravity.y) * desiredHeight);

            _rb2D.velocity = new Vector2(_rb2D.velocity.x, jumpHeight);
        }

        if(!_hasUmbrella) {
            if(_rb2D.velocity.y < -triggerTreshold) {
                _hasUmbrella = true;
            }
        }

        umbrella.SetActive(_hasUmbrella);
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
                _hasUmbrella = false;
				//break;
			}
		}
        float shrink = GameManager.Instance.shrinker.getCurrentShrink();
        float runScale = 1;
        if(shrink < Shrinker.midshrink)
    		runScale = _map(shrink, Shrinker.smallshrink, Shrinker.midshrink, minSpeedMult, maxSpeedMult);

		float speed = _mainCollider.bounds.size.x / 0.8f * maxSpeed * runScale;

		_rb2D.velocity = new Vector2(_velX * speed, _rb2D.velocity.y - (_hasUmbrella && _rb2D.velocity.y < 0 ? _rb2D.velocity.y * Time.deltaTime * umbrellaAlpha : 0));
	}

	private float _map(float value, float istart, float istop, float ostart, float ostop) {
		return ostart + (ostop - ostart) * ((value - istart) / (istop - istart));
	}
    public void setMovementsOff()
    {
        SetMovement(false);
        SetGravity(false);
    }
    public void SetMovement(bool enableMovement)
    {
        can_move = enableMovement;
    }

    public void SetGravity(bool enableGravity)
    {
        if(!enableGravity) GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        else GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        
    }
    
    public void setMovementOn()
    {
        SetMovement(true);
        SetGravity(true);
    }
}
