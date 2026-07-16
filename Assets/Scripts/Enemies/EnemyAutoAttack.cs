using UnityEngine;

public class EnemyAutoAttack : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float attackCooldown = 1;

    private float timer;
    private AttackTargetFinder finder;

    private void Start()
    {
        finder = GetComponent<AttackTargetFinder>();
        timer = attackCooldown;
    }

    private void Update()
    {
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
        }
    }
}