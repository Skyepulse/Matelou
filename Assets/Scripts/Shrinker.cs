using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinker : MonoBehaviour {

    public Camera mainCamera;
    public PlayerMovement player;
    public float shrinkFactor = 1.0f;
    public float shrinkSpeed = 1.0f;
    public bool canPickUpObjects = true;

    public const float smallshrink = 0.1f;
    public const float midshrink = 1f;
    public const float bigshrink = 1.5f;
    //Shrink status == 1 small, == 2 mid, == 3 big
    public int shrinkstatus = 2;

	private float _cameraBaseSize;
	private Vector3 _playerBaseSize;
    private float _currentShrink = 1.0f;

	void Start() {
        if(mainCamera != null) {
            _cameraBaseSize = mainCamera.orthographicSize;
        }
        if(player != null) {
            _playerBaseSize = player.transform.localScale;
        }
        
    }

    void Update() {
        //We check if we are currently shrinking:
        if (_isCurrentlyShrinking())
        {
            canPickUpObjects = false;
        } else
        {
            //We have to update the shrink factor first
            updateShrinkFactor();
            canPickUpObjects = true;
        }


        _currentShrink += (shrinkFactor - _currentShrink) * shrinkSpeed * Time.deltaTime;

        if (mainCamera == null || player == null) return;

        player.transform.localScale = Vector3.Scale(_playerBaseSize, new Vector3(player.facingRight ? 1 : -1, 1, 1)) * _currentShrink;
        mainCamera.orthographicSize = _cameraBaseSize * _currentShrink;

    }

    private void updateShrinkFactor()
    {
        switch (shrinkFactor)
        {
            case smallshrink:
                shrinkstatus = 1;
                break;
            case midshrink:
                shrinkstatus = 2;
                break;
            case bigshrink:
                shrinkstatus = 3;
                break;
        }
    }

    private bool _isCurrentlyShrinking()
    {
        if (Mathf.Abs(_currentShrink - shrinkFactor) >=0.09) return true;
        return false;
    }
}
