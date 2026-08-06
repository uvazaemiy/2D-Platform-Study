using System.Collections;
using UnityEngine;

public class EnemyAutoAttack : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float attackCooldown = 1;
    [SerializeField] private float attackDelay = 0.5f;

    private IAttackInteractable target;
    private bool tryAttacking;
    
    private AttackTargetFinder finder;
    private Animator _animator;
    private Health  _health;

    

    private void Start()
    {
        finder = GetComponent<AttackTargetFinder>();
        _animator = GetComponent<Animator>();
        _health =  GetComponent<Health>();
    }

    private void Update()
    {
        if (!_health.IsAlive()) return;

        target = finder.FindTarget();
        
        if (!tryAttacking && target != null)
            StartCoroutine(TryAttack());
    }

    private IEnumerator TryAttack() 
    {
        tryAttacking = true;
        
        _animator.SetTrigger("Attack");
        
        yield return new WaitForSeconds(attackDelay);
        
        if (target != null)
        {
            target.Interact(damage);
        }
        else
            tryAttacking = false;

        if (tryAttacking)
            yield return new WaitForSeconds(attackCooldown - attackDelay);
        
        tryAttacking = false;
    }
}