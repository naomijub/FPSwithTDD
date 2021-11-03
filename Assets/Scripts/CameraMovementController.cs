using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    public float sensitivityX = 100f;
    public float sensitivityY = 80f;
    private Camera Camera;
    private IUnityService unityService;
    [SerializeField]
    private float xAxisRotation;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = true;

        Camera = GetComponentInChildren<Camera>();
        unityService = GetComponent<IUnityService>();
        xAxisRotation = 0;

    }

    void Update()
    {
        float mouseX = unityService.GetInputAxis("Mouse X");
        float mouseY = unityService.GetInputAxis("Mouse Y");
        float deltaTime = unityService.GetDeltaTime();

        RotateY(mouseY, deltaTime);
        RotateX(mouseX, deltaTime);
    }

    void RotateX(float mouseX, float deltaTime)
    {
        float mouseRotation = AuxFunctions.SensitivityInFrame(mouseX, sensitivityX, deltaTime);
        transform.Rotate(Vector3.up * mouseRotation);
    }

    void RotateY(float mouseY, float deltaTime)
    {
        float mouseRotation = AuxFunctions.SensitivityInFrame(mouseY, sensitivityY, deltaTime);
        xAxisRotation -= mouseRotation;
        xAxisRotation = Mathf.Clamp(xAxisRotation, -90f, 90f);

        Camera.transform.localRotation = Quaternion.Euler(xAxisRotation, 0f, 0f);
    }

    public Camera GetCamera() {
        return Camera;
    }
}
