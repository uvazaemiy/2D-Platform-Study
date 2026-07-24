using UnityEngine;
using Pathfinding;

public class BatAI : MonoBehaviour
{
    public EnemySpawner EnemySpawner;
    public Transform player;
    public float stopDistance = 1.5f;
    [SerializeField] private float destroyDelay = 2;
    [SerializeField] private GameObject coinPrefab;

    private AIPath aiPath;
    private SpriteRenderer spriteRenderer;

    private Animator _animator;
    private Health _health;
    private Rigidbody2D _rb;
    private ChangeCollidersOnDie _changeCollidersOnDie;

    private void Awake()
    {
        aiPath = GetComponent<AIPath>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
        _rb =  GetComponent<Rigidbody2D>();
        _changeCollidersOnDie = GetComponent<ChangeCollidersOnDie>();
        
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
        
        StartCoroutine(_changeCollidersOnDie.ChangeColliders());
        
        EnemySpawner.RemoveEnemy(gameObject, destroyDelay);
        
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }
}