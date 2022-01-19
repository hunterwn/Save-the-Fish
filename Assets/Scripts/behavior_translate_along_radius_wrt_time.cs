using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// attach this class to a 2d object to cause it to move circularly around a point.
// requires further debugging to remove possible overflow over time and provide counter movement.
// requires further development to allow for elliptical movement 
public class behavior_translate_along_radius_wrt_time : MonoBehaviour
{
    public float distance_scalar_radius;
    public Vector3 location_circle_origin;
    public float translate_scalar_radial_speed; // the speed that can be dictated from the unity editor
    public bool translate_radial_clockwise;
    public float angle_theta_radian; // this should probably use a managed structure instead
    void Awake()
    {
       // more must be done later.
    }


    // Update is called once per frame
    void Update()
    {
        angle_theta_radian += translate_scalar_radial_speed * Time.deltaTime;
        Vector3 offset = new Vector3(Mathf.Sin(angle_theta_radian), Mathf.Cos((angle_theta_radian)), 0); 
        transform.position = location_circle_origin + offset; // basic trig and linear algebra

    }
}
