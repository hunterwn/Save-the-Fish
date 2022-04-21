using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingGear : ActiveObject
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
        {

            transform.Rotate(0, 0, 1);
        }
    }
}
