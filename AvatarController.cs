using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : IJump, IAvatarCollisions
{
    private Rigidbody2D rb;
    private IAvatarInput avatarInput;
    private AvatarSetting avatarSetting;

    public bool isGrounded;
    public bool enemyColision;
    public bool jump;

    bool IAvatarCollisions.isGrounded { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    bool IAvatarCollisions.enemyColision { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public AvatarController(Rigidbody2D _rb, IAvatarInput _avatarInput, AvatarSetting _avatarSetting)
    {
        this.rb = _rb;
        this.avatarInput = _avatarInput;
        this.avatarSetting = _avatarSetting;
    }

    public void AvatarJump(bool jump)
    {
        if (jump == true && isGrounded)
        {
            rb.velocity = Vector2.up * avatarSetting.JumpVelocity;

        }

    }

    public void RealisticFall()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (avatarSetting.FallMultiplier - 1) * Time.deltaTime;
        }
    }

    public void JumpHeightVariation()
    {
        if (rb.velocity.y > 0 && jump == false)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (avatarSetting.LowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public void CheckJump(bool jump)
    {
        if (GameManager.Instance.gameState == GameManager.GameState.PLAY)
        {
            AvatarJump(jump);
            JumpHeightVariation();
            RealisticFall();
        }
    }

    public void DetectEnemyCollision(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    public void DetectGroundedCollision(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            enemyColision = true;
            Time.timeScale = 0;
        }
    }

    public void DetectExitGroundedCollision(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            isGrounded = false;
        }
    }
}
