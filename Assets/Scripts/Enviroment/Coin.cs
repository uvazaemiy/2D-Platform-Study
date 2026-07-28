using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
    public static event Action<int> OnCoinCollected;
    
    [SerializeField] private float jumpForceMin = 4f;
    [SerializeField] private float jumpForceMax = 7f;
    [SerializeField] private float sideForce = 2f;
    [SerializeField] private int coinValue = 1;
    [Space]
    [SerializeField] private float collactableDelay;

    private Rigidbody2D _rb;
    private bool isCollactable;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        float randomJump = Random.Range(jumpForceMin, jumpForceMax);
        float randomDir = Random.Range(-sideForce, sideForce);
        Vector2 popDirection = new Vector2(randomDir, randomJump);
        
        _rb.AddForce(popDirection, ForceMode2D.Impulse);

        StartCoroutine(ChangeCollatable());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isCollactable && other.gameObject.CompareTag("Player"))
        {
            OnCoinCollected?.Invoke(coinValue);
            Destroy(gameObject);
        }
    }

    private IEnumerator ChangeCollatable()
    {
        yield return new WaitForSeconds(collactableDelay);
        
        isCollactable = true;
    }
}
