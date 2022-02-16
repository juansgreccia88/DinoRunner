using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAvatarInput
{
    bool JumpingPressed { get; set; }
    public void Jumping();
}
