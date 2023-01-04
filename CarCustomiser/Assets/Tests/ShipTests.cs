using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
// using UnityEngine.ColorUtility;

public class ShipTests
{
    [UnitySetUp]
    public IEnumerator Setup()
    {
        SceneManager.LoadScene("Main");
        yield return null;
        Debug.Log(SceneManager.GetActiveScene().name);
    }

    [UnityTest]
    public IEnumerator ChangeShipColour()
    {
        Setup();
        Ship ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<Ship>();
        Renderer body = GameObject.FindGameObjectWithTag("Body").GetComponent<Renderer>();


        ship.ChangeColour(0);
        yield return null;
        
        Assert.That(ColorUtility.ToHtmlStringRGB(body.material.color), Is.EqualTo("9FACCD"));
        

        ship.ChangeColour(1);
        yield return null;

        Assert.That(ColorUtility.ToHtmlStringRGB(body.material.color), Is.EqualTo("CC9FA7"));

        
        ship.ChangeColour(2);
        yield return null;

        Assert.That(ColorUtility.ToHtmlStringRGB(body.material.color), Is.EqualTo("F8F2B8"));
    }

    [UnityTest]
    public IEnumerator ColourChoicePersists()
    {
        Setup();
        Ship ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<Ship>();
        Renderer body = GameObject.FindGameObjectWithTag("Body").GetComponent<Renderer>();
        Turntable turntable = GameObject.Find("Turntable").GetComponent<Turntable>();

        turntable.ChangeColour(1);
        yield return null;
        turntable.ChangeShip(0);
        yield return null;
        
        body = GameObject.FindGameObjectWithTag("Body").GetComponent<Renderer>();
        Assert.That(ColorUtility.ToHtmlStringRGB(body.material.color), Is.EqualTo("CC9FA7"));
    }

    [UnityTest]
    public IEnumerator ChangeShipBase()
    {
        Setup();
        Turntable turntable = GameObject.Find("Turntable").GetComponent<Turntable>();
        GameObject body;

        turntable.ChangeShip(0);
        yield return null;
        body = GameObject.FindGameObjectWithTag("Body");
        Assert.That(body.name, Is.EqualTo("ship_00_base"));

        turntable.ChangeShip(1);
        yield return null;
        body = GameObject.FindGameObjectWithTag("Body");
        Assert.That(body.name, Is.EqualTo("ship_01_base"));
        
        turntable.ChangeShip(2);
        yield return null;
        body = GameObject.FindGameObjectWithTag("Body");
        Assert.That(body.name, Is.EqualTo("ship_02_base"));
    }

    [UnityTest]
    public IEnumerator ToggleShields()
    {
        Setup();
        Turntable turntable = GameObject.Find("Turntable").GetComponent<Turntable>();
        GameObject shields;

        shields = GameObject.FindGameObjectWithTag("Shields");
        Assert.That(shields, Is.EqualTo(null));

        turntable.ToggleShields();
        shields = GameObject.FindGameObjectWithTag("Shields");
        yield return null;
        Assert.That(shields.activeInHierarchy, Is.EqualTo(true));

        turntable.ToggleShields();
        yield return null;
        Assert.That(shields.activeInHierarchy, Is.EqualTo(false));
    }

}
