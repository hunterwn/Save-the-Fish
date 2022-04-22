using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string level1;
    public string level2;
    public string level3;
    public static int previousSceneIndex;
    public AudioSource menuButton;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1()
    {
        menuButton.Play();
        SceneManager.LoadScene(level1);
    }

    public void Level2()
    {
        menuButton.Play();
        SceneManager.LoadScene(level2);
    }
    public void Level3()
    {
        menuButton.Play();
        SceneManager.LoadScene(level3);
    }

    public void QuitGame()
    {
        menuButton.Play();
        Application.Quit();
    }

}
