using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMember : MonoBehaviour
{
    private GridManager gridManager;
    private void CalculateGridPoints() {
        float gridWidth = gridManager.gridWidth;

        Collider2D coll = gameObject.GetComponent<Collider2D>();
        Bounds bounds = coll.bounds;
        Vector2 bottomLeft = new Vector2(bounds.center.x - bounds.extents.x, bounds.center.y - bounds.extents.y);
        float y_val = bottomLeft.y;
        while(y_val <= bottomLeft.y + bounds.extents.y * 2) {
            float x_val = bottomLeft.x;
            while(x_val <= bottomLeft.x + bounds.extents.x * 2) {
                Vector2 newPoint = new Vector2(x_val, y_val);
                Collider2D hitColl = Physics2D.OverlapBox(newPoint, new Vector2(gridWidth / 2, gridWidth / 2), 0);
                if(hitColl != null) {
                    DrawBox(newPoint, 0.2f, Color.blue);
                    gridManager.addPoint(newPoint);
                }
                x_val += gridWidth;
            }
            y_val += gridWidth;
        }
    }

    void Start()
    {
        gridManager = transform.parent.gameObject.GetComponent<GridManager>();
        CalculateGridPoints();
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
}
