using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> colourButtons = new List<GameObject>();

    [SerializeField]
    private GameObject buttonHolder, colourButton;


    public void CreateColourButtons(Color[] colours)
    {
        DestroyColourButtons();
        Debug.Log("make buttons");
        int pos = 0;
        foreach(Color c in colours)
        {   
            GameObject button = Instantiate(colourButton, buttonHolder.transform);
            button.transform.Translate(pos,0,0);
            button.GetComponent<Image>().color = c;
            colourButtons.Add(button);
            pos += 60;

        }
    }

    private void DestroyColourButtons()
    {
        foreach(GameObject g in colourButtons)
        {
            Destroy(g);
        }
        colourButtons = new List<GameObject>();
    }
}
