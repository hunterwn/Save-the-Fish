using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attach this class to a 2d object to cause it to move left and right wrt.
public class behavior_translate_LR_wrt_time : MonoBehaviour
{
    private Vector3 location_object_postion = Vector3.zero;
    public float translate_left, translate_right; //translate left must be negative, translate right must be positive
    public float translation_scalar_speed; // it's probably not a good idea in the end to attach to framerate but for now, it will be fine
    public bool should_move, at_lim_left, at_lim_right; // flags

    void Awake()
    {
        location_object_postion = transform.position;
    }
    void FixedUpdate()
    {
        if(should_move)
        {
            if (!at_lim_right)
            {
                if (transform.position.x < location_object_postion.x + translate_right)
                    Move_object(translate_right);
                else if (transform.position.x >= location_object_postion.x + translate_right)
                    at_lim_left = !(at_lim_right = true);

            }
            else if (!at_lim_left)
            {
                if (transform.position.x > location_object_postion.x + translate_left)
                    Move_object(translate_left);
                else if (transform.position.x <= location_object_postion.x + translate_left)
                    at_lim_left = !(at_lim_right = false);
            }
        }
    }

    void Move_object(float translation_offset)
    {
        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(location_object_postion.x + translation_offset, transform.position.y, transform.position.z),
            translation_scalar_speed * Time.deltaTime);
    }
}
