using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PriceTests
{
    [UnitySetUp]
    public IEnumerator Setup()
    {
        SceneManager.LoadScene("Main");
        yield return null;
    }

    [UnityTest]
    public IEnumerator ModelsHavePrices()
    {
        Setup();
        GameObject button;
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        button = GameObject.Find("UI/OpenShipBodyCatalogue");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        button = GameObject.Find("UI/Ships/ShipBody/Ship00");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.That(gameManager.TotalPrice(), Is.EqualTo(1000));
    }

    [UnityTest]
    public IEnumerator ModelsHaveDifferentPrices()
    {
        Setup();
        GameObject button;
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        button = GameObject.Find("UI/OpenShipBodyCatalogue");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        button = GameObject.Find("UI/Ships/ShipBody/Ship01");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.That(gameManager.TotalPrice(), Is.EqualTo(2000));

        
        button = GameObject.Find("UI/OpenShipBodyCatalogue");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        button = GameObject.Find("UI/Ships/ShipBody/Ship02");
        button.GetComponent<Button>().onClick.Invoke();
        yield return null;

        Assert.That(gameManager.TotalPrice(), Is.EqualTo(3000));
    }
}
