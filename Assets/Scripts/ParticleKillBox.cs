using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleKillBox : MonoBehaviour
{
    public ParticleManager particleManager;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Particle")) {
            Destroy(other.gameObject);
            particleManager.particleCount -= 1;
        }
    }
}