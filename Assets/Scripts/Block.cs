using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DrawBox(gameObject.GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DrawBox(Collider2D coll) {
        Bounds boxBounds = coll.bounds;

        List<Vector3> corners = new List<Vector3>();
        corners.Add(new Vector3(boxBounds.center.x + boxBounds.extents.x, boxBounds.center.y + boxBounds.extents.y, 0));
        corners.Add(new Vector3(boxBounds.center.x + boxBounds.extents.x, boxBounds.center.y - boxBounds.extents.y, 0));
        corners.Add(new Vector3(boxBounds.center.x - boxBounds.extents.x, boxBounds.center.y - boxBounds.extents.y, 0));
        corners.Add(new Vector3(boxBounds.center.x - boxBounds.extents.x, boxBounds.center.y + boxBounds.extents.y, 0));

        Debug.DrawLine(corners[0], corners[1], Color.blue, 50.0f);
        Debug.DrawLine(corners[1], corners[2], Color.blue, 50.0f);
        Debug.DrawLine(corners[2], corners[3], Color.blue, 50.0f);
        Debug.DrawLine(corners[3], corners[0], Color.blue, 50.0f);
    }
}
