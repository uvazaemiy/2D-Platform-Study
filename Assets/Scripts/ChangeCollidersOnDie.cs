using System.Collections;
using UnityEngine;

public class ChangeCollidersOnDie : MonoBehaviour
{
    [SerializeField] private float changeDelay;
    [SerializeField] private Collider2D _collider1;
    [SerializeField] private Collider2D _collider2;

    public IEnumerator ChangeColliders()
    {
        yield return new WaitForSeconds(changeDelay);
        
        _collider1.enabled = false;
        _collider2.enabled = true;
    }
}
