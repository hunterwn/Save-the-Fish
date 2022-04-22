using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompleteVictory : MonoBehaviour
{
    public string menu;
    public Text points;
    public AudioSource menuButton;

    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.points -= (GlobalVariables.amountOfParts * 50000);
        points.text = "Score: " + GlobalVariables.points.ToString();
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
