using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static string currentLevel;
    public static string previousLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = "Title";
        previousLevel = "Title";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
