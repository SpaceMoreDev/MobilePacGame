using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class paclogic : MonoBehaviour
{
    public SpriteRenderer pacRenderer;

    void Start()
    {
        pacRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.CompareTag("Point"))
        {
            Point point = other.gameObject.GetComponent<Point>();
            if (point != null)
            {
                Debug.Log("Pac collided with a point!");
                
                point.EatPoint();
                
            }
        }
        else if (other.gameObject.CompareTag("Ghost"))
        {
            Debug.Log("Pac collided with an enemy!");
            Game.Score = 0;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            Point point = other.gameObject.GetComponent<Point>();
            if (point != null)
            {
                point.PauseSpawnCoroutine();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            Point point = other.gameObject.GetComponent<Point>();
            if (point != null)
            {
                if (point.isEaten)
                {
                    point.continueSpawnCoroutine();
                }
            }
        }
    }

}
