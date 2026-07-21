using UnityEngine;

public class EnemyAutoAttack : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float attackCooldown = 1;

    private float timer;
    private AttackTargetFinder finder;
    private Animator _animator;
    private Health  _health;

    private void Start()
    {
        finder = GetComponent<AttackTargetFinder>();
        _animator = GetComponent<Animator>();
        timer = attackCooldown;
        _health =  GetComponent<Health>();
    }

    private void Update()
    {
        if (!_health.IsAlive()) return;
        
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            TryAttack();
            timer = attackCooldown;
        }
    }

    private void TryAttack()
    {
        IAttackInteractable target = finder.FindTarget();

        if (target != null)
        {
            target.Interact(damage);
            _animator.SetTrigger("Attack");
        }
    }
}