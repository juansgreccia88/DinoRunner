using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputHandler : IAvatarInput
{
    public bool JumpingPressed { get; set; }

    public void Jumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
            JumpingPressed = true;
        }
        if (!Input.GetButton("Jump"))
        {
            JumpingPressed = false;
        }
    }
}
