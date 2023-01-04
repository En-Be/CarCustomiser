using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Color[] colours;
    public Renderer bodyRenderer;
    public GameObject shields;
    public GameObject boosters;
    public GameObject weapons;
    
    [SerializeField]
    private int price;

    public string Colour()
    {
        return "Red";
    }

    public int Price()
    {
        return price;
    }

    public void ChangeColour(int i)
    {
        bodyRenderer.material.SetColor("_Color", colours[i]);
    }

    public void ToggleShields()
    {
        if(shields.activeInHierarchy)
        {
            shields.SetActive(false);
        }
        else
        {
            shields.SetActive(true);
        }
    }

    public void ToggleBoosters()
    {
        if(boosters.activeInHierarchy)
        {
            boosters.SetActive(false);
        }
        else
        {
            boosters.SetActive(true);
        }
    }

    public void ToggleWeapons()
    {
        if(weapons.activeInHierarchy)
        {
            weapons.SetActive(false);
        }
        else
        {
            weapons.SetActive(true);
        }
    }

}
