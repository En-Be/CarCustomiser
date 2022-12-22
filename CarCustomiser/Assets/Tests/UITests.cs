using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UITests
{
    [UnitySetUp]
    public IEnumerator Setup()
    {
        SceneManager.LoadScene("Main");
        yield return null;
    }

    [UnityTest]
    public IEnumerator RotateClockwiseButton()
    {
        Setup();
        GameObject button = GameObject.Find("UI/RotateClockwise");
        GameObject turntable = GameObject.Find("Turntable");

        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.That(turntable.transform.eulerAngles.y, Is.EqualTo(1));
    }

    [UnityTest]
    public IEnumerator HoldRotateClockwiseButton()
    {
        Setup();
        GameObject button = GameObject.Find("UI/RotateClockwise");
        GameObject turntable = GameObject.Find("Turntable");

        ExecuteEvents.Execute(button, new PointerEventData (EventSystem.current), ExecuteEvents.pointerDownHandler);
        yield return null;
        yield return null;
        yield return null;
        ExecuteEvents.Execute(button, new PointerEventData (EventSystem.current), ExecuteEvents.pointerUpHandler);
        yield return null;

        Assert.That(turntable.transform.eulerAngles.y, Is.EqualTo(3));
    }

    [UnityTest]
    public IEnumerator RotateAntiClockwiseButton()
    {
        Setup();
        GameObject button = GameObject.Find("UI/RotateAntiClockwise");
        GameObject turntable = GameObject.Find("Turntable");

        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.That(turntable.transform.eulerAngles.y, Is.EqualTo(359));
    }

    [UnityTest]
    public IEnumerator HoldRotateAntiClockwiseButton()
    {
        Setup();
        GameObject button = GameObject.Find("UI/RotateAntiClockwise");
        GameObject turntable = GameObject.Find("Turntable");

        ExecuteEvents.Execute(button, new PointerEventData (EventSystem.current), ExecuteEvents.pointerDownHandler);
        yield return null;
        yield return null;
        yield return null;
        ExecuteEvents.Execute(button, new PointerEventData (EventSystem.current), ExecuteEvents.pointerUpHandler);
        yield return null;

        Assert.That(turntable.transform.eulerAngles.y, Is.EqualTo(357));
    }
}
