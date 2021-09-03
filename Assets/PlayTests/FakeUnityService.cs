using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeUnityService : MonoBehaviour, IUnityService
{
    public float GetDeltaTime() => 0.3f;

    public float GetInputAxis(string axis)
    {
        if (axis == "Horizontal")
        {
            return 1f;
        }
        else
        {
            return -1f;
        }
    }

}
