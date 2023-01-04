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
    public UIManager uiManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentShip = GameObject.FindWithTag("Ship");
        if(currentShip == null)
        {
            SpawnShip(0);
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
        SpawnShip(i);
    }

    public void SpawnShip(int i)
    {
        currentShip = Instantiate(ships[i], this.transform);
        Ship ship = currentShip.GetComponent<Ship>();
        ChangeColour(ship.colours[0]);
        gameManager.SetPrice(GetTotalPrice());
        uiManager.CreateColourButtons(ship.Colours());
    }

    public void ChangeColour(Color c)
    {
        currentShip.GetComponent<Ship>().ChangeColour(c);
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
