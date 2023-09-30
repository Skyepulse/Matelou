using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinker : MonoBehaviour {

    public Camera mainCamera;
    public PlayerMovement player;
    public float shrinkFactor = 1.0f;
    public float shrinkSpeed = 1.0f;

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

        _currentShrink += (shrinkFactor - _currentShrink) * shrinkSpeed * Time.deltaTime;

        if (mainCamera == null || player == null) return;

        player.transform.localScale = Vector3.Scale(_playerBaseSize, new Vector3(player.facingRight ? 1 : -1, 1, 1)) * _currentShrink;
        mainCamera.orthographicSize = _cameraBaseSize * _currentShrink;

    }
}
