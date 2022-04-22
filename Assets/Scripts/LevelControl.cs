using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public string menu;
    public AudioSource menuButton;


    // Start is called before the first frame update
    void Start()
    {
        //Update current scene
        GlobalVariables.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        menuButton.Play();
        SceneManager.LoadScene(menu);
    }

    public void Retry()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}

