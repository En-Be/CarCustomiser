using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private TextMeshProUGUI totalPrice;
    
    [SerializeField]
    private int price;

    private void Awake()
    {
        Instance = this;
        totalPrice = GameObject.Find("UI/TotalPrice").GetComponent<TextMeshProUGUI>();
    }

    public int TotalPrice()
    {
        return price;
    }

    public void SetPrice(int i)
    {
        price = i;
        totalPrice.text = i.ToString();
    }

}
