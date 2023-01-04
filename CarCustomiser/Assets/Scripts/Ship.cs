using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Color[] colours;
    public Renderer bodyRenderer;
    public GameObject shields;

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
}
