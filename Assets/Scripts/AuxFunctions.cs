using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuxFunctions
{
    public static float SensitivityInFrame(float axis, float sensitivity, float deltaTime)
    {
        return axis * sensitivity * deltaTime;
    }
}
