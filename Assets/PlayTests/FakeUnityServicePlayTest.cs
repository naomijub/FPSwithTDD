using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeUnityServicePlayTest : MonoBehaviour, IUnityService
{
    public float GetDeltaTime() => 0.03f;

    public float GetInputAxis(string axis)
    {
        if (axis == "Horizontal")
        {
            return 0f;
        }
        else if (axis == "Vertical")
        {
            return 1f;
        }
        else if (axis == "Mouse X")
        {
            return 1f;
        }
        else
        {
            return 0f;
        }
    }
}
