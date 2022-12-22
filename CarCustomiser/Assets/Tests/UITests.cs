using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITests : InputTestFixture
{
    [UnitySetUp]
    public override void Setup()
    {
        base.Setup();
        SceneManager.LoadScene("Main");
    }

    [UnityTest]
    public IEnumerator RotateClockwiseButton()
    {
        yield return null;
        GameObject button = GameObject.Find("UI/RotateClockwise");
        GameObject turntable = GameObject.Find("Turntable");

        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.That(turntable.transform.rotation.y, Is.GreaterThan(0));
        TearDown();
    }
}
