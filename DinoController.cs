using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour, IJump
{
    private Rigidbody2D Rb;
    [SerializeField] private float jumpVelocity;
    [SerializeField] bool isGrounded;

    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 2f;

    public bool jump;

    GameManager gameManager;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        else if (!Input.GetButton("Jump"))
        {
            jump = false;
        }
    }

    private void FixedUpdate()
    {
        if (gameManager.gameState == GameManager.GameState.PLAY)
        {
            Jump();
            JumpHeightVariation();
            RealisticFall();
        }
            
    }

    public void Jump()
    {
        if (jump == true && isGrounded)
        {
            Rb.velocity = Vector2.up * jumpVelocity;
        }
        
    }

    public void RealisticFall()
    {
        if (Rb.velocity.y < 0)
        {
            Rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    public void JumpHeightVariation()
    {
        if (Rb.velocity.y > 0 && jump == false)
        {
            Rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            isGrounded = true;
        }
        else if (collision.collider.tag == "Enemy")
        {
            Time.timeScale = 0;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            isGrounded = false;
        }
    }
}
