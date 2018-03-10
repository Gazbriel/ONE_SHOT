using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector2 MaxMoveCameraZone;
    public Vector2 MinMoveCameraZone;

    private void Update()
    {
        if (target != null)
        {
            MoveCamera();
        }
    }

    private void MoveCamera()
    {
        Vector3 desirePosition = new Vector3(Mathf.RoundToInt(target.position.x) + offset.x, Mathf.RoundToInt(target.position.y) + offset.y, -10);
        if (desirePosition.x > MinMoveCameraZone.x && desirePosition.x < MaxMoveCameraZone.x)
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
    
}
