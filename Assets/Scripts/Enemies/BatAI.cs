using UnityEngine;
using Pathfinding;

public class BatAI : MonoBehaviour
{
    public Transform player;
    public float stopDistance = 1.5f;
    [SerializeField] private float destroyDelay = 2;

    private AIPath aiPath;
    private SpriteRenderer spriteRenderer;

    private Animator _animator;
    private Health _health;
    private Rigidbody2D _rb;

    private void Awake()
    {
        aiPath = GetComponent<AIPath>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
        _rb =  GetComponent<Rigidbody2D>();
        
        if (_health != null)
        {
            _health.OnDamaged += PlayHitAnim;
            _health.OnKilled += PlayDieAnim;
        } 
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // Перевіряємо дистанцію до гравця
        bool checkDistance = distance > stopDistance;
        aiPath.canMove = checkDistance;

        // ПЕревіряємо позицію гравця відносно вісі X
        bool checkPositionX = player.position.x < transform.position.x;
        spriteRenderer.flipX = checkPositionX;
    }

    private void OnDisable()
    {
        if (_health != null)
        {
            _health.OnDamaged -= PlayHitAnim;
            _health.OnKilled -= PlayDieAnim;
        } 
    }
    
    
    private void PlayHitAnim()
    {
        _animator.SetTrigger("Hit");
    }
    
    private void PlayDieAnim()
    {
        aiPath.enabled = false;
        _rb.gravityScale = 1;
        
        _animator.SetBool("Die", true);
        
        Destroy(gameObject, destroyDelay);
    }
}