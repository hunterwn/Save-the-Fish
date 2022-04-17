using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRight : ActiveObject
{
    public float pushbyvalue = 5;
    public float pusheddistance = 0;
    public float rightlimit = 10;

    public float offset = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (active == false)
        {
            return;
        }
        else
        {
            float temp = transform.position.x + Time.deltaTime * pushbyvalue;
            temp *= (temp < 0.0f) ? -1.0f : 1.0f;
            
            if (pusheddistance < rightlimit)
            {
                pusheddistance += temp * 0.5f;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(temp, transform.position.y, transform.position.z), 0.2f);
            }
        }
    }
}
