using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityService : MonoBehaviour, IUnityService
{
    public float GetDeltaTime() => Time.deltaTime;
    public float GetInputAxis(string axis) => Input.GetAxis(axis);
}
