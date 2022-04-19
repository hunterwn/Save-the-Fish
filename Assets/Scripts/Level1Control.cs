using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Control : MonoBehaviour
{
    public string menu;
    

    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.currentLevel = "Level1";
        GlobalVariables.previousLevel = "Title";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(menu);
    }
}

