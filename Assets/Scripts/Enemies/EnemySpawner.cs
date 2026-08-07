using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform player;
    [Space]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int maxEnemies;
    [SerializeField] private int maxEnemiesPerLevel = 20;
    [SerializeField] private float spawnDelay;
    [Space]
    [SerializeField] private Transform[] spawnPoints;
    [Space]
    [SerializeField] private List<GameObject> allEnemies = new List<GameObject>();

    private int allEnemiesCounter = 0;
    private int allDestroyedEnemiesCounter = 0;
    
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true &&  allEnemiesCounter < maxEnemiesPerLevel)
        {
            if (allEnemies.Count < maxEnemies)
            {
                int spawnPointIndex;

                do spawnPointIndex = Random.Range(0, spawnPoints.Length); 
                while (CheckSpawnDistance(spawnPointIndex));
                
                GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
                
                newEnemy.GetComponent<BatAI>().player = player;
                newEnemy.GetComponent<BatAI>().EnemySpawner = this;
                newEnemy.GetComponent<AIDestinationSetter>().target = player;
                
                allEnemies.Add(newEnemy);
                allEnemiesCounter++;
            }
            
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void RemoveEnemy(GameObject enemy, float destroyDelay)
    {
        allEnemies.Remove(enemy);
        Destroy(enemy, destroyDelay);

        allDestroyedEnemiesCounter++;
        if (allDestroyedEnemiesCounter >= maxEnemiesPerLevel)
            gameManager.EndLevel();
    }

    private bool CheckSpawnDistance(int index)
    {
        return spawnPoints[index].transform.position.z > 0 && spawnPoints[index].transform.position.x >= 0 && spawnPoints[index].transform.position.x <= 1 && spawnPoints[index].transform.position.y >= 0 && spawnPoints[index].transform.position.y <= 1;
    }
}
