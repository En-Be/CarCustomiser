using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UITests : InputTestFixture
{
    [UnityTest]
    public IEnumerator TestGameStart()
    {
        GameObject playButton = GameObject.Find("UI/ClockwiseButton");
        GameObject turntable = GameObject.Find("Turntable");

        ClickUI(playButton);
        yield return null;

        Assert.That(turntable.transform.rotation.y, Is.GreaterThan(0));
    }
    
    public void ClickUI(GameObject uiElement)
    {
        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 screenPos = camera.WorldToScreenPoint(uiElement.transform.position);
        // Set(mouse.position, screenPos);
        // Click(mouse.leftButton);
    }
}
