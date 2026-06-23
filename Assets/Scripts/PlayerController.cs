using System;
using UnityEngine;






public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveForce = 5f;
    
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;


    
    
    
    
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0)
        {
            sr.flipX = true;
            anim.SetBool("Move", true);
        }
        else if (horizontal < 0)
        {
            sr.flipX = false;
            anim.SetBool("Move", true);
        }
        else
            anim.SetBool("Move", false);
        
        Vector2 moveDirection = new Vector2(horizontal, vertical);
        rb.linearVelocity = moveDirection.normalized * moveSpeed;

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }
    }
}