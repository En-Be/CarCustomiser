using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourButton : MonoBehaviour
{
    public Color color;
    public Ship ship;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(ChangeColour);
        color = this.GetComponent<Image>().color;
    }

    void ChangeColour()
    {
        Turntable turntable = GameObject.Find("Turntable").GetComponent<Turntable>();
        turntable.ChangeColour(color);
    }
}
