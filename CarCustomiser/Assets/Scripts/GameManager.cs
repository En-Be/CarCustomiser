using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int price;

    public int TotalPrice()
    {
        return price;
    }

    public void SetPrice(int i)
    {
        price = i;
    }

}
