using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourButton : MonoBehaviour
{
    public int buttonNumber;
    public Ship ship;
    private Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(ChangeColour);
    }

    void ChangeColour()
    {
        ship = GameObject.Find("Turntable/Ship").GetComponent<Ship>();
        ship.ChangeColour(buttonNumber);
    }
}
