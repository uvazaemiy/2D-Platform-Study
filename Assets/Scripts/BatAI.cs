using UnityEngine;
using Pathfinding;

public class BatAI : MonoBehaviour
{
    public Transform player;
    public float stopDistance = 1.5f;

    private AIPath aiPath;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        aiPath = GetComponent<AIPath>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // Перевіряємо дистанцію до гравця
        bool checkDistance = distance > stopDistance;
        aiPath.canMove = checkDistance;

        // ПЕревіряємо позицію гравця відносно вісі X
        bool checkPositionX = player.position.x < transform.position.x;
        spriteRenderer.flipX = checkPositionX;
    }
}