using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnityService
{
    float GetDeltaTime();
    float GetInputAxis(string axis);
}
