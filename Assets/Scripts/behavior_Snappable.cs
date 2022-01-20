using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this behavior to a 2D object to make it snappable via mouse(for now)
public class behavior_Snappable : MonoBehaviour
{

    public List<Transform> snapPoints;

    public List<behavior_Draggable> draggableObjects;

    public float snapRange = 0.5f;

    private void Start()
    {
        foreach (behavior_Draggable draggable in draggableObjects)
        {
            draggable.dragEndedCallback = OnDragEnded;
        }
    }


    private void OnDragEnded(behavior_Draggable draggable)
    {
        float distance_closest = -1.0f; // no such thing as negative dist
        Transform closestSnapPoint = null;

        foreach (Transform snapPoint in snapPoints)
        {
            float distance_current = Vector2.Distance(draggable.transform.position, snapPoint.localPosition);
            if (closestSnapPoint == null || distance_current < distance_closest)
            {
                closestSnapPoint = snapPoint;
                distance_closest = distance_current;
            }
        }

        if (closestSnapPoint != null && distance_closest <= snapRange)
        {
            draggable.transform.localPosition = closestSnapPoint.localPosition;
        }
    }
}
