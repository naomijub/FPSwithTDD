using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerAliveTestScript
{
    GameObject go;

    [SetUp]
    public void SetUp() { 
        go = new GameObject("test");
        go.AddComponent<PlayerLife>();
     }

    [Test]
    public void IsAlive_WhenInstantiated_ReturnsTrue()
    {
        PlayerLife player = go.GetComponent<PlayerLife>();

        Assert.AreEqual(true,player.IsAlive());
    }
}


