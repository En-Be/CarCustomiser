using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
// using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
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

    [UnityTest]
    public IEnumerator ChangeShipColourButtons()
    {
        Setup();
        Renderer body = GameObject.FindGameObjectWithTag("Body").GetComponent<Renderer>();
        GameObject button;

        button = GameObject.Find("UI/BaseColour/ChangeColour00");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.That(ColorUtility.ToHtmlStringRGB(body.material.color), Is.EqualTo("9FACCD"));
        

        button = GameObject.Find("UI/BaseColour/ChangeColour01");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.That(ColorUtility.ToHtmlStringRGB(body.material.color), Is.EqualTo("CC9FA7"));

        
        button = GameObject.Find("UI/BaseColour/ChangeColour02");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.That(ColorUtility.ToHtmlStringRGB(body.material.color), Is.EqualTo("F8F2B8"));
    }

    [UnityTest]
    public IEnumerator OpenShipCatalogue()
    {
        Setup();
        GameObject button;
        button = GameObject.Find("UI/OpenShipBodyCatalogue");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        GameObject window = GameObject.Find("UI/Ships");
        Assert.IsTrue(window.activeSelf);
    }

    [UnityTest]
    public IEnumerator CloseShipCatalogue()
    {
        Setup();
        GameObject button;
        button = GameObject.Find("UI/OpenShipBodyCatalogue");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        button = GameObject.Find("UI/Ships/ShipBody/Ship00");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        GameObject window = GameObject.Find("UI/Ships");
        Assert.IsNull(window);
    }

    [UnityTest]
    public IEnumerator ChangeShipBodyButtons()
    {
        Setup();
        GameObject body = GameObject.FindGameObjectWithTag("Body");
        GameObject button;
        GameObject catalogueButton;

        catalogueButton = GameObject.Find("UI/OpenShipBodyCatalogue");
        catalogueButton.GetComponent<Button>().onClick.Invoke();
        yield return null;

        button = GameObject.Find("UI/Ships/ShipBody/Ship00");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;
        body = GameObject.FindGameObjectWithTag("Body");
        Assert.That(body.name, Is.EqualTo("ship_00_base"));

        catalogueButton = GameObject.Find("UI/OpenShipBodyCatalogue");
        catalogueButton.GetComponent<Button>().onClick.Invoke();
        yield return null;

        button = GameObject.Find("UI/Ships/ShipBody/Ship01");
        Debug.Log(button);
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;
        body = GameObject.FindGameObjectWithTag("Body");
        Assert.That(body.name, Is.EqualTo("ship_01_base"));

        catalogueButton = GameObject.Find("UI/OpenShipBodyCatalogue");
        catalogueButton.GetComponent<Button>().onClick.Invoke();
        yield return null;

        button = GameObject.Find("UI/Ships/ShipBody/Ship02");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;
        body = GameObject.FindGameObjectWithTag("Body");
        Assert.That(body.name, Is.EqualTo("ship_02_base"));
    }

    [UnityTest]
    public IEnumerator ToggleShields()
    {
        Setup();
        GameObject button;
        button = GameObject.Find("UI/ToggleShields");

        GameObject shields;
        shields = GameObject.FindGameObjectWithTag("Shields");
        Assert.That(shields, Is.EqualTo(null));

        button.GetComponent<Button>().onClick.Invoke();
        yield return null;
        shields = GameObject.FindGameObjectWithTag("Shields");
        Assert.That(shields.activeInHierarchy, Is.EqualTo(true));

        button.GetComponent<Button>().onClick.Invoke();
        yield return null;
        shields = GameObject.FindGameObjectWithTag("Shields");
        Assert.That(shields, Is.EqualTo(null));
    }

    [UnityTest]
    public IEnumerator TotalPrice()
    {
        Setup();
        GameObject button;
        TextMeshProUGUI totalPrice = GameObject.Find("UI/TotalPrice").GetComponent<TextMeshProUGUI>();
        Debug.Log(totalPrice);
        Assert.That(totalPrice.text, Is.EqualTo("1000"));


        button = GameObject.Find("UI/OpenShipBodyCatalogue");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        button = GameObject.Find("UI/Ships/ShipBody/Ship01");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.That(totalPrice.text, Is.EqualTo("2000"));


        button = GameObject.Find("UI/OpenShipBodyCatalogue");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        button = GameObject.Find("UI/Ships/ShipBody/Ship02");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.That(totalPrice.text, Is.EqualTo("3000"));
    }

}
