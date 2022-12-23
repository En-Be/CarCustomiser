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
        Ship ship = GameObject.Find("Ship").GetComponent<Ship>();
        Renderer body = GameObject.Find("Body").GetComponent<Renderer>();


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
}
