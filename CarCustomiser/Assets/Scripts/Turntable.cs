using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turntable : MonoBehaviour
{
    public void RotateClockwise()
    {
        gameObject.transform.Rotate(0,1,0);
        Debug.Log("rotated clockwise");
    }

    public void RotateAntiClockwise()
    {
        gameObject.transform.Rotate(0,-1,0);
    }
}
