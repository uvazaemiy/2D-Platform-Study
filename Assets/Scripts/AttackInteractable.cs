using UnityEngine;

public class AttackInteractable : MonoBehaviour, IAttackInteractable
{
    private Health  health;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    public void Interact(int damage)
    {
        if (health.IsAlive())
            health.TakeDamage(damage);
    }
}
