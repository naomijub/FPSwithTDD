using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeYUnityService : MonoBehaviour, IUnityService
{
    public float GetDeltaTime() => 0.3f;

    public float GetInputAxis(string axis)
    {
        if (axis == "Horizontal")
        {
            return 1f;
        }
        else if (axis == "Vertical")
        {
            return -1f;
        }
        else if (axis == "Mouse Y")
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
    }
}
