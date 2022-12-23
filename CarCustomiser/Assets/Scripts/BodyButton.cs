using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyButton : MonoBehaviour
{
    public int buttonNumber;
    public Turntable turntable;
    private Button button;
    private ShipCatalogueButton catalogueButton;

    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(ChangeBody);
        turntable = GameObject.Find("Turntable").GetComponent<Turntable>();
        catalogueButton = GameObject.Find("UI/OpenShipBodyCatalogue").GetComponent<ShipCatalogueButton>();

    }

    void ChangeBody()
    {
        turntable.ChangeShip(buttonNumber);
        catalogueButton.CloseShipCatalogue();
        Debug.Log("change body");
    }
}
