using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyButton : MonoBehaviour
{
    public int buttonNumber;
    public Turntable turntable;
    private Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(ChangeBody);
        turntable = GameObject.Find("Turntable").GetComponent<Turntable>();
    }

    void ChangeBody()
    {
        turntable.ChangeShip(buttonNumber);
        Debug.Log("button pressed");
    }
}
