using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovementController : MonoBehaviour
{
    public IUnityService unityService;

    [SerializeField]
    private float speed = 20f;   
    Rigidbody _rb;   
    
    void Start()   {     
        _rb = GetComponent<Rigidbody>();
        unityService = GetComponent<IUnityService>();
    }   
    
    void Update()   {
        var h = unityService.GetInputAxis("Horizontal");     
        var v = unityService.GetInputAxis("Vertical");
        var deltaTime = unityService.GetDeltaTime();
        Movement(h, v, deltaTime);
    }

    void Movement(float h, float v, float deltaTime)
    {
        float x = SpeedByFrame(h, deltaTime);
        float z = SpeedByFrame(v, deltaTime);
        _rb.MovePosition(CalculatePosition(transform.position, x, z));
    }

    public float SpeedByFrame(float axis, float deltaTime) => speed * axis * deltaTime;

    public Vector3 CalculatePosition(Vector3 position, float x, float z) => position + new Vector3(x, 0f, z);
}
