using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class PartGeneratorButton : Button
{
    public GridManager gridManager;
    public Transform partToGenerate;
    private behavior_Draggable dragBehavior;
    public PartTracker partTracker;


    private bool mouseHeld = false;

    public override void OnPointerDown(PointerEventData eventData)
    {
        if(partTracker.partsLeft > 0) {
            GlobalVariables.amountOfParts++;
            partTracker.partsLeft--;
            base.OnPointerDown(eventData);
            mouseHeld = true;
            //Generate the new part
            Vector3 mousePosFromCamera = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 instancePosition = new Vector3(mousePosFromCamera.x, mousePosFromCamera.y, 10);
            Transform newPart = Instantiate(partToGenerate, instancePosition, Quaternion.identity);
            dragBehavior = newPart.gameObject.GetComponent<behavior_Draggable>();
            dragBehavior.gridManager = gridManager;
            dragBehavior.OnMouseDown();
            IEnumerator coroutine = DragPart(newPart);
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator DragPart(Transform part)
    {
        dragBehavior.OnMouseDown();
        while (mouseHeld)
        {
            yield return new WaitForSeconds(0.05f);
            dragBehavior.OnMouseDrag();
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        dragBehavior.OnMouseUp();
        mouseHeld = false;
    }
}