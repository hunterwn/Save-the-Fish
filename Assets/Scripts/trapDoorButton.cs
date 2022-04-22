using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapDoorButton : MonoBehaviour
{
    public GameObject trapDoor;
    private Rigidbody2D trapDoorRB;
    public Sprite pressedSprite;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        trapDoorRB = trapDoor.GetComponent<Rigidbody2D>();
        trapDoorRB.freezeRotation = true;
        trapDoorRB.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!other.gameObject.CompareTag("Particle")) {
            spriteRenderer.sprite = pressedSprite; 
            trapDoorRB.freezeRotation = false;
            trapDoorRB.constraints = 0;
        }
    }
}
