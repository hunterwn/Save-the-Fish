using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int previousSceneIndex;
    public static int points;
    public static int amountOfParts;

    // Start is called before the first frame update
    void Start()
    {
        previousSceneIndex = 0;
        points = 0;
        amountOfParts = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
