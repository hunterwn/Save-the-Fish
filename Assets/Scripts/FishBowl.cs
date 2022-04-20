using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class FishBowl : MonoBehaviour
{
    public int waterLayer = 6;
    public GameObject meter;
    private int waterCount = 0;

    private Vector3 change = new Vector3( 0, 0.004f, 0); 
    

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.layer == waterLayer)
        {
            waterCount += 1;
            meter.transform.localScale += change;
            meter.transform.position += change;

            //Check if filled bowl
            if(waterCount >= 240) SceneManager.LoadScene("Winscreen");
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.layer == waterLayer)
        {
            waterCount -= 1;
            meter.transform.localScale -= change;
            meter.transform.position -= change;
        }
    }
}
