using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// spin objects left over their center point.
public class SpinLeft : ActiveObject
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
            rotAxis_z += Time.deltaTime * rotSpeed;
        }
        transform.rotation = Quaternion.Euler(0, 0, rotAxis_z);
        return;
    }
}
