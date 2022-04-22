using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotatingGear : ActiveObject
{
    public enum Direction {
         right,
         left
     };
    public Direction rotationDirection = Direction.right;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
        {
            if(rotationDirection == Direction.right) {
                transform.Rotate(0, 0, -1);
            } else {
                transform.Rotate(0, 0, 1);
            }
        }
    }
}
