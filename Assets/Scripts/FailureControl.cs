using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailureControl : MonoBehaviour
{
    public string menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(menu);
    }

    public void Retry()
    {
        //SceneManager.LoadScene(GlobalVariables.currentLevel);
    }

    public void PreviousLevel()
    {
        //SceneManager.LoadScene(GlobalVariables.previousLevel);
    }
}
