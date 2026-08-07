using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private ChangeCollidersOnDie _changeCollidersOnDie;   
    private Animator _animator;
    private Health _health;
    private PlayerController playerController;
    
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
        _changeCollidersOnDie = GetComponent<ChangeCollidersOnDie>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!_health.IsAlive() || !playerController.allowMoving) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Attack");
        }
    }

    private void OnEnable()
    {
        if (_health != null)
        {
            _health.OnDamaged += PlayHitAnimation;
            _health.OnKilled += PlayDieAnimation;
        }
    }

    private void OnDisable()
    {
        if (_health != null)
            _health.OnDamaged -= PlayHitAnimation;
    }

    private void PlayHitAnimation()
    {
        _animator.SetTrigger("Hit");
    }

    private void PlayDieAnimation()
    {
        _animator.SetTrigger("Die");

        StartCoroutine(_changeCollidersOnDie.ChangeColliders());
    }
}
