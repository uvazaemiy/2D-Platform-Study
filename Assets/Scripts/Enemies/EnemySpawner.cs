using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [Space]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int maxEnemies;
    [SerializeField] private float spawnDelay;
    [Space]
    [SerializeField] private Transform[] spawnPoints;
    [Space]
    [SerializeField] private List<GameObject> allEnemies = new List<GameObject>();

    
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            if (allEnemies.Count < maxEnemies)
            {
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                
                GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
                newEnemy.GetComponent<BatAI>().player = player;
                
                newEnemy.GetComponent<AIDestinationSetter>().target = player;
                
                allEnemies.Add(newEnemy);
            }
            
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
