using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Variables
    // [SerializeField] private float mouseSensitivity;

    //REF
    // private Transform parent;

    void Start()
    {
        //parent = transform.parent;
    }


    public Transform target;
    public float smoothSpeed = 10f;
    public Vector3 offset;

    void LateUpdate(){
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }


    private void Rotate(){
        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //parent.Rotate(Vector3.up, mouseX);
    }
}
