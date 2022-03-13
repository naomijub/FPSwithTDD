using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CubeMovementTest
{
    GameObject go;

    [SetUp]
    public void SetUp()
    {
        go = new GameObject("test");
        go.AddComponent<CubeMovementController>();
        go.AddComponent<Rigidbody>();
        go.AddComponent<FakeUnityService>();
    }

    [UnityTest]
    public IEnumerator Movement_OneFrameSkipped_MovesCubePosition()
    {      
        Vector3 origin = go.transform.position;
                     
        yield return new WaitForSeconds(0.3f);
        Vector3 actual = go.transform.position;

        Assert.AreNotEqual(origin, actual);
    }
}
