using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapDoorButton : MonoBehaviour
{
    public GameObject[] trapDoors;
    private Rigidbody2D trapDoorRB;
    public Sprite pressedSprite;
    public SpriteRenderer spriteRenderer;
    public AudioSource trapDoorSound;
    public AudioSource trapDoorSound2;
    private bool pressed = false;

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
        if(!pressed && !other.gameObject.CompareTag("Particle")) {
            pressed = true;
            spriteRenderer.sprite = pressedSprite;
            trapDoorSound.Play();
            foreach (GameObject trapDoor in trapDoors) {
                trapDoorSound2.Play();
                trapDoorRB = trapDoor.GetComponent<Rigidbody2D>();
                trapDoorRB.freezeRotation = false;
                trapDoorRB.constraints = 0;
            }
        }
    }
}
