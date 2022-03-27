using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behavior_TapRotate : MonoBehaviour
{
    private bool isDragged = false;
    private Vector3 originalPosition;

    private void OnMouseDown()
    {
        originalPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if(transform.position != originalPosition) {
            isDragged = true;
        }
    }
    private void OnMouseUp()
    {
        if(!isDragged) {
            gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                gameObject.transform.eulerAngles.z + 90
            );
        } else {
            isDragged = false;
        }
    }
}
