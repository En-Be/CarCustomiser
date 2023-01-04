using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turntable : MonoBehaviour
{
    public GameManager gameManager;
    bool isRotatingClockwise = false;
    bool isRotatingAntiClockwise = false;
    public GameObject[] ships;
    public GameObject currentShip;
    public Color[] colours;
    public int currentColour;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentShip = GameObject.FindWithTag("Ship");
        if(currentShip == null)
        {
            currentShip = Instantiate(ships[0], this.transform);
            gameManager.SetPrice(currentShip.GetComponent<Ship>().Price());
        }
    }

    void Update()
    {
        if(isRotatingClockwise)
        {
            RotateClockwise();
        }

        if(isRotatingAntiClockwise)
        {
            RotateAntiClockwise();
        }
    }

    public void RotateClockwise()
    {
        gameObject.transform.Rotate(0,1,0);
        Debug.Log("rotated clockwise; y = " + transform.eulerAngles.y);
    }

    public void RotateAntiClockwise()
    {
        gameObject.transform.Rotate(0,-1,0);
        Debug.Log("rotated clockwise; y = " + transform.eulerAngles.y); 
    }

    public void SwitchClockwiseRotationOn()
    {
        isRotatingClockwise = true;
    }

    public void SwitchClockwiseRotationOff()
    {
        isRotatingClockwise = false;
    }

    public void SwitchAntiClockwiseRotationOn()
    {
        isRotatingAntiClockwise = true;
    }

    public void SwitchAntiClockwiseRotationOff()
    {
        isRotatingAntiClockwise = false;
    }

    public void ChangeShip(int i)
    {
        Destroy(currentShip);
        currentShip = Instantiate(ships[i], this.transform);
        currentShip.GetComponent<Ship>().ChangeColour(currentColour);
        gameManager.SetPrice(GetTotalPrice());
    }

    public void ChangeColour(int i)
    {
        currentColour = i;
        currentShip.GetComponent<Ship>().ChangeColour(i);
    }

    public void ToggleShields()
    {
        currentShip.GetComponent<Ship>().ToggleShields();
        gameManager.SetPrice(GetTotalPrice());

    }

    public void ToggleBoosters()
    {
        currentShip.GetComponent<Ship>().ToggleBoosters();
        gameManager.SetPrice(GetTotalPrice());
    }

    public void ToggleWeapons()
    {
        currentShip.GetComponent<Ship>().ToggleWeapons();
        gameManager.SetPrice(GetTotalPrice());
    }

    public int GetTotalPrice()
    {
        return currentShip.GetComponent<Ship>().Price();
    }

}
