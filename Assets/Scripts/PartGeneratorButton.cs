using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class PartGeneratorButton : Button
{
    public Transform generatedPartsContainer;
    public Transform partToGenerate;

    private bool mouseHeld = false;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        mouseHeld = true;
        //disable camera Pan/Zoom on touch or click
        Camera.main.GetComponent<Dossamer.PanZoom.PanZoomBehavior>().disableAllAxes();
        //Generate the new part
        Transform newPart = Instantiate(partToGenerate, generatedPartsContainer);
        Vector3 mousePosFromCamera = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPart.localPosition = new Vector3(mousePosFromCamera.x, mousePosFromCamera.y, 0);
        IEnumerator coroutine = DragPart(newPart);
        StartCoroutine(coroutine);
    }

    private IEnumerator DragPart(Transform part)
    {
        while (mouseHeld)
        {
            yield return new WaitForSeconds(0.01f);
            Vector3 mousePosFromCamera = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            part.localPosition = new Vector3(mousePosFromCamera.x, mousePosFromCamera.y, 0);
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        mouseHeld = false;
        //enable camera Pan/Zoom on release
        Camera.main.GetComponent<Dossamer.PanZoom.PanZoomBehavior>().enableAllAxes();
    }
}