using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private static TMP_Text scoreText;
    void Start()
    {  
        scoreText = GetComponent<TMP_Text>();
        if (scoreText == null)
        {
            Debug.LogError("TMP_Text component not found on ScoreText GameObject.");
        }
    }

    public static void UpdateScore(int score)
    {
        // Assuming you have a Text component attached to the same GameObject
        TMP_Text textComponent = scoreText;
        if (textComponent != null)
        {
            textComponent.text = "Score: " + score.ToString();
        }
    }

    

}
