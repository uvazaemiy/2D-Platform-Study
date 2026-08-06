using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 5;
    [SerializeField] protected int _currentHealth;

    public Action OnDamaged;
    public Action OnKilled;
    


    private void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (!IsAlive())
        {
            _currentHealth = 0;
            OnKilled?.Invoke();
        }
        
        OnDamaged?.Invoke();
    }

    public bool IsAlive()
    {
        return _currentHealth > 0;
    }
}
