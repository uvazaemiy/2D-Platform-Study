using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    private AttackTargetFinder finder;

    private void Start()
    {
        finder = GetComponent<AttackTargetFinder>();
    }

    private void Update()
    {
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
