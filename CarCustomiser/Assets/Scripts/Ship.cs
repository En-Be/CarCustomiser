using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Color[] colours;

    [SerializeField]
    private int basePrice;
    [SerializeField]
    private Renderer bodyRenderer;
    [SerializeField]
    private GameObject shields, boosters, weapons;

    private Accessory[] accessories;

    public string Colour()
    {
        return "Red";
    }

    public int Price()
    {
        int total = 0;
        total += basePrice;
        accessories = GetComponentsInChildren<Accessory>();
        foreach(Accessory a in accessories)
        {
            if(a.gameObject.activeInHierarchy == true)
            {
                total += a.Price();
            }
        }
        return total;
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
