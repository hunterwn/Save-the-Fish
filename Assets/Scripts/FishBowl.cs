using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class FishBowl : MonoBehaviour
{
    public int waterLayer = 6;
    private int waterCount = 0;
    public AudioSource waterSound;

    private Vector3 change = new Vector3( 0, 0.004f, 0); 
    

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.layer == waterLayer)
        {
            collider.gameObject.transform.localScale *= 2;
            waterCount += 1;

            //Check if sound needs to be done
            if(waterCount % 10 == 0) waterSound.Play();

            //Check if filled bowl
            if (waterCount >= 60)
            {
                if(GlobalVariables.previousSceneIndex != 3) SceneManager.LoadScene("Winscreen");
                else SceneManager.LoadScene("Victory");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.layer == waterLayer)
        {
            waterCount -= 1;
        }
    }
}
