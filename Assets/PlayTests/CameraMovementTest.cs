using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraMovementTest
{
    GameObject go;

    [SetUp]
    public void SetUp()
    {
        go = new GameObject("player");
        go.AddComponent<Camera>();
        go.AddComponent<CameraMovementController>();

        go.AddComponent<FakeUnityService>();
    }


    [UnityTest]
    public IEnumerator CameraMovementController_WhenInstantiated_ContainsCamera()
    {
        yield return null;

        Camera expected = go.GetComponentInChildren<Camera>();
        Camera actual = go.GetComponent<CameraMovementController>().GetCamera();

        Assert.IsNotNull(expected);
        Assert.AreEqual(expected, actual);
    }

    [UnityTest]
    public IEnumerator RotateXCamera_WhenSecondsPass_HasRotatedPlayerOnYAxis()
    {
        go.transform.rotation = Quaternion.Euler(Vector3.zero);
        var originalYRotation = go.transform.rotation.y;
        yield return new WaitForSeconds(1f);

        var newYRotation = go.transform.rotation.y;
        float actual = newYRotation - originalYRotation;

        Assert.Less(actual, 0f);
    }

}