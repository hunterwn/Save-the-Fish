using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartTracker : MonoBehaviour
{
    public int partsLeft = 5;
    public Text text;

    private void Update() {
        text.text = partsLeft.ToString();
    }
}