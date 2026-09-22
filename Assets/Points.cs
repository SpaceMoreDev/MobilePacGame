using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{   
    public static Points Instance { get; private set; }
    private List<Point> points = new List<Point>();
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

       foreach (Transform child in gameObject.transform)
        {
            Debug.Log("Found immediate child: " + child.name);
            
          points.Add(child.gameObject.GetComponent<Point>()); 
        }
    }
    

}
