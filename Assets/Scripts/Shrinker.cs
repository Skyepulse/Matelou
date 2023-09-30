using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinker : MonoBehaviour {

    public Camera mainCamera;
    public PlayerMovement player;
    public float shrinkFactor = 1.0f;

    private float _cameraBaseSize;
	private Vector3 _playerBaseSize;

	void Start() {
        if(mainCamera != null) {
            _cameraBaseSize = mainCamera.orthographicSize;
        }
        if(player != null) {
            _playerBaseSize = player.transform.localScale;
        }
        
    }

    void Update() {
        if (mainCamera == null || player == null) return;

        player.transform.localScale = _playerBaseSize * shrinkFactor;
        mainCamera.orthographicSize = _cameraBaseSize * shrinkFactor;

    }
}
