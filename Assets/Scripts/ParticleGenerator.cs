using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    public ParticleManager particleManager;
    public Transform particle;
    public float spawnDelay = 0.01f;
    public Vector3 initialVelocity = Vector3.zero;

    void Start()
    {
        IEnumerator coroutine = WaitAndSpawnParticle(spawnDelay);
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndSpawnParticle(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if(particleManager.particleCount < particleManager.particleLimit) {
                GenerateParticle();
            }
        }
    }

    void GenerateParticle() {
        GameObject newParticle = Instantiate(particle, transform).gameObject;
        if(initialVelocity != Vector3.zero) {
            newParticle.GetComponent<Rigidbody2D>().AddForce(initialVelocity);
        }
        particleManager.particleCount += 1;
    }
}