using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behavior_TapRotate : MonoBehaviour
{
    private bool isDragged = false;
    private Vector3 originalPosition;
    private behavior_Draggable dragBehavior;

    private void Start() {
        dragBehavior = gameObject.GetComponent<behavior_Draggable>();
    }

    private void OnMouseDown()
    {
        if(dragBehavior.gridManager.locked) {
            return;
        }
        originalPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if(dragBehavior.gridManager.locked) {
            return;
        }
        if(transform.position != originalPosition) {
            isDragged = true;
        }
    }
    private void OnMouseUp()
    {
        if(dragBehavior.gridManager.locked) {
            return;
        }
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
