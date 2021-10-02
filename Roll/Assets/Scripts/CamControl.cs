using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField,Range(1f,10f)]
    float mouseSensitivity = 3.0f;

    Vector3 rotation;

    [SerializeField]
    Transform target;

    [SerializeField,Range(1f,10f)]
    float distanceFromTarget = 3.0f;

    Vector3 currentRotation;
    Vector3 smoothVelocity = Vector3.zero;

    float smoothTime = 0.1f;

    Vector2 ClampX = new Vector2(-40, 40);

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = -Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotation.y += mouseX;
        rotation.x += mouseY;

        rotation.x = Mathf.Clamp(rotation.x, ClampX.x, ClampX.y);

        Vector3 nextRotation = new Vector3(rotation.x, rotation.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        transform.localEulerAngles = currentRotation;

        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}

