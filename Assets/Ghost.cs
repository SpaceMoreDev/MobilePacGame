using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    Vector3 SlideDirection = Vector3.zero;
    public bool isActive = false;
    public float speed = 7;

    void Start()
    {
        // Initialize the ghost as inactive
        isActive = false;
        GetComponent<SpriteRenderer>().enabled = false; // Hide the ghost initially
    }

    public void Spawn(Vector3 Direction)
    {
        // Implement the logic to spawn the ghost here
        Debug.Log("Ghost spawned: " + gameObject.name);

        transform.position = Vector3.zero; // Reset position to origin or any desired spawn point
        isActive = true;
        GetComponent<SpriteRenderer>().enabled = true;
        SlideDirection = Direction.normalized*0.1f;
        StartCoroutine(WaitAndKill(10f)); // Start the coroutine to wait and then deactivate the ghost after 5 seconds
        
    }

    void Update()
    {
        if (!isActive) return;


        // Move the ghost in the specified direction
        transform.position += SlideDirection * speed * Time.deltaTime;
    }

    IEnumerator WaitAndKill(float waitTime)
    {
       
        yield return new WaitForSeconds(waitTime);
        isActive = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
