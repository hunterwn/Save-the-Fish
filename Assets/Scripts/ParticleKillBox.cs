using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleKillBox : MonoBehaviour
{
    public ParticleManager particleManager;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Particle")) {
            Destroy(other.gameObject);
            particleManager.particleCount -= 1;
        }
    }
}