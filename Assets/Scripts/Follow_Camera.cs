using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Camera : MonoBehaviour
{
    //private
    private Camera _cam;
    private Transform _transform;
    private Vector2 _cam_offset;

    //Serialized
    [SerializeField]
    private Transform _camera_target;

    //public
    public float smoothspeed = 5f;

    void Start()
    {
        _cam = this.GetComponent<Camera>();
        _transform = this.transform;
        _cam_offset = new Vector2(_transform.position.x, transform.position.y);
    }

    private void LateUpdate()
    {
        if(_camera_target == null)
        {
            Debug.LogError("No target attached to the camera");
            return;
        }

        //We follow the target at each frame
        _move_target();
    }

    public void set_camera_position(Vector2 pos)
    {
        _transform.position = new Vector3(pos.x, pos.y, _transform.position.z);
    }

    //Smoothly move the camera to the new target's position
    private void _move_target()
    {
        Vector2 new_position = _camera_target.position;
        Vector2 target_smoothed_position = Vector2.Lerp(_transform.position, new_position, smoothspeed*Time.deltaTime);
        set_camera_position(target_smoothed_position);
    }
}
