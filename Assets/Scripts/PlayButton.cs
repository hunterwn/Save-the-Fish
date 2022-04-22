using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public ParticleGenerator particleGenerator;
    public GridManager gridManager;
    void OnMouseDown()
    {
        particleGenerator.BeginGenerating();
        var foundActiveObjects = FindObjectsOfType<ActiveObject>();
        foreach(ActiveObject x in foundActiveObjects) {
            x.active = true;
        }
        gridManager.locked = true;
        Destroy(gameObject);
    }
}
