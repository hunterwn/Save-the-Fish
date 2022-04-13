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
    private Vector3 previousPosition;
    [HideInInspector]
    public GridManager gridManager;
    private BoxCollider2D boxCollider;
    private List<Vector2> gridPoints;

    private Collider2D grabBox;

    private void CalculateGridPoints() {
        List<Vector2> newPoints = new List<Vector2>();
        Collider2D coll = gameObject.GetComponent<Collider2D>();
        Bounds bounds = coll.bounds;
        Vector2 bottomLeft = new Vector2(bounds.center.x - bounds.extents.x, bounds.center.y - bounds.extents.y);

        float y_val = bottomLeft.y;
        while(y_val <= bottomLeft.y + bounds.extents.y * 2) {
            float x_val = bottomLeft.x;
            while(x_val <= bottomLeft.x + bounds.extents.x * 2) {
                Vector2 newPoint = new Vector2(x_val, y_val);
                Collider2D hitColl = Physics2D.OverlapBox(newPoint, new Vector2(0.4f, 0.4f), 0);
                if(hitColl != null) {
                    newPoints.Add(newPoint);
                }
                x_val += 0.5f;
            }
            y_val += 0.5f;
        }
        gridPoints = newPoints;
    }

    private bool CheckGridPointsAvailable(Vector2 offset) {
        foreach(Vector2 point in gridPoints) {
            if(gridManager.checkPoint(point + offset)) {
                return false;
            }
        }
        return true;
    }
    
    private void AddOffsetToGridPoints(Vector2 offset) {
        for (int i = 0; i < gridPoints.Count; i++)
        {
            gridPoints[i] += offset;
            DrawBox(gridPoints[i], 0.2f, Color.green);
        }
    }
    public void OnMouseDown()
    {
        ActiveObject activeObject = gameObject.GetComponent<ActiveObject>();
        activeObject.SetInactive();
        isDragged = true;
        // CalculateGridPoints();
        Vector3 mousePosFromCamera = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDragStartPosition = new Vector3(mousePosFromCamera.x, mousePosFromCamera.y, 0);
        spriteDragStartPosition = transform.localPosition;

        //disable camera Pan/Zoom on touch or click
        Camera.main.GetComponent<Dossamer.PanZoom.PanZoomBehavior>().disableAllAxes();
    }

    public void OnMouseDrag()
    {
        if (isDragged)
        {
            Vector3 mousePosFromCamera = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPosition = spriteDragStartPosition + new Vector3(mousePosFromCamera.x, mousePosFromCamera.y, 0) -
                                      mouseDragStartPosition;
            Vector3 roundedPosition = RoundVec3toNearestHalf(newPosition);
            if(transform.localPosition != roundedPosition) {
                Vector3 offset = roundedPosition - transform.localPosition;

                if(CheckGridPointsAvailable(offset)) {
                    transform.localPosition = roundedPosition;
                    AddOffsetToGridPoints(offset);
                }
            }
        }
    }

    public void OnMouseUp()
    {
        ActiveObject activeObject = gameObject.GetComponent<ActiveObject>();
        activeObject.SetActive();
        isDragged = false;

        //enable camera Pan/Zoom on release
        Camera.main.GetComponent<Dossamer.PanZoom.PanZoomBehavior>().enableAllAxes();
    }

    private Vector3 RoundVec3toNearestHalf(Vector3 vec) {
        for (int i = 0; i < 3; i++)
        {
            vec[i] = (float)Math.Round(vec[i] * 2, MidpointRounding.AwayFromZero) / 2;
        }
        return vec;
    }


    //for debugging
    private void DrawBox(Vector2 center, float radius, Color color) {
        List<Vector3> corners = new List<Vector3>();
        corners.Add(new Vector3(center.x + radius, center.y + radius, 0));
        corners.Add(new Vector3(center.x + radius, center.y - radius, 0));
        corners.Add(new Vector3(center.x - radius, center.y - radius, 0));
        corners.Add(new Vector3(center.x - radius, center.y + radius, 0));

        Debug.DrawLine(corners[0], corners[1], color, Mathf.Infinity);
        Debug.DrawLine(corners[1], corners[2], color, Mathf.Infinity);
        Debug.DrawLine(corners[2], corners[3], color, Mathf.Infinity);
        Debug.DrawLine(corners[3], corners[0], color, Mathf.Infinity);
    }

    private void Start() {
        grabBox = gameObject.GetComponent<GrabBox>().grabCollider;
        grabBox.enabled = false;
        CalculateGridPoints();
        grabBox.enabled = true;
    }
}
