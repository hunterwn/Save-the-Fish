using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// // attach this class to a 2d object to cause it to move up and down wrt time.
public class behavior_translate_UD_wrt_time : MonoBehaviour
{
    private Vector3 location_object_postion = Vector3.zero;
    public float translate_down, translate_up; //translate left must be negative, translate right must be positive
    public float translation_scalar_speed; // it's probably not a good idea in the end to attach to framerate but for now, it will be fine
    public bool should_move, at_lim_down, at_lim_up; // flags

    void Awake()
    {
        location_object_postion = transform.position;
    }
    void FixedUpdate()
    {
        if(should_move)
        {
            if (!at_lim_up)
            {
                if (transform.position.y < location_object_postion.y + translate_up)
                    Move_object(translate_up);
                else if (transform.position.y >= location_object_postion.y + translate_up)
                    at_lim_down = !(at_lim_up = true);

            }
            else if (!at_lim_down)
            {
                if (transform.position.y > location_object_postion.y + translate_down)
                    Move_object(translate_down);
                else if (transform.position.y <= location_object_postion.y + translate_down)
                    at_lim_down = !(at_lim_up = false);
            }
        }
    }

    void Move_object(float translation_offset)
    {
        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3( transform.position.x,location_object_postion.y + translation_offset, transform.position.z),
            translation_scalar_speed * Time.deltaTime);
    }
}
