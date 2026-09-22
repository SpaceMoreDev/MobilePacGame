using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public bool isEaten = false;
    public Coroutine spawnCoroutine = null;


    public void EatPoint()
    {
        if (isEaten) return; // Prevent eating the point if it's already eaten
        
        isEaten = true;
        GetComponent<SpriteRenderer>().enabled = false;
        StartSpawnCoroutine();
        Debug.Log("Point eaten: " + gameObject.name);

        Game.UpdateScore(Game.Score + 1);
        
    }

    public void StartSpawnCoroutine()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(WaitAndSpawn(this));
        }
    }

    public void PauseSpawnCoroutine()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    public void continueSpawnCoroutine()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(WaitAndSpawn(this));
        }
    }

    public void Spawn()
    {
        isEaten = false;
        GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("Point spawned: " + gameObject.name);
    }

    static IEnumerator WaitAndSpawn(Point point)
    {
        yield return new WaitForSeconds(1f);

        point.Spawn();
    }
}
