using System.Collections;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float attackDelay;

    private IAttackInteractable target;
    
    private AttackTargetFinder finder;
    private Health _health;
    
    

    private void Start()
    {
        finder = GetComponent<AttackTargetFinder>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (!_health.IsAlive()) return;
        
        target = finder.FindTarget();
        
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(TryAttack());
        }
    }

    private IEnumerator TryAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        
        if (target != null)
        {
            target.Interact(damage);
        }
    }
}
