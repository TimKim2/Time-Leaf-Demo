using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveByJoystick : MonoBehaviour
{

    Vector3 currentMoveDir = Vector3.zero;
    Rigidbody2D rg;
    public float move_sp = 1.5f;

    // Use this for initialization
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        Move_Joystick();
    }


    public void Move_Joystick()
    {
        rg.MovePosition(transform.position + currentMoveDir * Time.fixedDeltaTime * move_sp);
    }

    public void SetCurrentDir(Vector3 axis)
    {
        currentMoveDir = axis;
        currentMoveDir.z = 0;
    }
}
