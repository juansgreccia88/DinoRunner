using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * speed * Time.deltaTime;
    }
}
