using UnityEngine;

public class AttackTargetFinder : MonoBehaviour
{
    [SerializeField] private float radius = 1.5f;
    [SerializeField] private LayerMask targetLayer;

    public IAttackInteractable FindTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            transform.position,
            radius,
            targetLayer
            );
        
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject == gameObject)
                continue;

            if (hit.TryGetComponent(out IAttackInteractable target))
            {
                return target;
            }
        }

        return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}