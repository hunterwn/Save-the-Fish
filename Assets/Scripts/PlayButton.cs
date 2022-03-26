using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public ParticleGenerator particleGenerator;
    void OnMouseDown()
    {
        particleGenerator.BeginGenerating();
        Destroy(gameObject);
    }
}
