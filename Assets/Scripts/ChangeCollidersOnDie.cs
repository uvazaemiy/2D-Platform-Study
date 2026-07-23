using UnityEngine;

public class ChangeCollidersOnDie : MonoBehaviour
{
    [SerializeField] private Collider2D _collider1;
    [SerializeField] private Collider2D _collider2;

    public void ChangeColliders()
    {
        _collider1.enabled = false;
        _collider2.enabled = true;
    }
}
