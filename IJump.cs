using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJump
{
    /*public void PressJump();
    public void notPressJump();*/
    void AvatarJump(bool jump);
    void RealisticFall();
    void JumpHeightVariation();
    public void CheckJump(bool jump);
}
