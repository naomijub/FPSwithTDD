using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    public float xMovementSpeed = 20f;
    [SerializeField]
    public float yMovementSpeed = 35f;

    CharacterController controller;
    IUnityService unityService;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        unityService = GetComponent<IUnityService>();

    }

    void Update()
    {
        float horizontal = unityService.GetInputAxis("Horizontal");
        float vertical = unityService.GetInputAxis("Vertical");
        float deltaTime = unityService.GetDeltaTime();

        Vector3 movement = MovementOnX(horizontal, deltaTime) + MovementOnZ(vertical, deltaTime);

        controller.Move(movement);
    }

    public Vector3 MovementOnX(float axis, float deltaTime)
    {
        return transform.right * AuxFunctions.SensitivityInFrame(axis, xMovementSpeed, deltaTime);
    }

    public Vector3 MovementOnZ(float axis, float deltaTime)
    {
        return transform.forward * AuxFunctions.SensitivityInFrame(axis, yMovementSpeed, deltaTime);
    }
}
