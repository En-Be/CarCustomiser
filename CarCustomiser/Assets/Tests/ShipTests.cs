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
        Color c = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        ship.ChangeColour(c);
        yield return null;
        
        Assert.That(body.material.color, Is.EqualTo(c));
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

    [UnityTest]
    public IEnumerator ToggleBoosters()
    {
        Setup();
        Turntable turntable = GameObject.Find("Turntable").GetComponent<Turntable>();
        GameObject boosters;

        boosters = GameObject.FindGameObjectWithTag("Boosters");
        Assert.That(boosters, Is.EqualTo(null));

        turntable.ToggleBoosters();
        boosters = GameObject.FindGameObjectWithTag("Boosters");
        yield return null;
        Assert.That(boosters.activeInHierarchy, Is.EqualTo(true));

        turntable.ToggleBoosters();
        yield return null;
        Assert.That(boosters.activeInHierarchy, Is.EqualTo(false));
    }

    [UnityTest]
    public IEnumerator ToggleWeapons()
    {
        Setup();
        Turntable turntable = GameObject.Find("Turntable").GetComponent<Turntable>();
        GameObject weapons;

        weapons = GameObject.FindGameObjectWithTag("Weapons");
        Assert.That(weapons, Is.EqualTo(null));

        turntable.ToggleWeapons();
        weapons = GameObject.FindGameObjectWithTag("Weapons");
        yield return null;
        Assert.That(weapons.activeInHierarchy, Is.EqualTo(true));

        turntable.ToggleWeapons();
        yield return null;
        Assert.That(weapons.activeInHierarchy, Is.EqualTo(false));
    }

}
