using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipCatalogueButton : MonoBehaviour
{
    public int buttonNumber;
    private Button button;
    public GameObject changeShipWindow;

    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OpenShipCatalogue);
    }

    void OpenShipCatalogue()
    {
        changeShipWindow.SetActive(true);
        Debug.Log("open catalogue");
    }

    public void CloseShipCatalogue()
    {
        changeShipWindow.SetActive(false);
        // Debug.Log("button pressed");
    }
}
