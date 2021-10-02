using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float cameraSmooth = 1;
    float lookUpMax = 60;
    float lookUpMin = -60;

    [SerializeField]
    Transform cam;

    Quaternion camRotation;
    RaycastHit hit;
    Vector3 cameraOffset;

    void Start()
    {
        camRotation = transform.localRotation;
        cameraOffset = cam.localPosition;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        camRotation.x += Input.GetAxis("Mouse Y") * cameraSmooth * (-1);
        camRotation.y += Input.GetAxis("Mouse X") * cameraSmooth;

        camRotation.x = Mathf.Clamp(camRotation.x, lookUpMin, lookUpMax);

        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);

        if (Physics.Linecast(transform.position, transform.position + transform.localRotation * cameraOffset, out hit))
        {
            cam.localPosition = new Vector3(0, 0.1f, - Vector3.Distance(transform.position, hit.point));
        }
        else
        {
            cam.localPosition = Vector3.Lerp(cam.localPosition, cameraOffset, Time.deltaTime);
        }
    }
}
