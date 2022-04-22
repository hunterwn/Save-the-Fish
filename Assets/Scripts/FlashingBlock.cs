using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingBlock : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Collider2D coll;
    void Start()
    {
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        Color color = spriteRenderer.color;
        Color transparentColor = color;
        transparentColor.a = 0.2f;
        while(true) {
            spriteRenderer.color = color;
            coll.enabled = true;
            yield return new WaitForSeconds(2);
            coll.enabled = false;
            spriteRenderer.color = transparentColor;
            yield return new WaitForSeconds(2);
        }
    }
}
