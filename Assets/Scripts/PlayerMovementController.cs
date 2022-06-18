using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    public float xMovementSpeed = 20f;
    [SerializeField]
    public float yMovementSpeed = 35f;
    [SerializeField]
    public Vector3 velocity = Vector3.zero;
    [SerializeField]
    public Transform groundPosition;
    public LayerMask groundLayerMask;

    float gravity = -9.8f;
    float detectionSphereRadius = 0.5f;
    bool isGrounded;

    CharacterController controller;
    IUnityService unityService;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        unityService = GetComponent<IUnityService>();
        if (groundPosition.position == Vector3.zero)
        {
            groundPosition.position = transform.position - (Vector3.up * transform.localScale.y / 2);
        }
    }

    void Update()
    {
        float horizontal = unityService.GetInputAxis("Horizontal");
        float vertical = unityService.GetInputAxis("Vertical");
        float deltaTime = unityService.GetDeltaTime();

        Vector3 movement = MovementOnX(horizontal, deltaTime) + MovementOnZ(vertical, deltaTime);

        controller.Move(movement);
        ApplyGravity(deltaTime);
    }

    void ApplyGravity(float deltaTime)
    {
        CalculateGravityVelocity(deltaTime);
        controller.Move(velocity * deltaTime);
    }

    public void CalculateGravityVelocity(float deltaTime)
    {
        isGrounded = Physics.CheckSphere(groundPosition.position, detectionSphereRadius, groundLayerMask);

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -1f;
        } else
        {
            velocity.y += gravity * deltaTime;
        }
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
