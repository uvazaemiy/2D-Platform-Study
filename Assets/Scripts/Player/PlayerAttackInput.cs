using System.Collections;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float attackDelay;
    
    private IAttackInteractable target;
    
    private AttackTargetFinder finder;
    private Health _health;
    private PlayerController playerController;
    
    

    private void Awake()
    {
        finder = GetComponent<AttackTargetFinder>();
        _health = GetComponent<Health>();
        playerController = GetComponent<PlayerController>();

        damage = PlayerPrefs.GetInt("MaxDamage", damage);
        PlayerPrefs.SetInt("MaxDamage", damage);
    }

    private void Update()
    {
        if (!_health.IsAlive() || !playerController.allowMoving) return;
        
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
