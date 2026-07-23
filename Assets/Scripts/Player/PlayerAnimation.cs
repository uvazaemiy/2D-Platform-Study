using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private ChangeCollidersOnDie _changeCollidersOnDie;   
    private Animator _animator;
    private Health _health;
    private PlayerController _playerController; 

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
        _playerController = GetComponent<PlayerController>();
        _changeCollidersOnDie = GetComponent<ChangeCollidersOnDie>();
    }

    private void OnEnable()
    {
        if (_health != null)
        {
            _health.OnDamaged += PlayHitAnimation;
            _health.OnKilled += PlayDieAnimation;
        }

        if (_playerController != null)
            _playerController.OnMove += PlayMoveAnimation;
    }

    private void OnDisable()
    {
        Debug.Log(_health);
        Debug.Log(_playerController);
        
        if (_health != null)
            _health.OnDamaged -= PlayHitAnimation;
        if (_playerController != null)
            _playerController.OnMove += PlayMoveAnimation;
    }

    private void PlayHitAnimation()
    {
        _animator.SetTrigger("Hit");
    }

    private void PlayMoveAnimation()
    {
        _animator.SetBool("Move", true);
    }

    private void PlayDieAnimation()
    {
        _animator.SetTrigger("Die");

        _changeCollidersOnDie.ChangeColliders();
    }
}
