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
        GameObject go = new GameObject("Player");
        go.AddComponent<PlayerMovementController>();
        go.AddComponent<CharacterController>();
        go.AddComponent<FakeUnityService>();
        Vector3 original = go.transform.position;

        yield return new WaitForSeconds(0.1f);

        Vector3 actual = go.transform.position;

        Assert.AreNotEqual(original, actual);
    }

    [UnityTest]
    public IEnumerator MovementAndRotation_OnRotatingView_HasZXIncreasedInDifferentProportions()
    {
        GameObject player = new GameObject("TestPlayer");
        player.AddComponent<PlayerMovementController>();
        player.AddComponent<CharacterController>();
        player.AddComponent<FakeUnityService>();
        player.AddComponent<Camera>();
        player.AddComponent<CameraMovementController>();

        yield return new WaitForSeconds(0.1f);
        Vector3 origin = player.transform.position;

        yield return new WaitForSeconds(0.3f);

        Vector3 actual = player.transform.position;
        float xProportion = actual.x / origin.x;
        float zProportion = actual.z / origin.z;

        Assert.Greater(zProportion, xProportion);

    }
}
