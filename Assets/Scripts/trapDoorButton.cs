using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapDoorButton : MonoBehaviour
{
    public GameObject[] trapDoors;
    private Rigidbody2D trapDoorRB;
    public Sprite pressedSprite;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject trapDoor in trapDoors) {
            trapDoorRB = trapDoor.GetComponent<Rigidbody2D>();
            trapDoorRB.freezeRotation = true;
            trapDoorRB.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!other.gameObject.CompareTag("Particle")) {
            spriteRenderer.sprite = pressedSprite; 
            foreach(GameObject trapDoor in trapDoors) {
                trapDoorRB = trapDoor.GetComponent<Rigidbody2D>();
                trapDoorRB.freezeRotation = false;
                trapDoorRB.constraints = 0;
            }
        }
    }
}
