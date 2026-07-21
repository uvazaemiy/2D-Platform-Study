using System;
using UnityEngine;






public class PlayerController : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    [Space]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveForce = 5f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGrounded;

    public Action OnMove;
    
    private SpriteRenderer sr;
    public Rigidbody2D rb;
    private Animator anim;
    private Health health;

    private float groundCheckRadius = 0.2f;
    
    
    
    
    
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    private void Update()
    {
        if (!health.IsAlive()) return;
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            sr.flipX = true;
            
            cameraFollow.offset = cameraFollow.offset.x < 0 ? 
                new Vector3(cameraFollow.offset.x * -1, cameraFollow.offset.y, cameraFollow.offset.z) 
                : cameraFollow.offset;
            
            OnMove?.Invoke();
        }
        else if (horizontal < 0)
        {
            sr.flipX = false;
            
            cameraFollow.offset = cameraFollow.offset.x > 0 ? 
                new Vector3(cameraFollow.offset.x * -1, cameraFollow.offset.y, cameraFollow.offset.z) 
                : cameraFollow.offset;
            
            OnMove?.Invoke();
        }
        else
            anim.SetBool("Move", false);

        
        
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);

        
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }
    }
}