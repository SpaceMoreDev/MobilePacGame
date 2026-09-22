using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float spawnInterval = 1f; // Time in seconds between spawns
    static public EnemySpawner Instance; // Reference to the enemy prefab

    [SerializeField] GameObject enemyPrefab; // Reference to the enemy prefab

    List<Ghost> EnemyList = new List<Ghost>(); // List to keep track of spawned enemies

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        StartCoroutine(WaitAndSpawn(spawnInterval)); // Call the WaitAndSpawn method to spawn an enemy after the initial interval

        for (int i = 0; i < 100; i++)
        {
            Ghost enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity).GetComponent<Ghost>();
            enemy.transform.parent = transform; // Set the parent of the enemy to the spawner for organization
            EnemyList.Add(enemy);
        }

    }

    Ghost GetEnemyFromPool()
    {
        foreach (Ghost enemy in EnemyList)
        {
            if (!enemy.isActive)
            {
                return enemy; // Return the first inactive enemy found in the pool
            }
        }
        return null; // Return null if no inactive enemies are found
    }

    // Update is called once per frame
    void Spawn()
    {
        if (Instance == null)
        {
            Debug.LogError("EnemySpawner instance is not set.");
            return;
        }

        Vector2 origin = Instance.transform.position;
        Vector2 direction = Random.insideUnitCircle.normalized; // Random direction
        float maxDistance = 1;

        Debug.DrawRay(origin, direction * maxDistance, Color.red,2f);

        GetEnemyFromPool()?.Spawn(direction * Game.Speed); // Spawn the enemy in the random direction with the specified speed

        StartCoroutine(WaitAndSpawn(spawnInterval));
    }

    IEnumerator WaitAndSpawn(float waitTime)
    {
       
        yield return new WaitForSeconds(waitTime);
        Spawn();
    }
}
