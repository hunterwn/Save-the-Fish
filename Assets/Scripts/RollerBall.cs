using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBall : ActiveObject
{
    private bool activated = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(active && !activated) {
            activated = true;
            this.gameObject.AddComponent<Rigidbody2D>();
        }
    }
}
