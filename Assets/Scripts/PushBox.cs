using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : ActiveObject
{
    public float pushForce = 250;
    public AudioSource pushButtonSound;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("RollerBall")) {
            pushButtonSound.Play();
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * pushForce);
        }
    }
}
