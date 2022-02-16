using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{
    private IAvatarInput avatarInput;
    [SerializeField] private AvatarSetting avatarSetting;
    private AvatarController avatarController;

    public void Awake()
    {
        avatarInput = new InputHandler();
        avatarController = new AvatarController(this.GetComponent<Rigidbody2D>(), avatarInput, avatarSetting);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(avatarController.isGrounded);
        avatarInput.Jumping();
        avatarController.CheckJump(avatarInput.JumpingPressed);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        avatarController.DetectEnemyCollision(collision);
        avatarController.DetectGroundedCollision(collision);
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        avatarController.DetectExitGroundedCollision(collision);
    }
}
