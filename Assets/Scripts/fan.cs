using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fan : MonoBehaviour
{
    bool waiting = false;
    public AudioSource fanSound;
    public Vector2 addedForce = new Vector2(1, 0);
    public Animator animator;
    private void Start() {
        animator.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Particle")) {
            if(!waiting) {
                fanSound.Play();
                StartCoroutine(WaitCoroutine());
            }
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

    IEnumerator WaitCoroutine()
    {
        waiting = true;
        animator.enabled = true;
        yield return new WaitForSeconds(1.5f);
        animator.enabled = false;
        waiting = false;
    }
}
