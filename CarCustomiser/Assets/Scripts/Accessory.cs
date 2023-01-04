using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory : MonoBehaviour
{
    [SerializeField]
    private int price;

    public int Price()
    {
        return price;
    }
}
