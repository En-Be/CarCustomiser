using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Color[] colours;
    public Renderer bodyRenderer;

    public string Colour()
    {
        return "Red";
    }

    public void ChangeColour(int i)
    {
        bodyRenderer.material.SetColor("_Color", colours[i]);
    }
}
