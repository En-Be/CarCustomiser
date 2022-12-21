using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class testy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject turntable = GameObject.Find("Turntable");
        Debug.Log(turntable);
    }


}
