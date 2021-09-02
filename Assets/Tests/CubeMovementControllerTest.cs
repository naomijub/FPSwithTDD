using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CubeMovementControllerTest
{
    GameObject go;

    [SetUp]
    public void SetUp()
    {
        go = new GameObject("test");
        go.AddComponent<CubeMovementController>();
    }

    [Test]
    public void SpeedByFrame_WhenDeltaTimeAndAxisArePositive_ReturnsSpeedInFrame() {
        float deltaTime = 0.3f;
        float axis = 1f;
        CubeMovementController moveController = go.GetComponent<CubeMovementController>();

        float actualSpeed = moveController.SpeedByFrame(axis, deltaTime);

        Assert.AreEqual(actualSpeed, 6f);
    }

    [Test]
    public void SpeedByFrame_WhenAxisIsZero_Returns0f()
    {
        float deltaTime = 0.3f;
        float axis = 0f;
        CubeMovementController moveController = go.GetComponent<CubeMovementController>();

        float actualSpeed = moveController.SpeedByFrame(axis, deltaTime);

        Assert.AreEqual(actualSpeed, 0f);
        Assert.That(Mathf.Approximately(actualSpeed, 0f));
    }

    [Test]
    public void CalculatePostion_WhenXZAreZero_ReturnSamePosition()
    {
        Vector3 originalPosition = Vector3.zero;
        CubeMovementController moveController = go.GetComponent<CubeMovementController>();

        Vector3 movedPosition = moveController.CalculatePosition(originalPosition, 0f, 0f);

        Assert.AreEqual(originalPosition, movedPosition);
    }

    [Test]
    public void CalculatePostion_WhenXIsPositive_ReturnIncreasedXAxisPosition()
    {
        Vector3 originalPosition = Vector3.zero;
        float x = 1f;
        CubeMovementController moveController = go.GetComponent<CubeMovementController>();

        Vector3 movedPosition = moveController.CalculatePosition(originalPosition, x, 0f);

        Assert.AreEqual(Vector3.right, movedPosition);
    }

    [Test]
    public void CalculatePostion_WhenXandZArePositive_ReturnIncreasedPosition()
    {
        Vector3 originalPosition = Vector3.zero;
        float x = 2f;
        float z = 2f;
        CubeMovementController moveController = go.GetComponent<CubeMovementController>();

        Vector3 movedPosition = moveController.CalculatePosition(originalPosition, x, z);

        Assert.AreEqual(new Vector3(2f, 0f, 2f), movedPosition);
    }

}
