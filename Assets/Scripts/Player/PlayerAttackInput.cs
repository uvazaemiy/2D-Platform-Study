using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    [SerializeField] private int damage = 1;

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
        
        if (Input.GetMouseButtonDown(0))
        {
            TryAttack();
        }
    }

    private void TryAttack()
    {
        IAttackInteractable target = finder.FindTarget();

        if (target != null)
        {
            target.Interact(damage);
        }
    }
}
