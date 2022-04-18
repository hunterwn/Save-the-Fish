using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spin objects Right over their center point.
public class SpinRight : ActiveObject
{
    private float rotAxis_z;
    public float rotSpeed = 25;
    private void FixedUpdate()
    {
        // check active status.
        if (active == false)
        {
            return;
        }
        else
        {
            rotAxis_z += Time.deltaTime * rotSpeed * (-1.0f);
        }
        transform.rotation = Quaternion.Euler(0, 0, rotAxis_z);
        return;
    }
}
