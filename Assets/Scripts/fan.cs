using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fan : MonoBehaviour
{
    public Vector2 addedForce = new Vector2(1, 0);
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Particle")) {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(addedForce);
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Particle")) {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(addedForce);
        }
    }
}
