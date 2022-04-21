using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public ParticleGenerator particleGenerator;
    void OnMouseDown()
    {
        particleGenerator.BeginGenerating();
        var foundActiveObjects = FindObjectsOfType<ActiveObject>();
        foreach(ActiveObject x in foundActiveObjects) {
            x.active = true;
        }
        Destroy(gameObject);
    }
}
