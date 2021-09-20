using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementSpeedTest
{
    GameObject go;
    PlayerMovementController moveController;
    CameraMovementController cameraController;

    [SetUp]
    public void SetUp()
    {
        go = new GameObject("Player");
        go.AddComponent<PlayerMovementController>();
        go.AddComponent<CameraMovementController>();
        moveController = go.GetComponent<PlayerMovementController>();
        cameraController = go.GetComponent<CameraMovementController>();
    }

    // A Test behaves as an ordinary method
    [Test]
    public void XMovementInFrame_WhenEverythingElseIs1_ReturnsTheXSpeed()
    {
        float deltaTime = 1f;
        float horizontal = 1f;

        float frameSpeed = AuxFunctions.SensitivityInFrame(horizontal, moveController.xMovementSpeed, deltaTime);

        Assert.AreEqual(20f, frameSpeed);
    }

    [Test]
    public void XMovementInFrame_WhenDeltaTimeIsShort_ReturnsTheXSpeedInTheFrame() {
        float deltaTime = 0.1f;
        float horizontal = 1f;

        float frameSpeed = AuxFunctions.SensitivityInFrame(horizontal, moveController.xMovementSpeed, deltaTime);

        Assert.AreEqual(2f, frameSpeed);
    }

    [Test]
    public void XMovementInFrame_WhenHorizontalAxisIsNegative_ReturnsTheXSpeedInTheFrame() {
        float deltaTime = 0.1f;
        float horizontal = -1f;

        float frameSpeed = AuxFunctions.SensitivityInFrame(horizontal, moveController.xMovementSpeed, deltaTime);

        Assert.AreEqual(-2f, frameSpeed);
    }

    [Test]
    public void CameraSensitivityOnX_WhenNothingIs1f_ReturnsSensitivityOnFrame()
    {
        float mouseX = 45f;
        float deltaTime = 0.015f;

        float xRotation = AuxFunctions.SensitivityInFrame(mouseX, cameraController.sensitivityX, deltaTime);

        Assert.AreEqual(xRotation, 67.5f);
    }

    [Test]
    public void CameraSensitivityOnY_WhenNothingIs1f_ReturnsSensitivityOnFrame()
    {
        float mouseY = 45f;
        float deltaTime = 0.015f;

        float yRotation = AuxFunctions.SensitivityInFrame(mouseY, cameraController.sensitivityY, deltaTime);

        Assert.AreEqual(yRotation, 54f);
    }

    [Test]
    public void MovementOnX_WhenValuesAreNot1f_ReturnsNegativeRightVector3()
    {
        float axis = -1f;
        float deltaTime = 0.1f;
        Vector3 expected = Vector3.left * 2f;

        Vector3 actual = moveController.MovementOnX(axis, deltaTime);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void MovementOnZ_WhenValuesAreNot1f_ReturnsNegativeForwardVector3()
    {
        float axis = -1f;
        float deltaTime = 0.1f;
        Vector3 expected = Vector3.back * 3.5f;

        Vector3 actual = moveController.MovementOnZ(axis, deltaTime);

        Assert.AreEqual(expected, actual);
    }
}
