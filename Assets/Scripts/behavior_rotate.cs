using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this class to a 2d object to cause it to spin w.r.t frametime.
public class behavior_rotate : MonoBehaviour
{
    private float rotation_z; // the actual z value
    
    public float rotate_scalar_speed; // the rotation speed that can be dictated from the unity editor
    public bool rotate_counter_clockwise; // boolean to choose between rotating clockwise and counter clockwise
    
    // Update is called once per frame
    void Update()
    {
        rotation_z += ((rotate_counter_clockwise) ? (1) : (-1)) * Time.deltaTime * rotate_scalar_speed;
        transform.rotation = Quaternion.Euler(0,0,rotation_z);

    }
}
