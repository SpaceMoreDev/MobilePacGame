using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pac : MonoBehaviour
{
    CircleCollider2D pacCollider;
    [SerializeField] private paclogic pac;

    // Start is called before the first frame update
    void Start()
    {
        pacCollider = GetComponent<CircleCollider2D>();
        pac = transform.GetComponentInChildren<paclogic>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward, -Game.Speed * Time.deltaTime);
            
            if (pac)
            {
                pac.pacRenderer.flipX = true;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward, Game.Speed * Time.deltaTime);
                if (pac)
            {
                pac.pacRenderer.flipX = false;
            }
        }
    }

}
