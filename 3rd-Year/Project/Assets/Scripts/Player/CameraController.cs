using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Movement")]
    public float currentX;
    public float CameraStaticY;
    public float sensitivity;
    public Quaternion rotation;

    [Header("Object To Look At")]
    public float distance;
    public Transform lookat;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LateUpdate()
    {
            currentX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

            Vector3 Direction = new Vector3(0, 0, -distance);
            rotation = Quaternion.Euler(CameraStaticY, currentX, 0);

            transform.position = lookat.position + rotation * Direction;
            transform.LookAt(lookat.position);
    }

    public void SensitivityAdjust(float value)
    {
        sensitivity = value;
    }
}
