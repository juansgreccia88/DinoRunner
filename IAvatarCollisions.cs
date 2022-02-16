using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAvatarCollisions
{
    public bool isGrounded { get; set; }
    public bool enemyColision { get; set; }
    public void DetectEnemyCollision(Collision2D collision);
    public void DetectGroundedCollision(Collision2D collision);
    public void DetectExitGroundedCollision(Collision2D collision);
    
}
