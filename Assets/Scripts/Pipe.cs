using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public int waterLayer = 6;

    //Speed up stuck particles in pipe to avoid clogging
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.layer == waterLayer)
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            if(rb.velocity.magnitude < 2.0f) {
                other.gameObject.GetComponent<Rigidbody2D>().velocity *= 1.5f;
            }
        }
    }
}
