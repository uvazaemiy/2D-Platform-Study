using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;

    public Action OnDamaged;
    

    private int _currentHealth;

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
            Debug.Log("Dead");
        }
        
        Debug.Log("Health: " + _currentHealth);
        
        OnDamaged?.Invoke();
    }

    public bool IsAlive()
    {
        return _currentHealth > 0;
    }
}
