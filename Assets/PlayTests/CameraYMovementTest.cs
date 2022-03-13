using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraYMovementTest
{
    GameObject go;

    [SetUp]
    public void SetUp()
    {
        go = new GameObject("player");
        go.AddComponent<Camera>();
        go.AddComponent<CameraMovementController>();

        go.AddComponent<FakeYUnityService>();
    }


    [UnityTest]
    public IEnumerator RotateYCamera_WhenSecondsPass_HasRotatedPlayerOnXAxis()
    {
        var originalCameraXRotation = go.GetComponent<Camera>().transform.localRotation.x;
        yield return new WaitForSeconds(1f);

        var newCameraXRotation = go.GetComponent<Camera>().transform.localRotation.x;

        Assert.Greater(newCameraXRotation, originalCameraXRotation);
    }

    [UnityTest]
    public IEnumerator RotateYCamera_WhenSecondsPass_IsClamped()
    {
        go.GetComponent<Camera>().transform.localRotation = Quaternion.Euler(89f, 0, 0);
        yield return new WaitForSeconds(1f);

        var newCameraXRotation = go.GetComponent<Camera>().transform.localRotation.x;
        Assert.Greater(newCameraXRotation, 0.69f);

        yield return new WaitForSeconds(1f);

        var secondNewCameraXRotation = go.GetComponent<Camera>().transform.localRotation.x;
        Assert.AreEqual(secondNewCameraXRotation, newCameraXRotation);
    }
}
