using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float gridWidth = 0.5f;
    [HideInInspector]
    private List<Vector2> gridPoints = new List<Vector2>();

    public void addPoint(Vector2 newPoint) {
        gridPoints.Add(RoundVec2toNearestHalf(newPoint));
    }

    public bool checkPoint(Vector2 point) {
        return gridPoints.Contains(RoundVec2toNearestHalf(point));
    }

    private Vector2 RoundVec2toNearestHalf(Vector2 vec) {
        for (int i = 0; i < 2; i++)
        {
            vec[i] = (float)Math.Round(vec[i] * 2, MidpointRounding.AwayFromZero) / 2;
        }
        return vec;
    }
}
