using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this behavior to a 2D object to make it draggable via mouse(for now)
public class behavior_Draggable : MonoBehaviour
{

    public delegate void DragEndedDelegate(behavior_Draggable draggableObject);

    public DragEndedDelegate dragEndedCallback;


    private bool isDragged = false;

    private Vector3 mouseDragStartPosition;

    private Vector3 spriteDragStartPosition;

    private void OnMouseDown()
    {
        isDragged = true;
        Vector3 mousePosFromCamera = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDragStartPosition = new Vector3(mousePosFromCamera.x, mousePosFromCamera.y, 0);
        spriteDragStartPosition = transform.localPosition;

        //disable camera Pan/Zoom on touch or click
        Camera.main.GetComponent<Dossamer.PanZoom.PanZoomBehavior>().disableAllAxes();
    }

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            Vector3 mousePosFromCamera = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.localPosition = spriteDragStartPosition + new Vector3(mousePosFromCamera.x, mousePosFromCamera.y, 0) -
                                      mouseDragStartPosition;
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;
        //dragEndedCallback(this);

        //enable camera Pan/Zoom on release
        Camera.main.GetComponent<Dossamer.PanZoom.PanZoomBehavior>().enableAllAxes();
    }
}
