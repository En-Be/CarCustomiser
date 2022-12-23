using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turntable : MonoBehaviour
{
    bool isRotatingClockwise = false;
    bool isRotatingAntiClockwise = false;


    void Update()
    {
        if(isRotatingClockwise)
        {
            RotateClockwise();
        }

        if(isRotatingAntiClockwise)
        {
            RotateAntiClockwise();
        }
    }

    public void RotateClockwise()
    {
        gameObject.transform.Rotate(0,1,0);
        Debug.Log("rotated clockwise; y = " + transform.eulerAngles.y);
    }

    public void RotateAntiClockwise()
    {
        gameObject.transform.Rotate(0,-1,0);
        Debug.Log("rotated clockwise; y = " + transform.eulerAngles.y); 
    }

    public void SwitchClockwiseRotationOn()
    {
        isRotatingClockwise = true;
    }

    public void SwitchClockwiseRotationOff()
    {
        isRotatingClockwise = false;
    }

    public void SwitchAntiClockwiseRotationOn()
    {
        isRotatingAntiClockwise = true;
    }

    public void SwitchAntiClockwiseRotationOff()
    {
        isRotatingAntiClockwise = false;
    }

}
