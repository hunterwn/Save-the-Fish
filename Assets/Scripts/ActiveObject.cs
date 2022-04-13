using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObject : MonoBehaviour
{
    private bool active = false;

    public void SetInactive() {
        this.active = true;
    }

    public void SetActive() {
        this.active = false;
    }
}
