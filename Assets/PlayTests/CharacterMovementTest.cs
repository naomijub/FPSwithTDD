using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System;

public class CharacterMovementTest
{

    [UnityTest]
    public IEnumerator CharacterMovement_When1SecondPassed_MovesCharacter()
    {
        LayerMask groundMask = new LayerMask
        {
            value = 0
        };
        GameObject go = new GameObject("Player");
        go.AddComponent<PlayerMovementController>();
        go.AddComponent<CharacterController>();
        go.AddComponent<FakeUnityService>();
        PlayerMovementController moveController = go.GetComponent<PlayerMovementController>();
        moveController.groundLayerMask = groundMask;
        moveController.groundPosition = (new GameObject("Ground position")).transform;


        Vector3 original = go.transform.position;

        yield return new WaitForSeconds(0.1f);

        Vector3 actual = go.transform.position;

        Assert.AreNotEqual(original, actual);
    }

    [UnityTest]
    public IEnumerator MovementAndRotation_OnRotatingView_HasZXIncreasedInDifferentProportions()
    {
        LayerMask groundMask = new LayerMask
        {
            value = 0
        };
        GameObject go = new GameObject("Player");
        go.AddComponent<PlayerMovementController>();
        go.AddComponent<CharacterController>();
        go.AddComponent<FakeUnityService>();
        go.AddComponent<Camera>();
        go.AddComponent<CameraMovementController>();
        PlayerMovementController moveController = go.GetComponent<PlayerMovementController>();
        moveController.groundLayerMask = groundMask;
        moveController.groundPosition = (new GameObject("Ground position")).transform;

        yield return new WaitForSeconds(0.1f);
        Vector3 origin = go.transform.position;

        yield return new WaitForSeconds(0.3f);

        Vector3 actual = go.transform.position;
        float xProportion = actual.x / origin.x;
        float zProportion = actual.z / origin.z;

        Assert.Greater(zProportion, xProportion);

    }

    [UnityTest]
    public IEnumerator ApplyGravity_AfterSeconds_MovesCubeDown()
    {
        LayerMask groundMask = new LayerMask
        {
            value = 0
        };
        GameObject go = new GameObject("Player");
        go.AddComponent<PlayerMovementController>();
        go.AddComponent<CharacterController>();
        go.AddComponent<UnityService>();
        PlayerMovementController moveController = go.GetComponent<PlayerMovementController>();
        moveController.groundLayerMask = groundMask;
        moveController.groundPosition = (new GameObject("Ground position")).transform;

        Vector3 original = go.transform.position;

        yield return new WaitForSeconds(0.1f);
        Vector3 actual = go.transform.position;

        Assert.AreNotEqual(original, actual);
        Assert.Less(actual.y, -0.045f);
        Assert.Greater(actual.y, -0.12f);

        yield return new WaitForSeconds(0.1f);
        Vector3 actual2 = go.transform.position;

        Assert.AreNotEqual(actual, actual2);
        Assert.Less(actual2.y, -0.22f);
        Assert.Greater(actual2.y, -0.33f);
    }

    [UnityTest]
    public IEnumerator ApplyGravity_WehnHitsGround_VelocityIsZero()
    {
        LayerMask groundMask = new LayerMask
        {
            value = 3
        };

        GameObject go = new GameObject("Player");
        go.AddComponent<PlayerMovementController>();
        go.AddComponent<CharacterController>();
        go.AddComponent<UnityService>();
        PlayerMovementController moveController = go.GetComponent<PlayerMovementController>();
        moveController.groundLayerMask = groundMask;
        moveController.groundPosition = (new GameObject("Ground position")).transform;

        Vector3 original = go.transform.position;

        GameObject ground = new GameObject("Ground");
        ground.transform.localScale = new Vector3(100f, 1f, 100f);
        ground.transform.position = Vector3.down * 3;
        ground.AddComponent<BoxCollider>();
        ground.layer = 3;

        yield return new WaitForSeconds(3f);
        Vector3 actual = go.transform.position;
        Assert.Less(actual.y, original.y);
        Assert.That(Mathf.Approximately(actual.y, -1.42f));
        Assert.Less(-1.3f, moveController.velocity.y);
    }
}
